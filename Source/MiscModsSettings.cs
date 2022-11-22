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

        #region Robots Settings

        #region Cleaner Settings
        internal static float tier_1_CleaningSpeed = 1f;
        internal static float tier_2_CleaningSpeed = 1.5f;
        internal static float tier_3_CleaningSpeed = 2f;
        internal static float tier_4_CleaningSpeed = 3f;
        internal static float tier_5_CleaningSpeed = 4f;
        #endregion

        #region Crafter
        internal static float tier_1_CrafterLaborSpeed = 1f;
        internal static float tier_2_CrafterLaborSpeed = 1.5f;
        internal static float tier_3_CrafterLaborSpeed = 2f;
        internal static float tier_4_CrafterLaborSpeed = 3f;
        internal static float tier_5_CrafterLaborSpeed = 4f;
        #endregion

        #endregion
        internal static List<ThingDef> database;
        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref tier_1_ConstrctionSpeed, "tier_1_ConstrctionSpeed", 1f);
        }
    }
}
