using AIRobot;
using HarmonyLib;
using RimWorld;
using System.Linq;
using Verse;

namespace MiscRobotsPlusPlus.Patches
{
    [HarmonyPatch(typeof(Pawn_WorkSettings), "SetPriority")]
    class PatchSetWorkSettings
    {
        public static void Prefix(WorkTypeDef w, int priority, Pawn ___pawn)
        {
            // Reflect updated work setting in robotWorkTypes
            if (!(___pawn is X2_AIRobot robot)) return;

            var workSetting = robot.def2?.robotWorkTypes?.FirstOrDefault(rwt => rwt.workTypeDef == w);
            if (workSetting == null || workSetting.priority == priority) return;

            workSetting.priority = priority;
            ClearWorkGiverCache(robot);
        }

        private static void ClearWorkGiverCache(X2_AIRobot robot)
        {
            var prop = robot.GetType().GetField("workGiversNonEmergencyCache", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(robot, null);
            var prop2 = robot.GetType().GetField("workGiversEmergencyCache", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop2.SetValue(robot, null);
        }

        /*public static void Prefix(WorkTypeDef w, int priority, Pawn ___pawn)
        {
            // Reflect updated work setting in robotWorkTypes
            if (!(___pawn is AIRobot.X2_AIRobot robot)) return;

            robot.def2.robotWorkTags = WorkTags.AllWork;

            var key = robot.ToString() + " - " + w;
            var workSetting = robot.def2?.robotWorkTypes?.FirstOrDefault(rwt => rwt.workTypeDef == w);
            if (workSetting == null && !_defaultPriorities.ContainsKey(key)) return;
            bool update = false;
            if (workSetting != null)
            {
                update = workSetting.priority != priority;
                if (!_defaultPriorities.ContainsKey(key)) _defaultPriorities[key] = workSetting.priority;
                if (priority == 0)
                {
                    robot.def2?.robotWorkTypes?.Remove(workSetting);
                }
                else
                {
                    workSetting.priority = priority;
                }
            }
            else if (priority != 0)
            {
                robot.def2?.robotWorkTypes?.Add(new RobotWorkTypes()
                {
                    priority = _defaultPriorities[key],
                    workTypeDef = w
                });
                update = true;
            }

            if (update)
            {
                //robot.workSettings.EnableAndInitialize();

                var prop = robot.GetType().GetField("workGiversNonEmergencyCache", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                prop.SetValue(robot, null);
                var prop2 = robot.GetType().GetField("workGiversEmergencyCache", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                prop2.SetValue(robot, null);
            }
            /*var prop = s.GetType().GetField("id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(s, "new value");*/
        //}
    }
}
