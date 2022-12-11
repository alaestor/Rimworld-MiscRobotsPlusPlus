using HarmonyLib;
using MiscRobotsPlusPlus.Patches;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using UnityEngine;
using UnityEngine.Rendering;
using Verse;

namespace MiscRobotsPlusPlus
{
    [StaticConstructorOnStartup]
    public class MiscRobotsPlusPlus : Mod
    {
        static MiscRobotsPlusPlus()
        {
            var har = new Harmony("MiscRobotsPlusPlus");
            har.PatchAll(Assembly.GetExecutingAssembly());

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

        #region Writing Settings
        public override void WriteSettings()
        {
            base.WriteSettings();


#if true
            //Cleaners
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_1_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_1_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_1_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_1_CleanerMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_2_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_2_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_2_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_2_CleanerMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_3_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_3_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_3_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_3_CleanerMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_4_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_4_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_4_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_4_CleanerMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_5_Def, StatDefOf.CleaningSpeed, MiscModsSettings.tier_5_CleaningSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Cleaner_5_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_5_CleanerMarket);

            //Builders
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_1_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_1_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_1_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_1_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_1_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_1_Builder_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_1_Def, StatDefOf.MarketValue, MiscModsSettings.tier_1_Builder_MarketValue);

            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_2_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_2_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_2_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_2_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_2_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_2_Builder_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_2_Def, StatDefOf.MarketValue, MiscModsSettings.tier_2_Builder_MarketValue);

            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_3_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_3_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_3_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_3_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_3_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_3_Builder_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_3_Def, StatDefOf.MarketValue, MiscModsSettings.tier_3_Builder_MarketValue);

            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_4_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_4_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_4_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_4_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_4_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_4_Builder_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_4_Def, StatDefOf.MarketValue, MiscModsSettings.tier_4_Builder_MarketValue);

            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_5_Def, StatDefOf.ConstructionSpeed, MiscModsSettings.tier_5_Builder_ConstructionSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_5_Def, StatDefOf.DeepDrillingSpeed, MiscModsSettings.tier_5_Builder_DeepDrillingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_Builder_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_5_Def, StatDefOf.SmoothingSpeed, MiscModsSettings.tier_5_Builder_SmoothingSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Builder_5_Def, StatDefOf.MarketValue, MiscModsSettings.tier_5_Builder_MarketValue);

            //Crafter
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_CrafterLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_1_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_1_CrafterMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_CrafterLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_2_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_2_CrafterMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_CrafterLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_3_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_3_CrafterMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_CrafterLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_4_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_4_CrafterMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_CrafterLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Crafter_5_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_5_CrafterMarket);
            //ER
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_ERTendingLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_1_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_1_ERMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.ER_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_ERTendingLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_2_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_2_ERMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.ER_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_ERTendingLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_3_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_3_ERMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.ER_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_ERTendingLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_4_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_4_ERMarket);

            SaveSettingForStatModifer(ThingDefRobotsOf.ER_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_ERTendingLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.ER_5_Def, StatDefOf.MarketValue, MiscModsSettings.Tier_5_ERMarket);
            //Kitchen
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_1_Def, StatDefOf.MarketValue, MiscModsSettings.tier_1_Kitcen_MarketValue);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_Kitchen_GeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_1_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_1_KitchenPlantHarvestYield);

            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_2_Def, StatDefOf.MarketValue, MiscModsSettings.tier_2_Kitcen_MarketValue);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenGeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_2_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_2_KitchenPlantHarvestYield);

            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_3_Def, StatDefOf.MarketValue, MiscModsSettings.tier_3_Kitcen_MarketValue);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenGeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_3_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_3_KitchenPlantHarvestYield);

            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_4_Def, StatDefOf.MarketValue, MiscModsSettings.tier_4_Kitcen_MarketValue);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenGeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_4_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_4_KitchenPlantHarvestYield);

            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_5_Def, StatDefOf.MarketValue, MiscModsSettings.tier_5_Kitcen_MarketValue);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenGeneralLaborSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenPlantHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenPlantWorkSpeed);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenDrugHarvestYield);
            SaveSettingForStatModifer(ThingDefRobotsOf.Kitchen_5_Def, StatDefOf.GeneralLaborSpeed, MiscModsSettings.tier_5_KitchenPlantHarvestYield);

            //Omni
            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_1_Def, StatDefOf.MarketValue, MiscModsSettings.tier_1_Omni_MarketValue);
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

            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_2_Def, StatDefOf.MarketValue, MiscModsSettings.tier_2_Omni_MarketValue);
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

            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_3_Def, StatDefOf.MarketValue, MiscModsSettings.tier_3_Omni_MarketValue);
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

            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_4_Def, StatDefOf.MarketValue, MiscModsSettings.tier_4_Omni_MarketValue);
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

            SaveSettingForStatModifer(ThingDefRobotsOf.Omni_5_Def, StatDefOf.MarketValue, MiscModsSettings.tier_5_Omni_MarketValue);
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
#endif
        }
        #endregion

        public override string SettingsCategory()
        {
            return "MISC_Robots_Category".Translate();
        }
        private bool eRSettings = false;
        private bool cleanerSettings = false;
        private bool craftersSettings = false;
        private bool kitchenSettings = false;
        private bool builderSettings = false;
        private bool omniSettings = false;
        //Cleaning Settings Dev Only Mode
        private bool DevOnly = false;


        #region  Int Buffers
        string CleanMarket_1_buffer = "1000";
        string CleanMarket_2_buffer = "5000";
        string CleanMarket_3_buffer = "15000";
        string CleanMarket_4_buffer = "35000";
        string CleanMarket_5_buffer = "50000";

        string BuilderMarket_1_buffer = "1000";
        string BuilderMarket_2_buffer = "5000";
        string BuilderMarket_3_buffer = "15000";
        string BuilderMarket_4_buffer = "35000";
        string BuilderMarket_5_buffer = "50000";

        string CrafterMarket_1_buffer = "1000";
        string CrafterMarket_2_buffer = "5000";
        string CrafterMarket_3_buffer = "15000";
        string CrafterMarket_4_buffer = "35000";
        string CrafterMarket_5_buffer = "50000";

        string ERMarket_1_buffer = "1000";
        string ERMarket_2_buffer = "5000";
        string ERMarket_3_buffer = "15000";
        string ERMarket_4_buffer = "35000";
        string ERMarket_5_buffer = "50000";


        string KitchenMarket_1_buffer = "1000";
        string KitchenMarket_2_buffer = "5000";
        string KitchenMarket_3_buffer = "15000";
        string KitchenMarket_4_buffer = "35000";
        string KitchenMarket_5_buffer = "50000";

        string OmniMarket_1_buffer = "4000";
        string OmniMarket_2_buffer = "8000";
        string OmniMarket_3_buffer = "24000";
        string OmniMarket_4_buffer = "36000";
        string OmniMarket_5_buffer = "92000";
#endregion
        Vector2 scrollPos;
        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            Listing_Standard guiStandard = new Listing_Standard();
            guiStandard.Begin(inRect);
            {
                guiStandard.Label("MISC_WIP".Translate());
                guiStandard.GapLine();
                float remainingHeight = inRect.height - guiStandard.CurHeight;
                Rect outRect = guiStandard.GetRect(remainingHeight);
                Rect viewRect = new Rect(outRect)
                {
                    width = outRect.width - 16,
                    height = remainingHeight * 12
                };
             
                Widgets.BeginScrollView(outRect, ref scrollPos, viewRect);
                {

                    guiStandard.Begin(viewRect);
                    {
                        if (DevOnly)
                        {
                            DrawingSettings(guiStandard, MiscModsSettings.buildersData, 1f, 999f);
                        }
#if true
                        guiStandard.CheckboxLabeled("MISC_Cleaning_Settings".Translate(), ref cleanerSettings);
                        if (cleanerSettings)
                        {
                           
                            guiStandard.Label("MISC_CleaningTeir_I_MarketValue".Translate(MiscModsSettings.Tier_1_CleanerMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_1_CleanerMarket, ref CleanMarket_1_buffer);

                            guiStandard.Label("MISC_CleaningTeir_I_Speed".Translate(MiscModsSettings.tier_1_CleaningSpeed * 100));
                            MiscModsSettings.tier_1_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_1_CleaningSpeed, 0.1f, 15f);
                            guiStandard.Gap();

                            guiStandard.Label("MISC_CleaningTeir_II_MarketValue".Translate(MiscModsSettings.Tier_2_CleanerMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_2_CleanerMarket, ref CleanMarket_2_buffer);

                            guiStandard.Label("MISC_CleaningTeir_II_Speed".Translate(MiscModsSettings.tier_2_CleaningSpeed * 100));
                            MiscModsSettings.tier_2_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_2_CleaningSpeed, 0.1f, 15f);
                            guiStandard.Gap();

                            guiStandard.Label("MISC_CleaningTeir_III_MarketValue".Translate(MiscModsSettings.Tier_3_CleanerMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_3_CleanerMarket, ref CleanMarket_3_buffer);

                            guiStandard.Label("MISC_CleaningTeir_III_Speed".Translate(MiscModsSettings.tier_3_CleaningSpeed * 100));
                            MiscModsSettings.tier_3_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_3_CleaningSpeed, 0.1f, 15f);
                            guiStandard.Gap();

                            guiStandard.Label("MISC_CleaningTeir_IV_MarketValue".Translate(MiscModsSettings.Tier_4_CleanerMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_4_CleanerMarket, ref CleanMarket_4_buffer);

                            guiStandard.Label("MISC_CleaningTeir_IV_Speed".Translate(MiscModsSettings.tier_4_CleaningSpeed * 100));
                            MiscModsSettings.tier_4_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_4_CleaningSpeed, 0.1f, 15f);

                            guiStandard.Gap(); 
                            guiStandard.Label("MISC_CleaningTeir_V_MarketValue".Translate(MiscModsSettings.Tier_5_CleanerMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_5_CleanerMarket, ref CleanMarket_5_buffer);

                            guiStandard.Label("MISC_CleaningTeir_V_Speed".Translate(MiscModsSettings.tier_5_CleaningSpeed * 100));
                            MiscModsSettings.tier_5_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_5_CleaningSpeed, 0.1f, 15f);
                        }
                        guiStandard.GapLine(24);

                        guiStandard.CheckboxLabeled("MISC_Crafters_Settings".Translate(), ref craftersSettings);
                        if (craftersSettings)
                        {
                            guiStandard.Gap();
                            guiStandard.Label("MISC_Crafter_I_MarketValue".Translate(MiscModsSettings.Tier_1_CrafterMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_1_CrafterMarket, ref CrafterMarket_1_buffer);
                            guiStandard.Label("MISC_CrafterLaborTeir_I_Speed".Translate(MiscModsSettings.tier_1_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_1_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_1_CrafterLaborSpeed, 0.1f, 15f);
                            guiStandard.Gap();
                            guiStandard.Label("MISC_Crafter_II_MarketValue".Translate(MiscModsSettings.Tier_2_CrafterMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_2_CrafterMarket, ref CrafterMarket_2_buffer);

                            guiStandard.Label("MISC_CrafterLaborTeir_II_Speed".Translate(MiscModsSettings.tier_2_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_2_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_2_CrafterLaborSpeed, 0.1f, 15);
                            guiStandard.Gap();
                            guiStandard.Label("MISC_Crafter_III_MarketValue".Translate(MiscModsSettings.Tier_3_CrafterMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_3_CrafterMarket, ref CrafterMarket_3_buffer);
                            guiStandard.Label("MISC_CrafterLaborTeir_III_Speed".Translate(MiscModsSettings.tier_3_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_3_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_3_CrafterLaborSpeed, 0.1f, 15f);
                            guiStandard.Gap();
                            guiStandard.Label("MISC_Crafter_IV_MarketValue".Translate(MiscModsSettings.Tier_4_CrafterMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_4_CrafterMarket, ref CrafterMarket_4_buffer);
                            guiStandard.Label("MISC_CrafterLaborTeir_IV_Speed".Translate(MiscModsSettings.tier_4_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_4_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_4_CrafterLaborSpeed, 0.1f, 15f);
                            guiStandard.Gap();
                            guiStandard.Label("MISC_Crafter_V_MarketValue".Translate(MiscModsSettings.Tier_5_CrafterMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_5_CrafterMarket, ref CrafterMarket_5_buffer);
                            guiStandard.Label("MISC_CrafterLaborTeir_V_Speed".Translate(MiscModsSettings.tier_5_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_5_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_5_CrafterLaborSpeed, 0.1f, 15f);
                            guiStandard.Gap();
                        }
                        guiStandard.GapLine(24);

                        guiStandard.CheckboxLabeled("MISC_ER_Settings".Translate(), ref eRSettings);
                        if (eRSettings)
                        {
                            guiStandard.Label("MISC_ER_I_MarketValue".Translate(MiscModsSettings.Tier_1_ERMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_1_ERMarket, ref ERMarket_1_buffer);
                            guiStandard.Label("MISC_ER_TendSpeed_I".Translate(MiscModsSettings.tier_1_ERTendingLaborSpeed * 100));
                            MiscModsSettings.tier_1_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_1_ERTendingLaborSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_ER_SurgerySucces_I".Translate(MiscModsSettings.tier_2_ERMedicalSurgerySuccessChance * 100));
                            MiscModsSettings.tier_1_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_1_ERMedicalSurgerySuccessChance, 0.1f, 15f);

                            guiStandard.Gap();
                            guiStandard.Label("MISC_ER_II_MarketValue".Translate(MiscModsSettings.Tier_2_ERMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_2_ERMarket, ref ERMarket_2_buffer);
                            guiStandard.Label("MISC_ER_TendSpeed_II".Translate(MiscModsSettings.tier_2_ERTendingLaborSpeed * 100));
                            MiscModsSettings.tier_2_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_2_ERTendingLaborSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_ER_SurgerySucces_II".Translate(MiscModsSettings.tier_2_ERMedicalSurgerySuccessChance * 100));
                            MiscModsSettings.tier_2_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_2_ERMedicalSurgerySuccessChance, 0.1f, 15f);

                            guiStandard.Gap();
                            guiStandard.Label("MISC_ER_III_MarketValue".Translate(MiscModsSettings.Tier_3_ERMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_3_ERMarket, ref ERMarket_3_buffer);
                            guiStandard.Label("MISC_ER_TendSpeed_III".Translate(MiscModsSettings.tier_3_ERTendingLaborSpeed * 100));
                            MiscModsSettings.tier_3_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_3_ERTendingLaborSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_ER_SurgerySucces_III".Translate(MiscModsSettings.tier_3_ERMedicalSurgerySuccessChance * 100));
                            MiscModsSettings.tier_3_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_3_ERMedicalSurgerySuccessChance, 0.1f, 15f);

                            guiStandard.Gap();
                            guiStandard.Label("MISC_ER_IV_MarketValue".Translate(MiscModsSettings.Tier_4_ERMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_4_ERMarket, ref ERMarket_4_buffer);
                            guiStandard.Label("MISC_ER_TendSpeed_IV".Translate(MiscModsSettings.tier_4_ERTendingLaborSpeed * 100));
                            MiscModsSettings.tier_4_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_4_ERTendingLaborSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_ER_SurgerySucces_IV".Translate(MiscModsSettings.tier_4_ERMedicalSurgerySuccessChance * 100));
                            MiscModsSettings.tier_4_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_4_ERMedicalSurgerySuccessChance, 0.1f, 15f);

                            guiStandard.Gap();
                            guiStandard.Label("MISC_ER_V_MarketValue".Translate(MiscModsSettings.Tier_5_ERMarket));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.Tier_5_ERMarket, ref ERMarket_5_buffer);
                            guiStandard.Label("MISC_ER_TendSpeed_V".Translate(MiscModsSettings.tier_5_ERTendingLaborSpeed * 100));
                            MiscModsSettings.tier_5_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_5_ERTendingLaborSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_ER_SurgerySucces_V".Translate(MiscModsSettings.tier_5_ERMedicalSurgerySuccessChance * 100));
                            MiscModsSettings.tier_5_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_5_ERMedicalSurgerySuccessChance, 0.1f, 15f);

                        }
                        guiStandard.GapLine(24);

                        guiStandard.CheckboxLabeled("MISC_Kitchen_Settings".Translate(), ref kitchenSettings);
                        if (kitchenSettings)
                        {
                            guiStandard.Label("MISC_Kitchen_I_MarketValue".Translate(MiscModsSettings.tier_1_Kitcen_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_1_Kitcen_MarketValue, ref KitchenMarket_1_buffer);

                            guiStandard.Label("MISC_Kitchen_GeneralLabor_I".Translate(MiscModsSettings.tier_1_Kitchen_GeneralLaborSpeed * 100));
                            MiscModsSettings.tier_1_Kitchen_GeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Kitchen_GeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_I".Translate(MiscModsSettings.tier_1_KitchenPlantWorkSpeed * 100));
                            MiscModsSettings.tier_1_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_1_KitchenPlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantHarvestYield_I".Translate(MiscModsSettings.tier_1_KitchenPlantHarvestYield * 100));
                            MiscModsSettings.tier_1_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_KitchenPlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_DrugHarvestYield_I".Translate(MiscModsSettings.tier_1_KitchenDrugHarvestYield * 100));
                            MiscModsSettings.tier_1_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_KitchenDrugHarvestYield, 0.1f, 15f);

                            guiStandard.GapLine();

                            guiStandard.Label("MISC_Kitchen_II_MarketValue".Translate(MiscModsSettings.tier_2_Kitcen_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_2_Kitcen_MarketValue, ref KitchenMarket_2_buffer);

                            guiStandard.Label("MISC_Kitchen_GeneralLabor_II".Translate(MiscModsSettings.tier_2_KitchenGeneralLaborSpeed * 100));
                            MiscModsSettings.tier_2_KitchenGeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_2_KitchenGeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_II".Translate(MiscModsSettings.tier_2_KitchenPlantWorkSpeed * 100));
                            MiscModsSettings.tier_2_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_2_KitchenPlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantHarvestYield_II".Translate(MiscModsSettings.tier_2_KitchenPlantHarvestYield * 100));
                            MiscModsSettings.tier_2_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_2_KitchenPlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_DrugHarvestYield_II".Translate(MiscModsSettings.tier_2_KitchenDrugHarvestYield * 100));
                            MiscModsSettings.tier_2_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_2_KitchenDrugHarvestYield, 0.1f, 15f);

                            guiStandard.GapLine();

                            guiStandard.Label("MISC_Kitchen_III_MarketValue".Translate(MiscModsSettings.tier_3_Kitcen_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_3_Kitcen_MarketValue, ref KitchenMarket_3_buffer);

                            guiStandard.Label("MISC_Kitchen_GeneralLabor_III".Translate(MiscModsSettings.tier_3_KitchenGeneralLaborSpeed * 100));
                            MiscModsSettings.tier_3_KitchenGeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_3_KitchenGeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_III".Translate(MiscModsSettings.tier_3_KitchenPlantWorkSpeed * 100));
                            MiscModsSettings.tier_3_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_3_KitchenPlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantHarvestYield_III".Translate(MiscModsSettings.tier_3_KitchenPlantHarvestYield * 100));
                            MiscModsSettings.tier_3_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_3_KitchenPlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_DrugHarvestYield_III".Translate(MiscModsSettings.tier_3_KitchenDrugHarvestYield * 100));
                            MiscModsSettings.tier_3_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_3_KitchenDrugHarvestYield, 0.1f, 15f);

                            guiStandard.GapLine();

                            guiStandard.Label("MISC_Kitchen_IV_MarketValue".Translate(MiscModsSettings.tier_4_Kitcen_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_4_Kitcen_MarketValue, ref KitchenMarket_4_buffer);

                            guiStandard.Label("MISC_Kitchen_GeneralLabor_IV".Translate(MiscModsSettings.tier_4_KitchenGeneralLaborSpeed * 100));
                            MiscModsSettings.tier_4_KitchenGeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_4_KitchenGeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_IV".Translate(MiscModsSettings.tier_4_KitchenPlantWorkSpeed * 100));
                            MiscModsSettings.tier_4_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_4_KitchenPlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantHarvestYield_IV".Translate(MiscModsSettings.tier_4_KitchenPlantHarvestYield * 100));
                            MiscModsSettings.tier_4_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_4_KitchenPlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_DrugHarvestYield_IV".Translate(MiscModsSettings.tier_4_KitchenDrugHarvestYield * 100));
                            MiscModsSettings.tier_4_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_4_KitchenDrugHarvestYield, 0.1f, 15f);

                            guiStandard.GapLine();

                            guiStandard.Label("MISC_Kitchen_V_MarketValue".Translate(MiscModsSettings.tier_5_Kitcen_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_5_Kitcen_MarketValue, ref KitchenMarket_5_buffer);

                            guiStandard.Label("MISC_Kitchen_GeneralLabor_V".Translate(MiscModsSettings.tier_5_KitchenGeneralLaborSpeed * 100));
                            MiscModsSettings.tier_5_KitchenGeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_5_KitchenGeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_V".Translate(MiscModsSettings.tier_5_KitchenPlantWorkSpeed * 100));
                            MiscModsSettings.tier_5_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_5_KitchenPlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_PlantHarvestYield_V".Translate(MiscModsSettings.tier_5_KitchenPlantHarvestYield * 100));
                            MiscModsSettings.tier_5_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_5_KitchenPlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_Kitchen_DrugHarvestYield_V".Translate(MiscModsSettings.tier_5_KitchenDrugHarvestYield * 100));
                            MiscModsSettings.tier_2_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_2_KitchenDrugHarvestYield, 0.1f, 15f);
                        }
                        guiStandard.GapLine(24);

                        guiStandard.CheckboxLabeled("MISC_Builder_Settings".Translate(), ref builderSettings);
                        if (builderSettings)
                        {

                            guiStandard.Label("MISC_Builder_I_MarketValue".Translate(MiscModsSettings.tier_1_Builder_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_1_Builder_MarketValue, ref BuilderMarket_1_buffer);
                            guiStandard.Label("MISC_BuilderTeir_I_ConstructionSpeed".Translate(MiscModsSettings.tier_1_Builder_ConstructionSpeed * 100));
                            MiscModsSettings.tier_1_Builder_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Builder_ConstructionSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_I_DeepDrillingSpeed".Translate(MiscModsSettings.tier_1_Builder_DeepDrillingSpeed * 100));
                            MiscModsSettings.tier_1_Builder_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Builder_DeepDrillingSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_I_MiningYield".Translate(MiscModsSettings.tier_1_Builder_MiningYield * 100));
                            MiscModsSettings.tier_1_Builder_MiningYield = guiStandard.Slider(MiscModsSettings.tier_1_Builder_MiningYield, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_I_SmoothingSpeed".Translate(MiscModsSettings.tier_1_Builder_SmoothingSpeed * 100));
                            MiscModsSettings.tier_1_Builder_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Builder_SmoothingSpeed, 0.1f, 15f);
                            guiStandard.Gap();

                            guiStandard.Label("MISC_Builder_II_MarketValue".Translate(MiscModsSettings.tier_2_Builder_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_2_Builder_MarketValue, ref BuilderMarket_2_buffer);
                            guiStandard.Label("MISC_BuilderTeir_II_ConstructionSpeed".Translate(MiscModsSettings.tier_2_Builder_ConstructionSpeed * 100));
                            MiscModsSettings.tier_2_Builder_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_2_Builder_ConstructionSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_II_DeepDrillingSpeed".Translate(MiscModsSettings.tier_2_Builder_DeepDrillingSpeed * 100));
                            MiscModsSettings.tier_2_Builder_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_2_Builder_DeepDrillingSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_II_MiningYield".Translate(MiscModsSettings.tier_2_Builder_MiningYield * 100));
                            MiscModsSettings.tier_2_Builder_MiningYield = guiStandard.Slider(MiscModsSettings.tier_2_Builder_MiningYield, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_II_SmoothingSpeed".Translate(MiscModsSettings.tier_2_Builder_SmoothingSpeed * 100));
                            MiscModsSettings.tier_2_Builder_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_2_Builder_SmoothingSpeed, 0.1f, 15f);
                            guiStandard.Gap();
                            guiStandard.Label("MISC_Builder_III_MarketValue".Translate(MiscModsSettings.tier_3_Builder_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_3_Builder_MarketValue, ref BuilderMarket_3_buffer);
                            guiStandard.Label("MISC_BuilderTeir_III_ConstructionSpeed".Translate(MiscModsSettings.tier_3_Builder_ConstructionSpeed * 100));
                            MiscModsSettings.tier_3_Builder_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_3_Builder_ConstructionSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_III_DeepDrillingSpeed".Translate(MiscModsSettings.tier_3_Builder_DeepDrillingSpeed * 100));
                            MiscModsSettings.tier_3_Builder_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_3_Builder_DeepDrillingSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_III_MiningYield".Translate(MiscModsSettings.tier_3_Builder_MiningYield * 100));
                            MiscModsSettings.tier_3_Builder_MiningYield = guiStandard.Slider(MiscModsSettings.tier_3_Builder_MiningYield, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_III_SmoothingSpeed".Translate(MiscModsSettings.tier_3_Builder_SmoothingSpeed * 100));
                            MiscModsSettings.tier_3_Builder_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_3_Builder_SmoothingSpeed, 0.1f, 15f);
                            guiStandard.Gap();
                            guiStandard.Label("MISC_Builder_IV_MarketValue".Translate(MiscModsSettings.tier_4_Builder_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_4_Builder_MarketValue, ref BuilderMarket_4_buffer);
                            guiStandard.Label("MISC_BuilderTeir_IV_ConstructionSpeed".Translate(MiscModsSettings.tier_4_Builder_ConstructionSpeed * 100));
                            MiscModsSettings.tier_4_Builder_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_4_Builder_ConstructionSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_IV_DeepDrillingSpeed".Translate(MiscModsSettings.tier_4_Builder_DeepDrillingSpeed * 100));
                            MiscModsSettings.tier_4_Builder_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_4_Builder_DeepDrillingSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_IV_MiningYield".Translate(MiscModsSettings.tier_4_Builder_MiningYield * 100));
                            MiscModsSettings.tier_4_Builder_MiningYield = guiStandard.Slider(MiscModsSettings.tier_4_Builder_MiningYield, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_IV_SmoothingSpeed".Translate(MiscModsSettings.tier_4_Builder_SmoothingSpeed * 100));
                            MiscModsSettings.tier_4_Builder_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_4_Builder_SmoothingSpeed, 0.1f, 15f);
                            guiStandard.Gap();

                            guiStandard.Label("MISC_Builder_V_MarketValue".Translate(MiscModsSettings.tier_5_Builder_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_5_Builder_MarketValue, ref BuilderMarket_5_buffer);
                            guiStandard.Label("MISC_BuilderTeir_V_ConstructionSpeed".Translate(MiscModsSettings.tier_5_Builder_ConstructionSpeed * 100));
                            MiscModsSettings.tier_5_Builder_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_5_Builder_ConstructionSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_V_DeepDrillingSpeed".Translate(MiscModsSettings.tier_5_Builder_DeepDrillingSpeed * 100));
                            MiscModsSettings.tier_5_Builder_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_5_Builder_DeepDrillingSpeed, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_V_MiningYield".Translate(MiscModsSettings.tier_5_Builder_MiningYield * 100));
                            MiscModsSettings.tier_5_Builder_MiningYield = guiStandard.Slider(MiscModsSettings.tier_5_Builder_MiningYield, 0.1f, 15f);
                            guiStandard.Label("MISC_BuilderTeir_V_SmoothingSpeed".Translate(MiscModsSettings.tier_5_Builder_SmoothingSpeed * 100));
                            MiscModsSettings.tier_5_Builder_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_5_Builder_SmoothingSpeed, 0.1f, 15f);
                        }
                        guiStandard.GapLine(24);

                        guiStandard.CheckboxLabeled("MISC_Omni_Settings".Translate(), ref omniSettings);
                        if (omniSettings)
                        {

                            guiStandard.Label("MISC_Omni_I_MarketValue".Translate(MiscModsSettings.tier_1_Omni_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_1_Omni_MarketValue, ref OmniMarket_1_buffer); 

                            guiStandard.Label("MISC_OmniTeir_I_WorkTableSpeed".Translate(), MiscModsSettings.tier_1_Omni_WorkTableWorkSpeedFactor * 100);
                            MiscModsSettings.tier_1_Omni_WorkTableWorkSpeedFactor = guiStandard.Slider(MiscModsSettings.tier_1_Omni_WorkTableWorkSpeedFactor, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_GeneralLaborSpeed".Translate(), MiscModsSettings.tier_1_Omni_GeneralLaborSpeed * 100);
                            MiscModsSettings.tier_1_Omni_GeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Omni_GeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_CleaningSpeed".Translate(), MiscModsSettings.tier_1_Omni_CleaningSpeed * 100);
                            MiscModsSettings.tier_1_Omni_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Omni_CleaningSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_ConstructionSpeed".Translate(), MiscModsSettings.tier_1_Omni_ConstructionSpeed * 100);
                            MiscModsSettings.tier_1_Omni_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Omni_ConstructionSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_DeepDrillSpeed".Translate(), MiscModsSettings.tier_1_Omni_DeepDrillingSpeed * 100);
                            MiscModsSettings.tier_1_Omni_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Omni_DeepDrillingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_SmothingSpeed".Translate(), MiscModsSettings.tier_1_Omni_SmoothingSpeed * 100);
                            MiscModsSettings.tier_1_Omni_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Omni_SmoothingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_PlantWorkSpeed".Translate(), MiscModsSettings.tier_1_Omni_PlantWorkSpeed * 100);
                            MiscModsSettings.tier_1_Omni_PlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_1_Omni_PlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_MiningYield".Translate(), MiscModsSettings.tier_1_Omni_MiningYield * 100);
                            MiscModsSettings.tier_1_Omni_MiningYield = guiStandard.Slider(MiscModsSettings.tier_1_Omni_MiningYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_PlantHarvestYield".Translate(), MiscModsSettings.tier_1_Omni_PlantHarvestYield * 100);
                            MiscModsSettings.tier_1_Omni_PlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_Omni_PlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_DrungHarvestSpeed".Translate(), MiscModsSettings.tier_1_Omni_DrugHarvestYield * 100);
                            MiscModsSettings.tier_1_Omni_DrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_Omni_DrugHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_ConstructChance".Translate(), MiscModsSettings.tier_1_Omni_ConstructSuccessChance * 100);
                            MiscModsSettings.tier_1_Omni_ConstructSuccessChance = guiStandard.Slider(MiscModsSettings.tier_1_Omni_ConstructSuccessChance, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_I_SurgeryChance".Translate(), MiscModsSettings.tier_1_Omni_MedicalSurgerySuccessChance * 100);
                            MiscModsSettings.tier_1_Omni_MedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_1_Omni_MedicalSurgerySuccessChance, 0.1f, 15f);

                            guiStandard.Gap();
                            guiStandard.Label("MISC_Omni_II_MarketValue".Translate(MiscModsSettings.tier_2_Omni_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_2_Omni_MarketValue, ref OmniMarket_2_buffer);

                            guiStandard.Label("MISC_OmniTeir_II_WorkTableSpeed".Translate(), MiscModsSettings.tier_2_Omni_WorkTableWorkSpeedFactor * 100);
                            MiscModsSettings.tier_2_Omni_WorkTableWorkSpeedFactor = guiStandard.Slider(MiscModsSettings.tier_2_Omni_WorkTableWorkSpeedFactor, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_GeneralLaborSpeed".Translate(), MiscModsSettings.tier_2_Omni_GeneralLaborSpeed * 100);
                            MiscModsSettings.tier_2_Omni_GeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_2_Omni_GeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_CleaningSpeed".Translate(), MiscModsSettings.tier_2_Omni_CleaningSpeed * 100);
                            MiscModsSettings.tier_2_Omni_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_2_Omni_CleaningSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_ConstructionSpeed".Translate(), MiscModsSettings.tier_2_Omni_ConstructionSpeed * 100);
                            MiscModsSettings.tier_2_Omni_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_2_Omni_ConstructionSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_DeepDrillSpeed".Translate(), MiscModsSettings.tier_2_Omni_DeepDrillingSpeed * 100);
                            MiscModsSettings.tier_2_Omni_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_2_Omni_DeepDrillingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_SmothingSpeed".Translate(), MiscModsSettings.tier_2_Omni_SmoothingSpeed * 100);
                            MiscModsSettings.tier_2_Omni_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_2_Omni_SmoothingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_PlantWorkSpeed".Translate(), MiscModsSettings.tier_2_Omni_PlantWorkSpeed * 100);
                            MiscModsSettings.tier_2_Omni_PlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_2_Omni_PlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_MiningYield".Translate(), MiscModsSettings.tier_2_Omni_MiningYield * 100);
                            MiscModsSettings.tier_2_Omni_MiningYield = guiStandard.Slider(MiscModsSettings.tier_2_Omni_MiningYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_PlantHarvestYield".Translate(), MiscModsSettings.tier_2_Omni_PlantHarvestYield * 100);
                            MiscModsSettings.tier_2_Omni_PlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_2_Omni_PlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_DrungHarvestSpeed".Translate(), MiscModsSettings.tier_2_Omni_DrugHarvestYield * 100);
                            MiscModsSettings.tier_2_Omni_DrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_2_Omni_DrugHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_ConstructChance".Translate(), MiscModsSettings.tier_2_Omni_ConstructSuccessChance * 100);
                            MiscModsSettings.tier_2_Omni_ConstructSuccessChance = guiStandard.Slider(MiscModsSettings.tier_2_Omni_ConstructSuccessChance, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_II_SurgeryChance".Translate(), MiscModsSettings.tier_2_Omni_MedicalSurgerySuccessChance * 100);
                            MiscModsSettings.tier_2_Omni_MedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_2_Omni_MedicalSurgerySuccessChance, 0.1f, 15f);

                            guiStandard.Gap();

                            guiStandard.Label("MISC_Omni_III_MarketValue".Translate(MiscModsSettings.tier_3_Omni_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_3_Omni_MarketValue, ref OmniMarket_3_buffer);

                            guiStandard.Label("MISC_OmniTeir_III_WorkTableSpeed".Translate(), MiscModsSettings.tier_3_Omni_WorkTableWorkSpeedFactor * 100);
                            MiscModsSettings.tier_3_Omni_WorkTableWorkSpeedFactor = guiStandard.Slider(MiscModsSettings.tier_3_Omni_WorkTableWorkSpeedFactor, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_GeneralLaborSpeed".Translate(), MiscModsSettings.tier_3_Omni_GeneralLaborSpeed * 100);
                            MiscModsSettings.tier_3_Omni_GeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_3_Omni_GeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_CleaningSpeed".Translate(), MiscModsSettings.tier_3_Omni_CleaningSpeed * 100);
                            MiscModsSettings.tier_3_Omni_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_3_Omni_CleaningSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_ConstructionSpeed".Translate(), MiscModsSettings.tier_3_Omni_ConstructionSpeed * 100);
                            MiscModsSettings.tier_3_Omni_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_3_Omni_ConstructionSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_DeepDrillSpeed".Translate(), MiscModsSettings.tier_3_Omni_DeepDrillingSpeed * 100);
                            MiscModsSettings.tier_3_Omni_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_3_Omni_DeepDrillingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_SmothingSpeed".Translate(), MiscModsSettings.tier_3_Omni_SmoothingSpeed * 100);
                            MiscModsSettings.tier_3_Omni_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_3_Omni_SmoothingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_PlantWorkSpeed".Translate(), MiscModsSettings.tier_3_Omni_PlantWorkSpeed * 100);
                            MiscModsSettings.tier_3_Omni_PlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_3_Omni_PlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_MiningYield".Translate(), MiscModsSettings.tier_3_Omni_MiningYield * 100);
                            MiscModsSettings.tier_3_Omni_MiningYield = guiStandard.Slider(MiscModsSettings.tier_3_Omni_MiningYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_PlantHarvestYield".Translate(), MiscModsSettings.tier_3_Omni_PlantHarvestYield * 100);
                            MiscModsSettings.tier_3_Omni_PlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_3_Omni_PlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_DrungHarvestSpeed".Translate(), MiscModsSettings.tier_3_Omni_DrugHarvestYield * 100);
                            MiscModsSettings.tier_3_Omni_DrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_3_Omni_DrugHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_ConstructChance".Translate(), MiscModsSettings.tier_3_Omni_ConstructSuccessChance * 100);
                            MiscModsSettings.tier_3_Omni_ConstructSuccessChance = guiStandard.Slider(MiscModsSettings.tier_3_Omni_ConstructSuccessChance, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_III_SurgeryChance".Translate(), MiscModsSettings.tier_3_Omni_MedicalSurgerySuccessChance * 100);
                            MiscModsSettings.tier_3_Omni_MedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_3_Omni_MedicalSurgerySuccessChance, 0.1f, 15f);

                            guiStandard.Gap();


                            guiStandard.Label("MISC_Omni_IV_MarketValue".Translate(MiscModsSettings.tier_4_Omni_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_4_Omni_MarketValue, ref OmniMarket_4_buffer);

                            guiStandard.Label("MISC_OmniTeir_IV_WorkTableSpeed".Translate(), MiscModsSettings.tier_4_Omni_WorkTableWorkSpeedFactor * 100);
                            MiscModsSettings.tier_4_Omni_WorkTableWorkSpeedFactor = guiStandard.Slider(MiscModsSettings.tier_4_Omni_WorkTableWorkSpeedFactor, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_GeneralLaborSpeed".Translate(), MiscModsSettings.tier_4_Omni_GeneralLaborSpeed * 100);
                            MiscModsSettings.tier_4_Omni_GeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_4_Omni_GeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_CleaningSpeed".Translate(), MiscModsSettings.tier_4_Omni_CleaningSpeed * 100);
                            MiscModsSettings.tier_4_Omni_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_4_Omni_CleaningSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_ConstructionSpeed".Translate(), MiscModsSettings.tier_4_Omni_ConstructionSpeed * 100);
                            MiscModsSettings.tier_4_Omni_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_4_Omni_ConstructionSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_DeepDrillSpeed".Translate(), MiscModsSettings.tier_4_Omni_DeepDrillingSpeed * 100);
                            MiscModsSettings.tier_4_Omni_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_4_Omni_DeepDrillingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_SmothingSpeed".Translate(), MiscModsSettings.tier_4_Omni_SmoothingSpeed * 100);
                            MiscModsSettings.tier_4_Omni_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_4_Omni_SmoothingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_PlantWorkSpeed".Translate(), MiscModsSettings.tier_4_Omni_PlantWorkSpeed * 100);
                            MiscModsSettings.tier_4_Omni_PlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_4_Omni_PlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_MiningYield".Translate(), MiscModsSettings.tier_4_Omni_MiningYield * 100);
                            MiscModsSettings.tier_4_Omni_MiningYield = guiStandard.Slider(MiscModsSettings.tier_4_Omni_MiningYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_PlantHarvestYield".Translate(), MiscModsSettings.tier_4_Omni_PlantHarvestYield * 100);
                            MiscModsSettings.tier_4_Omni_PlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_4_Omni_PlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_DrungHarvestSpeed".Translate(), MiscModsSettings.tier_4_Omni_DrugHarvestYield * 100);
                            MiscModsSettings.tier_4_Omni_DrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_4_Omni_DrugHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_ConstructChance".Translate(), MiscModsSettings.tier_4_Omni_ConstructSuccessChance * 100);
                            MiscModsSettings.tier_4_Omni_ConstructSuccessChance = guiStandard.Slider(MiscModsSettings.tier_4_Omni_ConstructSuccessChance, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_IV_SurgeryChance".Translate(), MiscModsSettings.tier_4_Omni_MedicalSurgerySuccessChance * 100);
                            MiscModsSettings.tier_4_Omni_MedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_4_Omni_MedicalSurgerySuccessChance, 0.1f, 15f);
                            guiStandard.Gap();


                            guiStandard.Label("MISC_Omni_V_MarketValue".Translate(MiscModsSettings.tier_5_Omni_MarketValue));
                            guiStandard.TextFieldNumeric<int>(ref MiscModsSettings.tier_5_Omni_MarketValue, ref OmniMarket_5_buffer);

                            guiStandard.Label("MISC_OmniTeir_V_WorkTableSpeed".Translate(), MiscModsSettings.tier_5_Omni_WorkTableWorkSpeedFactor * 100);
                            MiscModsSettings.tier_5_Omni_WorkTableWorkSpeedFactor = guiStandard.Slider(MiscModsSettings.tier_5_Omni_WorkTableWorkSpeedFactor, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_GeneralLaborSpeed".Translate(), MiscModsSettings.tier_5_Omni_GeneralLaborSpeed * 100);
                            MiscModsSettings.tier_5_Omni_GeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_5_Omni_GeneralLaborSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_CleaningSpeed".Translate(), MiscModsSettings.tier_5_Omni_CleaningSpeed * 100);
                            MiscModsSettings.tier_5_Omni_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_5_Omni_CleaningSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_ConstructionSpeed".Translate(), MiscModsSettings.tier_5_Omni_ConstructionSpeed * 100);
                            MiscModsSettings.tier_5_Omni_ConstructionSpeed = guiStandard.Slider(MiscModsSettings.tier_5_Omni_ConstructionSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_DeepDrillSpeed".Translate(), MiscModsSettings.tier_5_Omni_DeepDrillingSpeed * 100);
                            MiscModsSettings.tier_5_Omni_DeepDrillingSpeed = guiStandard.Slider(MiscModsSettings.tier_5_Omni_DeepDrillingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_SmothingSpeed".Translate(), MiscModsSettings.tier_5_Omni_SmoothingSpeed * 100);
                            MiscModsSettings.tier_5_Omni_SmoothingSpeed = guiStandard.Slider(MiscModsSettings.tier_5_Omni_SmoothingSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_PlantWorkSpeed".Translate(), MiscModsSettings.tier_5_Omni_PlantWorkSpeed * 100);
                            MiscModsSettings.tier_5_Omni_PlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_5_Omni_PlantWorkSpeed, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_MiningYield".Translate(), MiscModsSettings.tier_5_Omni_MiningYield * 100);
                            MiscModsSettings.tier_5_Omni_MiningYield = guiStandard.Slider(MiscModsSettings.tier_5_Omni_MiningYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_PlantHarvestYield".Translate(), MiscModsSettings.tier_5_Omni_PlantHarvestYield * 100);
                            MiscModsSettings.tier_5_Omni_PlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_5_Omni_PlantHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_DrungHarvestSpeed".Translate(), MiscModsSettings.tier_5_Omni_DrugHarvestYield * 100);
                            MiscModsSettings.tier_5_Omni_DrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_5_Omni_DrugHarvestYield, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_ConstructChance".Translate(), MiscModsSettings.tier_5_Omni_ConstructSuccessChance * 100);
                            MiscModsSettings.tier_5_Omni_ConstructSuccessChance = guiStandard.Slider(MiscModsSettings.tier_5_Omni_ConstructSuccessChance, 0.1f, 15f);

                            guiStandard.Label("MISC_OmniTeir_V_SurgeryChance".Translate(), MiscModsSettings.tier_5_Omni_MedicalSurgerySuccessChance * 100);
                            MiscModsSettings.tier_5_Omni_MedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_5_Omni_MedicalSurgerySuccessChance, 0.1f, 15f);

                            }
#endif
                    }
                    guiStandard.End();
                }
                Widgets.EndScrollView();
            }
            guiStandard.End();
        }
        private void DrawingSettings(Listing_Standard listing, RobotsData data, float min, float max)
        {
            for (int i = 0; i < data.defThing.Length; i++)
            {
                listing.Label(data.defThing[i].Translate());
                for (int x = 0; x < data.statsData.Length; x++)
                {
                    listing.TextFieldNumericLabeled(data.statsData[x].ToString(), ref data.settingsValue[i,x], ref data.buffers[i,x], min, max);
                }
            }
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

        private void WriteSettings(List<string> thingDefs, List<StatDef> stat,float setting)
        {
            StatModifier statModifier = null;
            for (int i = 0; i < thingDefs.Count; i++)
            {
                for (int x = 0; x < stat.Count; x++)
                {
                    foreach (var statBasic in DefDatabase<ThingDef>.GetNamed(thingDefs[i]).statBases)
                    {
                        if (statBasic.stat == stat[x])
                        {
                            statModifier = statBasic;
                            break;
                        }
                    }
                }
                
                if (statModifier != null)
                {
                    statModifier.value = setting;
                }

            }
        }
    }
}




