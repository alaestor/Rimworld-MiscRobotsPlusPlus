using AIRobot;
using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace MiscRobotsPlusPlus.Patches
{
    [HarmonyPatch(typeof(Pawn), "GetDisabledWorkTypes")]
    class PatchPawn_GetDisabledWorkTypes
    {
        // Add disabled work types from robotWorkTypes for robots since they aren't listed in normal work types
        public static void Postfix(Pawn __instance, bool permanentOnly, ref List<WorkTypeDef> __result)
        {
            if (__result.Count > 0 || !(__instance is X2_AIRobot robot) || robot.def2 == null) return;

            var permanentlyDisabled = DefDatabase<WorkTypeDef>.AllDefsListForReading
                .Where(d => !robot.def2.robotWorkTypes.Any(rwt => rwt.workTypeDef == d))
                .ToList();

            __result.AddRange(permanentlyDisabled);
            __result = __result.Distinct().ToList();

            var fieldToUpdate = permanentOnly ? "cachedDisabledWorkTypesPermanent" : "cachedDisabledWorkTypes";
            var prop = typeof(Pawn).GetField(fieldToUpdate, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(robot, __result);
        }
    }
}
