using HarmonyLib;
using MiscRobotsPlusPlus.Patches;
using System.Collections.Generic;
using Verse;

namespace MiscRobotsPlusPlus.Compatibility
{
    class PatchWorkTab
    {
        public static void Patch(Harmony harmony)
        {
            if (ModLister.HasActiveModWithName("Work Tab"))
            {
                var parameters = new[]
                {
                    new[] { typeof(WorkTypeDef), typeof(int), typeof(List<int>) },
                    new[] { typeof(WorkTypeDef), typeof(int), typeof(int) },
                    new[] { typeof(WorkTypeDef), typeof(int), typeof(int), typeof(bool) }
                };
                foreach (var p in parameters)
                {
                    var method = AccessTools.Method("WorkTab.PriorityTracker:SetPriority", p);
                    if (method == null) continue;
                    harmony.Patch(original: method, prefix: new HarmonyMethod(typeof(PatchWorkTab), nameof(Prefix_SetPriority)));
                }
            }
        }

        public static void Prefix_SetPriority(object __instance, WorkTypeDef worktype, int priority)
        {
            /*var t = __instance.GetType();
            var prop = t.GetProperty("Pawn");
            var pawn = prop.GetValue(__instance, null) as Pawn;*/

            var pawn = __instance?.GetType()?.GetProperty("Pawn")?.GetValue(__instance, null) as Pawn;
            if (pawn == null)
            {
                Log.Message($"Misc. Robots++: couldn't find pawn when trying to set priority {priority} for {worktype}");
            }
            else
            {
                SetPriorityImplementation.Impl(pawn, worktype, priority, "fluffy worktype");
            }
        }
    }
}
