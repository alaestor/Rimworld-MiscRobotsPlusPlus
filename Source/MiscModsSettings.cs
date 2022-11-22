using HarmonyLib;
using MiscRobotsPlusPlus.Patches;
using System.Collections.Generic;
using System.Reflection;
using Verse;

namespace MiscRobotsPlusPlus
{
    public class MiscModsSettings : ModSettings
    {
        internal static float tier_1_ConstrctionSpeed = 1f;
        internal static float tier_1_DeepDrillSpeed = 1f;
        internal static List<ThingDef> database;
        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref tier_1_ConstrctionSpeed, "tier_1_ConstrctionSpeed", 1f);
        }
    }
}
