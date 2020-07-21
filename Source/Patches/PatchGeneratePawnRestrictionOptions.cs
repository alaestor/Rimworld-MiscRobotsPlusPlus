using AIRobot;
using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Verse;

namespace MiscRobotsPlusPlus.Patches
{
    // Add robots to bill target list
    public class PatchGeneratePawnRestrictionOptions
    {
        public static void Patch(Harmony harmony)
        {
            var nestedTypes = typeof(Dialog_BillConfig).GetNestedTypes(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            var targetType = nestedTypes.FirstOrDefault(t => t.FullName.Contains("GeneratePawnRestrictionOptions"));
            var targetMethod = targetType.GetMethod("MoveNext", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            harmony.Patch(targetMethod, transpiler: new HarmonyMethod(typeof(PatchGeneratePawnRestrictionOptions), nameof(Transpiler)));
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var originalCall = typeof(PawnsFinder).GetMethod("get_AllMaps_FreeColonists");
            var getColonists = typeof(ColonistsAndRobotsFinder).GetMethod("GetColonistsAndRobots");
            var bill = typeof(Dialog_BillConfig).GetField("bill", BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Call && instruction.Calls(originalCall))
                {
                    yield return new CodeInstruction(OpCodes.Ldloc_2);
                    yield return new CodeInstruction(OpCodes.Ldfld, bill);
                    yield return new CodeInstruction(OpCodes.Call, getColonists);
                }
                else
                {
                    yield return instruction;
                }
            }
        }
    }

    public class ColonistsAndRobotsFinder
    {
        public static List<Pawn> GetColonistsAndRobots(Bill bill)
        {
            var originalTab = Activator.CreateInstance(typeof(X2_MainTabWindow_Robots)) as MainTabWindow_PawnTable;
            var originalPawnsFunc = typeof(X2_MainTabWindow_Robots).GetProperty("Pawns", BindingFlags.Instance | BindingFlags.NonPublic);
            var robots = (originalPawnsFunc.GetValue(originalTab) as IEnumerable<Pawn>)
                ?.Select(r => r as X2_AIRobot)
                ?.ToList();
            var ret = PawnsFinder.AllMaps_FreeColonists;
            if (robots == null) return ret;

            var workGiver = bill?.billStack?.billGiver?.GetWorkgiver();
            if (workGiver != null)
            {
                // Check directly against source def since Misc. Robots doesn't initialize def2 until the robot is activated
                robots = robots
                    .Where(r => r.def is X2_ThingDef_AIRobot def2
                        && (def2.robotWorkTypes?.Any(rwt => rwt.workTypeDef == workGiver.workType) ?? false))
                    .ToList();
            }
            else
            {
                Log.Message("Misc. Robots++: Couldn't find workGiver in GeneratePawnRestrictionOptions, skipping filtering of robots");
            }

            ret.AddRange(robots);
            return ret;
        }
    }
}