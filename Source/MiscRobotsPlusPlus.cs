using HarmonyLib;
using MiscRobotsPlusPlus.Patches;
using RimWorld;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Verse;

namespace MiscRobotsPlusPlus
{
    [StaticConstructorOnStartup]
    public class MiscRobotsPlusPlus : Mod
    {
        static MiscRobotsPlusPlus()
        {
            var harmony = new Harmony("MiscRobotsPlusPlus");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            PatchGeneratePawnRestrictionOptions.Patch(harmony);
        }

        public MiscRobotsPlusPlus(ModContentPack content) : base(content)
        {
            LongEventHandler.ExecuteWhenFinished(GetSettings);
            LongEventHandler.ExecuteWhenFinished(PushDatabase);
        }
        private void PushDatabase()
        {
            MiscModsSettings.database = DefDatabase<ThingDef>.AllDefsListForReading;
        }
        //This fucker would take ages to write. Hopefully i was smart.
        public override void WriteSettings()
        {
            base.WriteSettings();

            //Cleaners
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_1_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_1_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_2_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_2_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_3_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_3_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_4_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_4_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_5_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_5_CleaningSpeed);

            //Builders
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_1_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_1_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_1_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_1_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_1_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_1_Builder_SmoothingSpeed);

            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_2_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_2_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_2_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_2_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_2_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_2_Builder_SmoothingSpeed);

            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_3_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_3_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_3_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_3_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_3_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_3_Builder_SmoothingSpeed);

            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_4_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_4_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_4_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_4_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_4_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_4_Builder_SmoothingSpeed);

            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_5_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_5_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_5_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_5_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_5_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_5_Builder_SmoothingSpeed);

            //Crafter
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_CrafterLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_CrafterLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_CrafterLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_CrafterLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_CrafterLaborSpeed);
            //ER
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_ERTendingLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_ERTendingLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_ERTendingLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_ERTendingLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_ERTendingLaborSpeed);
            //Kitchen
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_KitchenGeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_KitchenPlantHarvestYield);

            SaveSettingForStatModifer(ThingDefRobotsOf.ER_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenGeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenPlantHarvestYield);

            SaveSettingForStatModifer(ThingDefRobotsOf.ER_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenGeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenPlantHarvestYield);

            SaveSettingForStatModifer(ThingDefRobotsOf.ER_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenGeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenPlantHarvestYield);

            SaveSettingForStatModifer(ThingDefRobotsOf.ER_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenGeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenPlantHarvestYield);

            //Omni
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_ConstructSuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_DrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_MedicalSurgerySuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_MiningYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_PlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_PlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Omni_WorkTableWorkSpeedFactor);

            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_ConstructSuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_DrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_MedicalSurgerySuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_MiningYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_PlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_PlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Omni_WorkTableWorkSpeedFactor);

            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_ConstructSuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_DrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_MedicalSurgerySuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_MiningYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_PlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_PlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Omni_WorkTableWorkSpeedFactor);

            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_ConstructSuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_DrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_MedicalSurgerySuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_MiningYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_PlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_PlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Omni_WorkTableWorkSpeedFactor);

            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_ConstructSuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_DrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_MedicalSurgerySuccessChance);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_MiningYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_PlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_PlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Omni_WorkTableWorkSpeedFactor);


        }
        public override string SettingsCategory()
        {
            return "MISC_Robots_Category".Translate();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
          
            Listing_Standard guiStandard = new Listing_Standard();
            MiscModsSettings.DrawSetting(guiStandard, inRect);

            base.DoSettingsWindowContents(inRect);
        }

        void GetSettings()
        {
            GetSettings<MiscModsSettings>();
        }
        //This helper method saved crap ton of time
        //Returns Stat modifier
        private void SaveSettingForStatModifer(string def, StatDef stat, float settings)
        {
            StatModifier statModifier = null;
            foreach (StatModifier statBasis in DefDatabase<ThingDef>.GetNamed(def).statBases)
            {
                if (statBasis.stat == stat)
                {
                    statModifier = statBasis;
                    break;
                }
            }
            if (statModifier != null)
            {
                statModifier.value = settings;
            }
        }
    
    }
}
