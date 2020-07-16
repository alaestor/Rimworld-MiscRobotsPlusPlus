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
        public static void Postfix(Pawn __instance, bool permanentOnly, ref List<WorkTypeDef> __result)
        {
            // TODO: need to handle non-permanent as well? This is only to disable on work tab
            if (!permanentOnly || __result.Count > 0 || !(__instance is X2_AIRobot robot) || robot.def2 == null) return;

            var permanentlyDisabled = DefDatabase<WorkTypeDef>.AllDefsListForReading
                .Where(d => !robot.def2.robotWorkTypes.Any(rwt => rwt.workTypeDef == d))
                .ToList();

            __result.AddRange(permanentlyDisabled);
            __result = __result.Distinct().ToList();

            Messages.Message("Set permanently disabled for " + robot.ToString(), MessageTypeDefOf.NeutralEvent);
            var prop = typeof(Pawn).GetField("cachedDisabledWorkTypesPermanent", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(robot, __result);
        }
    }
}
