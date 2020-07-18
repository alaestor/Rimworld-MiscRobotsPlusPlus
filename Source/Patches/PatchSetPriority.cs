using AIRobot;
using HarmonyLib;
using RimWorld;
using System.Linq;
using Verse;

namespace MiscRobotsPlusPlus.Patches
{
    [HarmonyPatch(typeof(Pawn_WorkSettings), "SetPriority")]
    class PatchVanillaSetPriority
    {
        public static void Prefix(WorkTypeDef w, int priority, Pawn ___pawn)
        {
            SetPriorityImplementation.Impl(___pawn, w, priority, "vanilla");
        }
    }

    /*// Doesn't work
    [HarmonyPatch(typeof(PriorityTracker), "SetPriority")]
    [HarmonyPatch(new[] { typeof(WorkGiverDef), typeof(int), typeof(List<int>) })]
    [HarmonyPatch(new[] { typeof(WorkGiverDef), typeof(int), typeof(int) })]
    [HarmonyPatch(new[] { typeof(WorkGiverDef), typeof(int), typeof(int), typeof(bool) })]
    class PatchWorkTabSetPrioritySubTasks
    {
        public static void Prefix(PriorityTracker __instance, WorkGiverDef workgiver, int priority)
        {
            SetPriorityImplementation.Impl(__instance?.Pawn, workgiver?.workType, priority, "fluffy workgiver");
        }
    }*/

    class SetPriorityImplementation
    {
        public static void Impl(Pawn pawn, WorkTypeDef worktype, int priority, string debugType)
        {
            if (!(pawn is X2_AIRobot robot)) return;

            var workSetting = robot.def2?.robotWorkTypes?.FirstOrDefault(rwt => rwt.workTypeDef == worktype);
            if (workSetting == null || workSetting.priority == priority) return;

            workSetting.priority = priority;
            Messages.Message("Set " + debugType + " prio for " + pawn + " to " + priority, MessageTypeDefOf.NeutralEvent);
            ClearWorkGiverCache(robot);
        }

        public static void ClearWorkGiverCache(X2_AIRobot robot)
        {
            var prop = robot.GetType().GetField("workGiversNonEmergencyCache", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(robot, null);
            var prop2 = robot.GetType().GetField("workGiversEmergencyCache", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop2.SetValue(robot, null);
        }
    }
}
