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
            var robots = originalPawnsFunc.GetValue(originalTab) as IEnumerable<Pawn>;

            var workGiver = bill?.billStack?.billGiver?.GetWorkgiver();
            if (workGiver != null)
            {
                robots = robots.Where(r => !r.WorkTypeIsDisabled(workGiver.workType));
            }
            else
            {
                Log.Message("Misc. Robots++: Couldn't find workGiver in GeneratePawnRestrictionOptions, skipping filtering of robots");
            }

            var colonists = PawnsFinder.AllMaps_FreeColonists;
            colonists.AddRange(robots);
            return colonists;
        }
    }
}
