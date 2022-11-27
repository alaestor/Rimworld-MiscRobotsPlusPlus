using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.GUILayout;
using Verse;

namespace MiscRobotsPlusPlus
{
    public class MiscModsSettings : ModSettings
    {
        #region Robots Settings

        #region Cleaner Settings
        internal static int Tier_1_CleanerMarket = 1000;
        internal static float tier_1_CleaningSpeed = 1f;
        internal static int Tier_2_CleanerMarket = 5000;
        internal static float tier_2_CleaningSpeed = 1.5f;
        internal static int Tier_3_CleanerMarket = 15000;
        internal static float tier_3_CleaningSpeed = 2f;
        internal static int Tier_4_CleanerMarket = 35000;
        internal static float tier_4_CleaningSpeed = 3f; 
        internal static int Tier_5_CleanerMarket = 50000;
        internal static float tier_5_CleaningSpeed = 4f;
        #endregion

        #region Crafter
        internal static int Tier_1_CrafterMarket = 1000;
        internal static float tier_1_CrafterLaborSpeed = 1f;
        internal static float Tier_1_Crafter_WorkTableWorkSpeed = 1f;
        internal static int Tier_2_CrafterMarket = 1000;
        internal static float tier_2_CrafterLaborSpeed = 2f;
        internal static float Tier_2_Crafter_WorkTableWorkSpeed = 2f;
        internal static int Tier_3_CrafterMarket = 1000;
        internal static float tier_3_CrafterLaborSpeed = 2.5f;
        internal static float Tier_3_Crafter_WorkTableWorkSpeed = 2.5f;
        internal static int Tier_4_CrafterMarket = 1000;
        internal static float tier_4_CrafterLaborSpeed = 3f;
        internal static float Tier_4_Crafter_WorkTableWorkSpeed = 3f;
        internal static int Tier_5_CrafterMarket = 1000;
        internal static float tier_5_CrafterLaborSpeed = 4f;
        internal static float Tier_5_Crafter_WorkTableWorkSpeed = 4f;
        #endregion

        #region ER
        internal static int Tier_1_ERMarket = 1000;
        internal static int Tier_2_ERMarket = 5000;
        internal static int Tier_3_ERMarket = 15000;
        internal static int Tier_4_ERMarket = 35000;
        internal static int Tier_5_ERMarket = 50000;

        internal static float tier_1_ERMedicalSurgerySuccessChance = 1f;
        internal static float tier_2_ERMedicalSurgerySuccessChance = 1.25f;
        internal static float tier_3_ERMedicalSurgerySuccessChance = 1.5f;
        internal static float tier_4_ERMedicalSurgerySuccessChance = 1.75f;
        internal static float tier_5_ERMedicalSurgerySuccessChance = 2f;

        internal static float tier_1_ERTendingLaborSpeed = 1f;
        internal static float tier_2_ERTendingLaborSpeed = 2f;
        internal static float tier_3_ERTendingLaborSpeed = 2.5f;
        internal static float tier_4_ERTendingLaborSpeed = 3f;
        internal static float tier_5_ERTendingLaborSpeed = 4f;
        #endregion

        #region Kitchen
        internal static int tier_1_Kitcen_MarketValue = 1000;
        internal static int tier_2_Kitcen_MarketValue = 5000;
        internal static int tier_3_Kitcen_MarketValue = 15000;
        internal static int tier_4_Kitcen_MarketValue = 35000;
        internal static int tier_5_Kitcen_MarketValue = 50000;

        internal static float tier_1_Kitchen_GeneralLaborSpeed = 1f;
        internal static float tier_1_KitchenPlantWorkSpeed = 1f;
        internal static float tier_1_KitchenPlantHarvestYield = 1f;
        internal static float tier_1_KitchenDrugHarvestYield = 1f;

        internal static float tier_2_KitchenGeneralLaborSpeed = 2f;
        internal static float tier_2_KitchenPlantWorkSpeed = 2f;
        internal static float tier_2_KitchenPlantHarvestYield = 1.25f;
        internal static float tier_2_KitchenDrugHarvestYield = 1.25f;

        internal static float tier_3_KitchenGeneralLaborSpeed = 2.5f;
        internal static float tier_3_KitchenPlantWorkSpeed = 2.5f;
        internal static float tier_3_KitchenPlantHarvestYield = 1.5f;
        internal static float tier_3_KitchenDrugHarvestYield = 1.5f;

        internal static float tier_4_KitchenGeneralLaborSpeed = 3f;
        internal static float tier_4_KitchenPlantWorkSpeed = 3f;
        internal static float tier_4_KitchenPlantHarvestYield = 1.75f;
        internal static float tier_4_KitchenDrugHarvestYield = 1.75f;

        internal static float tier_5_KitchenGeneralLaborSpeed = 4f;
        internal static float tier_5_KitchenPlantWorkSpeed = 4f;
        internal static float tier_5_KitchenPlantHarvestYield = 2f;
        internal static float tier_5_KitchenDrugHarvestYield = 2f;
        #endregion

        #region Builder
        //Used in Builder anywhere?
        internal static float tier_5_Builder_GeneralLaborSpeed = 1f;
        internal static float tier_1_Builder_GeneralLaborSpeed = 1.5f;
        internal static float tier_2_Builder_GeneralLaborSpeed = 2f;
        internal static float tier_3_Builder_GeneralLaborSpeed = 3f;
        internal static float tier_4_Builder_GeneralLaborSpeed = 4f;


        internal static int tier_1_Builder_MarketValue = 1000;
        internal static int tier_2_Builder_MarketValue = 5000;
        internal static int tier_3_Builder_MarketValue = 15000;
        internal static int tier_4_Builder_MarketValue = 35000;
        internal static int tier_5_Builder_MarketValue = 50000;

        internal static float tier_1_Builder_ConstructionSpeed = 1f;
        internal static float tier_2_Builder_ConstructionSpeed = 1.5f;
        internal static float tier_3_Builder_ConstructionSpeed = 2f;
        internal static float tier_4_Builder_ConstructionSpeed = 3f;
        internal static float tier_5_Builder_ConstructionSpeed = 4f;
        
        internal static float tier_1_Builder_DeepDrillingSpeed = 1f;
        internal static float tier_2_Builder_DeepDrillingSpeed = 1.5f;
        internal static float tier_3_Builder_DeepDrillingSpeed = 2f;
        internal static float tier_4_Builder_DeepDrillingSpeed = 3f;
        internal static float tier_5_Builder_DeepDrillingSpeed = 4f;

        internal static float tier_1_Builder_SmoothingSpeed = 1f;
        internal static float tier_2_Builder_SmoothingSpeed = 1.5f;
        internal static float tier_3_Builder_SmoothingSpeed = 2f;
        internal static float tier_4_Builder_SmoothingSpeed = 3f;
        internal static float tier_5_Builder_SmoothingSpeed = 4f;

        internal static float tier_1_Builder_MiningYield = 1f;
        internal static float tier_2_Builder_MiningYield = 1.25f;
        internal static float tier_3_Builder_MiningYield = 1.5f;
        internal static float tier_4_Builder_MiningYield = 1.75f;
        internal static float tier_5_Builder_MiningYield = 2.00f;
        #endregion

        #region Omni


        internal static int tier_1_Omni_MarketValue = 4000;
        internal static int tier_2_Omni_MarketValue = 8000;
        internal static int tier_3_Omni_MarketValue = 24000;
        internal static int tier_4_Omni_MarketValue = 36000;
        internal static int tier_5_Omni_MarketValue = 92000; 

        internal static float tier_1_Omni_WorkTableWorkSpeedFactor = 1f;
        internal static float tier_1_Omni_GeneralLaborSpeed = 1f;
        internal static float tier_1_Omni_CleaningSpeed = 1f;
        internal static float tier_1_Omni_ConstructionSpeed = 1f;
        internal static float tier_1_Omni_DeepDrillingSpeed = 1f;
        internal static float tier_1_Omni_SmoothingSpeed = 1f;
        internal static float tier_1_Omni_PlantWorkSpeed = 1f;
        internal static float tier_1_Omni_MiningYield = 1f;
        internal static float tier_1_Omni_PlantHarvestYield = 1f;
        internal static float tier_1_Omni_DrugHarvestYield = 1f;
        internal static float tier_1_Omni_ConstructSuccessChance = 1f;
        internal static float tier_1_Omni_MedicalSurgerySuccessChance = 1f;


        internal static float tier_2_Omni_WorkTableWorkSpeedFactor = 2f;
        internal static float tier_2_Omni_GeneralLaborSpeed = 2f;
        internal static float tier_2_Omni_CleaningSpeed = 2f;
        internal static float tier_2_Omni_ConstructionSpeed = 2f;
        internal static float tier_2_Omni_DeepDrillingSpeed = 2f;
        internal static float tier_2_Omni_SmoothingSpeed = 2f;
        internal static float tier_2_Omni_PlantWorkSpeed = 2f;
        internal static float tier_2_Omni_MiningYield = 1.3f;
        internal static float tier_2_Omni_PlantHarvestYield = 1.3f;
        internal static float tier_2_Omni_DrugHarvestYield = 1.3f;
        internal static float tier_2_Omni_ConstructSuccessChance = 1.3f;
        internal static float tier_2_Omni_MedicalSurgerySuccessChance = 1.3f;

        internal static float tier_3_Omni_WorkTableWorkSpeedFactor = 2.5f;
        internal static float tier_3_Omni_GeneralLaborSpeed = 2.5f;
        internal static float tier_3_Omni_CleaningSpeed = 2.5f;
        internal static float tier_3_Omni_ConstructionSpeed = 2.5f;
        internal static float tier_3_Omni_DeepDrillingSpeed = 2.5f;
        internal static float tier_3_Omni_SmoothingSpeed = 2.5f;
        internal static float tier_3_Omni_PlantWorkSpeed = 2.5f;
        internal static float tier_3_Omni_MiningYield = 1.6f;
        internal static float tier_3_Omni_PlantHarvestYield = 1.6f;
        internal static float tier_3_Omni_DrugHarvestYield = 1.6f;
        internal static float tier_3_Omni_ConstructSuccessChance = 1.6f;
        internal static float tier_3_Omni_MedicalSurgerySuccessChance = 1.6f;

        internal static float tier_4_Omni_WorkTableWorkSpeedFactor = 3f;
        internal static float tier_4_Omni_GeneralLaborSpeed = 3f;
        internal static float tier_4_Omni_CleaningSpeed = 3f;
        internal static float tier_4_Omni_ConstructionSpeed = 3f;
        internal static float tier_4_Omni_DeepDrillingSpeed = 3f;
        internal static float tier_4_Omni_SmoothingSpeed = 3f;
        internal static float tier_4_Omni_PlantWorkSpeed = 3f;
        internal static float tier_4_Omni_MiningYield = 1.9f;
        internal static float tier_4_Omni_PlantHarvestYield = 1.9f;
        internal static float tier_4_Omni_DrugHarvestYield = 1.9f;
        internal static float tier_4_Omni_ConstructSuccessChance = 1.6f;
        internal static float tier_4_Omni_MedicalSurgerySuccessChance = 1.9f;


        internal static float tier_5_Omni_WorkTableWorkSpeedFactor = 3f;
        internal static float tier_5_Omni_GeneralLaborSpeed = 3f;
        internal static float tier_5_Omni_CleaningSpeed = 3f;
        internal static float tier_5_Omni_ConstructionSpeed = 3f;
        internal static float tier_5_Omni_DeepDrillingSpeed = 3f;
        internal static float tier_5_Omni_SmoothingSpeed = 3f;
        internal static float tier_5_Omni_PlantWorkSpeed = 3f;
        internal static float tier_5_Omni_MiningYield = 1.9f;
        internal static float tier_5_Omni_PlantHarvestYield = 1.9f;
        internal static float tier_5_Omni_DrugHarvestYield = 1.9f;
        internal static float tier_5_Omni_ConstructSuccessChance = 1.6f;
        internal static float tier_5_Omni_MedicalSurgerySuccessChance = 1.9f;

        #endregion
        #endregion
        internal static List<ThingDef> database;
        #region Expose Data
        public override void ExposeData()
        {
            base.ExposeData();

            //Cleaner
            Scribe_Values.Look(ref Tier_1_CleanerMarket, "Cleaner_I_Market_Value",1000);
            Scribe_Values.Look(ref Tier_2_CleanerMarket, "Cleaner_II_Market_Value", 5000);
            Scribe_Values.Look(ref Tier_3_CleanerMarket, "Cleaner_III_Market_Value", 15000);
            Scribe_Values.Look(ref Tier_4_CleanerMarket, "Cleaner_IV_Market_Value", 35000);
            Scribe_Values.Look(ref Tier_5_CleanerMarket, "Cleaner_V_Market_Value", 50000);

            Scribe_Values.Look(ref tier_1_CleaningSpeed, "Cleaner_I_Cleaning_Speed", 1f);
            Scribe_Values.Look(ref tier_2_CleaningSpeed, "Cleaner_II_Cleaning_Speed", 1.5f);
            Scribe_Values.Look(ref tier_3_CleaningSpeed, "Cleaner_III_Cleaning_Speed", 2f);
            Scribe_Values.Look(ref tier_4_CleaningSpeed, "Cleaner_IV_Cleaning_Speed", 3f);
            Scribe_Values.Look(ref tier_5_CleaningSpeed, "Cleaner_V_Cleaning_Speed", 4f);


            //Crafter
            Scribe_Values.Look(ref Tier_1_CrafterMarket, "Crafter_I_Market_Value", 1000);
            Scribe_Values.Look(ref Tier_1_CrafterMarket, "Crafter_II_Market_Value", 5000);
            Scribe_Values.Look(ref Tier_1_CrafterMarket, "Crafter_III_Market_Value", 15000);
            Scribe_Values.Look(ref Tier_1_CrafterMarket, "Crafter_IV_Market_Value", 35000); 
            Scribe_Values.Look(ref Tier_1_CrafterMarket, "Crafter_V_Market_Value", 50000);

            Scribe_Values.Look(ref tier_1_CrafterLaborSpeed, "Crafter_I_Crafting_Speed", 1f);
            Scribe_Values.Look(ref tier_2_CrafterLaborSpeed, "Crafter_II_Crafting_Speed", 2f);
            Scribe_Values.Look(ref tier_3_CrafterLaborSpeed, "Crafter_III_Crafting_Speed", 2.5f);
            Scribe_Values.Look(ref tier_4_CrafterLaborSpeed, "Crafter_IV_Crafting_Speed", 3f);
            Scribe_Values.Look(ref tier_5_CrafterLaborSpeed, "Crafter_V_Crafting_Speed", 4f);


            //ER
            Scribe_Values.Look(ref Tier_1_ERMarket, "ER_I_Market_Value", 1000);
            Scribe_Values.Look(ref Tier_2_ERMarket, "ER_II_Market_Value", 5000);
            Scribe_Values.Look(ref Tier_3_ERMarket, "ER_III_Market_Value", 15000);
            Scribe_Values.Look(ref Tier_4_ERMarket, "ER_IV_Market_Value", 35000);
            Scribe_Values.Look(ref Tier_5_ERMarket, "ER_V_Market_Value", 50000);

            Scribe_Values.Look(ref tier_1_ERTendingLaborSpeed, "ER_I_Tending_Speed", 1f);
            Scribe_Values.Look(ref tier_2_ERTendingLaborSpeed, "ER_II_Tending_Speed", 2f);
            Scribe_Values.Look(ref tier_3_ERTendingLaborSpeed, "ER_III_Tending_Speed", 2.5f);
            Scribe_Values.Look(ref tier_4_ERTendingLaborSpeed, "ER_IV_Tending_Speed", 3f);
            Scribe_Values.Look(ref tier_5_ERTendingLaborSpeed, "ER_V_Tending_Speed", 4f);

            Scribe_Values.Look(ref tier_1_ERMedicalSurgerySuccessChance, "ER_I_Surgery_Chance", 1f);
            Scribe_Values.Look(ref tier_2_ERMedicalSurgerySuccessChance, "ER_II_Surgery_Chance", 1.25f);
            Scribe_Values.Look(ref tier_3_ERMedicalSurgerySuccessChance, "ER_III_Surgery_Chance", 1.5f);
            Scribe_Values.Look(ref tier_4_ERMedicalSurgerySuccessChance, "ER_IV_Surgery_Chance", 1.75f);
            Scribe_Values.Look(ref tier_5_ERMedicalSurgerySuccessChance, "ER_V_Surgery_Chance", 2f);


            //Kitchen
            Scribe_Values.Look(ref tier_1_Kitcen_MarketValue, "Kitchen_I_MarketValue", 1000);
            Scribe_Values.Look(ref tier_2_Kitcen_MarketValue, "Kitchen_II_MarketValue", 5000);
            Scribe_Values.Look(ref tier_3_Kitcen_MarketValue, "Kitchen_III_MarketValue", 15000);
            Scribe_Values.Look(ref tier_4_Kitcen_MarketValue, "Kitchen_IV_MarketValue", 35000);
            Scribe_Values.Look(ref tier_5_Kitcen_MarketValue, "Kitchen_V_MarketValue", 50000);

            Scribe_Values.Look(ref tier_1_Kitchen_GeneralLaborSpeed, "Kitchen_I_GeneralLaborSpeed", 1f);
            Scribe_Values.Look(ref tier_2_KitchenGeneralLaborSpeed, "Kitchen_II_GeneralLaborSpeed", 2f);
            Scribe_Values.Look(ref tier_3_KitchenGeneralLaborSpeed, "Kitchen_III_GeneralLaborSpeed", 2.5f);
            Scribe_Values.Look(ref tier_4_KitchenGeneralLaborSpeed, "Kitchen_IV_GeneralLaborSpeed", 3f);
            Scribe_Values.Look(ref tier_5_KitchenGeneralLaborSpeed, "Kitchen_V_GeneralLaborSpeed", 4f);

            Scribe_Values.Look(ref tier_1_KitchenPlantWorkSpeed, "Kitchen_I_PlantWorkSpeed", 1f);
            Scribe_Values.Look(ref tier_2_KitchenPlantWorkSpeed, "Kitchen_II_PlantWorkSpeed", 2f);
            Scribe_Values.Look(ref tier_3_KitchenPlantWorkSpeed, "Kitchen_III_PlantWorkSpeed", 2.5f);
            Scribe_Values.Look(ref tier_4_KitchenPlantWorkSpeed, "Kitchen_IV_PlantWorkSpeed", 3f);
            Scribe_Values.Look(ref tier_5_KitchenPlantWorkSpeed, "Kitchen_V_PlantWorkSpeed", 4f);

            Scribe_Values.Look(ref tier_1_KitchenPlantHarvestYield, "Kitchen_I_PlantHarvestYield", 1f);
            Scribe_Values.Look(ref tier_2_KitchenPlantHarvestYield, "Kitchen_II_PlantHarvestYield", 1.25f);
            Scribe_Values.Look(ref tier_3_KitchenPlantHarvestYield, "Kitchen_III_PlantHarvestYield", 1.5f);
            Scribe_Values.Look(ref tier_4_KitchenPlantHarvestYield, "Kitchen_IV_PlantHarvestYield", 1.75f);
            Scribe_Values.Look(ref tier_5_KitchenPlantHarvestYield, "Kitchen_V_PlantHarvestYield", 2f);

            Scribe_Values.Look(ref tier_1_KitchenDrugHarvestYield, "Kitchen_I_DrugHarvestYield", 1f);
            Scribe_Values.Look(ref tier_2_KitchenDrugHarvestYield, "Kitchen_II_DrugHarvestYield", 1.25f);
            Scribe_Values.Look(ref tier_3_KitchenDrugHarvestYield, "Kitchen_III_DrugHarvestYield", 1.5f);
            Scribe_Values.Look(ref tier_4_KitchenDrugHarvestYield, "Kitchen_IV_DrugHarvestYield", 1.75f);
            Scribe_Values.Look(ref tier_5_KitchenDrugHarvestYield, "Kitchen_V_DrugHarvestYield", 2f);


            //Builder
            Scribe_Values.Look(ref tier_1_Builder_MarketValue, "Builder_I_MarketValue", 1000);
            Scribe_Values.Look(ref tier_2_Builder_MarketValue, "Builder_II_MarketValue", 5000);
            Scribe_Values.Look(ref tier_3_Builder_MarketValue, "Builder_III_MarketValue", 15000);
            Scribe_Values.Look(ref tier_4_Builder_MarketValue, "Builder_IV_MarketValue", 35000);
            Scribe_Values.Look(ref tier_5_Builder_MarketValue, "Builder_V_MarketValue", 50000);

            Scribe_Values.Look(ref tier_1_Builder_ConstructionSpeed, "Builder_I_ConstructionSpeed", 1f);
            Scribe_Values.Look(ref tier_2_Builder_ConstructionSpeed, "Builder_II_ConstructionSpeed", 1.5f);
            Scribe_Values.Look(ref tier_3_Builder_ConstructionSpeed, "Builder_III_ConstructionSpeed", 2f);
            Scribe_Values.Look(ref tier_4_Builder_ConstructionSpeed, "Builder_IV_ConstructionSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Builder_ConstructionSpeed, "Builder_V_ConstructionSpeed", 4f);

            Scribe_Values.Look(ref tier_1_Builder_DeepDrillingSpeed, "Builder_I_DeepDrillingSpeed", 1f);
            Scribe_Values.Look(ref tier_2_Builder_DeepDrillingSpeed, "Builder_II_DeepDrillingSpeed", 1.5f);
            Scribe_Values.Look(ref tier_3_Builder_DeepDrillingSpeed, "Builder_III_DeepDrillingSpeed", 2f);
            Scribe_Values.Look(ref tier_4_Builder_DeepDrillingSpeed, "Builder_IV_DeepDrillingSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Builder_DeepDrillingSpeed, "Builder_V_DeepDrillingSpeed", 4f);

            Scribe_Values.Look(ref tier_5_Builder_GeneralLaborSpeed, "Builder_I_GeneralLaborSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Builder_GeneralLaborSpeed, "Builder_II_GeneralLaborSpeed", 1.5f);
            Scribe_Values.Look(ref tier_2_Builder_GeneralLaborSpeed, "Builder_III_GeneralLaborSpeed", 2f);
            Scribe_Values.Look(ref tier_3_Builder_GeneralLaborSpeed, "Builder_IV_GeneralLaborSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Builder_GeneralLaborSpeed, "Builder_V_GeneralLaborSpeed", 4f);

            Scribe_Values.Look(ref tier_1_Builder_SmoothingSpeed, "Builder_I_SmoothingSpeed", 1f);
            Scribe_Values.Look(ref tier_2_Builder_SmoothingSpeed, "Builder_II_SmoothingSpeed", 1.5f);
            Scribe_Values.Look(ref tier_3_Builder_SmoothingSpeed, "Builder_III_SmoothingSpeed", 2f);
            Scribe_Values.Look(ref tier_4_Builder_SmoothingSpeed, "Builder_IV_SmoothingSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Builder_SmoothingSpeed, "Builder_V_SmoothingSpeed", 4f);

            Scribe_Values.Look(ref tier_1_Builder_MiningYield, "Builder_I_MiningYield", 1f);
            Scribe_Values.Look(ref tier_2_Builder_MiningYield, "Builder_II_MiningYield", 1.2f);
            Scribe_Values.Look(ref tier_3_Builder_MiningYield, "Builder_III_MiningYield", 1.4f);
            Scribe_Values.Look(ref tier_4_Builder_MiningYield, "Builder_IV_MiningYield", 1.6f);
            Scribe_Values.Look(ref tier_5_Builder_MiningYield, "Builder_V_MiningYield", 1.8f);

            //Omni


    
            Scribe_Values.Look(ref tier_1_Omni_MarketValue, "Omni_I_MarketValue", 4000);
            Scribe_Values.Look(ref tier_1_Omni_MarketValue, "Omni_II_MarketValue", 8000);
            Scribe_Values.Look(ref tier_1_Omni_MarketValue, "Omni_III_MarketValue", 24000);
            Scribe_Values.Look(ref tier_1_Omni_MarketValue, "Omni_IV_MarketValue", 36000);
            Scribe_Values.Look(ref tier_1_Omni_MarketValue, "Omni_V_MarketValue", 92000);

            Scribe_Values.Look(ref tier_1_Omni_WorkTableWorkSpeedFactor, "Omni_I_WorkSpeedFactor", 1f);
            Scribe_Values.Look(ref tier_1_Omni_GeneralLaborSpeed, "Omni_I_GeneralLaborSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_CleaningSpeed, "Omni_I_CleaningSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_ConstructionSpeed, "Omni_I_ConstructionSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_DeepDrillingSpeed, "Omni_I_DeepDrillingSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_SmoothingSpeed, "Omni_I_SmoothingSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_PlantWorkSpeed, "Omni_I_PlantWorkSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_MiningYield, "Omni_I_MiningYield", 1f);
            Scribe_Values.Look(ref tier_1_Omni_PlantHarvestYield, "Omni_I_PlantHarvestYield", 1f);
            Scribe_Values.Look(ref tier_1_Omni_DrugHarvestYield, "Omni_I_DrugHarvestYield", 1f);
            Scribe_Values.Look(ref tier_1_Omni_ConstructSuccessChance, "Omni_I_ConstructSuccessChance", 1f);
            Scribe_Values.Look(ref tier_1_Omni_MedicalSurgerySuccessChance, "Omni_I_SurgerySuccess", 1f);

            Scribe_Values.Look(ref tier_2_Omni_WorkTableWorkSpeedFactor, "Omni_II_WorkSpeedFactor", 2f);
            Scribe_Values.Look(ref tier_2_Omni_GeneralLaborSpeed, "Omni_II_GeneralLaborSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_CleaningSpeed, "Omni_II_CleaningSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_ConstructionSpeed, "Omni_II_ConstructionSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_DeepDrillingSpeed, "Omni_II_DeepDrillingSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_SmoothingSpeed, "Omni_II_SmoothingSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_PlantWorkSpeed, "Omni_II_PlantWorkSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_MiningYield, "Omni_II_MiningYield", 1.3f);
            Scribe_Values.Look(ref tier_2_Omni_PlantHarvestYield, "Omni_II_PlantHarvestYield", 1.3f);
            Scribe_Values.Look(ref tier_2_Omni_DrugHarvestYield, "Omni_II_DrugHarvestYield", 1.3f);
            Scribe_Values.Look(ref tier_2_Omni_ConstructSuccessChance, "Omni_II_ConstructSuccessChance", 1.3f);
            Scribe_Values.Look(ref tier_2_Omni_MedicalSurgerySuccessChance, "Omni_II_SurgerySuccess", 1.3f);

            Scribe_Values.Look(ref tier_3_Omni_WorkTableWorkSpeedFactor, "Omni_III_WorkSpeedFactor", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_GeneralLaborSpeed, "Omni_III_GeneralLaborSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_CleaningSpeed, "Omni_III_CleaningSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_ConstructionSpeed, "Omni_III_ConstructionSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_DeepDrillingSpeed, "Omni_III_DeepDrillingSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_SmoothingSpeed, "Omni_III_SmoothingSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_PlantWorkSpeed, "Omni_III_PlantWorkSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_MiningYield, "Omni_III_MiningYield", 1.6f);
            Scribe_Values.Look(ref tier_3_Omni_PlantHarvestYield, "Omni_III_PlantHarvestYield", 1.6f);
            Scribe_Values.Look(ref tier_3_Omni_DrugHarvestYield, "Omni_III_DrugHarvestYield", 1.6f);
            Scribe_Values.Look(ref tier_3_Omni_ConstructSuccessChance, "Omni_III_ConstructSuccessChance", 1.6f);
            Scribe_Values.Look(ref tier_3_Omni_MedicalSurgerySuccessChance, "Omni_III_SurgerySuccess", 1.6f);

            Scribe_Values.Look(ref tier_4_Omni_WorkTableWorkSpeedFactor, "Omni_IV_WorkSpeedFactor", 3f);
            Scribe_Values.Look(ref tier_4_Omni_GeneralLaborSpeed, "Omni_IV_GeneralLaborSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_CleaningSpeed, "Omni_IV_CleaningSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_ConstructionSpeed, "Omni_IV_ConstructionSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_DeepDrillingSpeed, "Omni_IV_DeepDrillingSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_SmoothingSpeed, "Omni_IV_SmoothingSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_PlantWorkSpeed, "Omni_IV_PlantWorkSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_MiningYield, "Omni_IV_MiningYield", 1.9f);
            Scribe_Values.Look(ref tier_4_Omni_PlantHarvestYield, "Omni_IV_PlantHarvestYield", 1.9f);
            Scribe_Values.Look(ref tier_4_Omni_DrugHarvestYield, "Omni_IV_DrugHarvestYield", 1.9f);
            Scribe_Values.Look(ref tier_4_Omni_ConstructSuccessChance, "Omni_IV_ConstructSuccessChance", 1.6f);
            Scribe_Values.Look(ref tier_4_Omni_MedicalSurgerySuccessChance, "Omni_IV_SurgerySuccess", 1.9f);

            Scribe_Values.Look(ref tier_5_Omni_WorkTableWorkSpeedFactor, "Omni_V_WorkSpeedFactor", 3f);
            Scribe_Values.Look(ref tier_5_Omni_GeneralLaborSpeed, "Omni_V_GeneralLaborSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_CleaningSpeed, "Omni_V_CleaningSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_ConstructionSpeed, "Omni_V_ConstructionSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_DeepDrillingSpeed, "Omni_V_DeepDrillingSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_SmoothingSpeed, "Omni_V_SmoothingSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_PlantWorkSpeed, "Omni_V_PlantWorkSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_MiningYield, "Omni_V_MiningYield", 1.9f);
            Scribe_Values.Look(ref tier_5_Omni_PlantHarvestYield, "Omni_V_PlantHarvestYield", 1.9f);
            Scribe_Values.Look(ref tier_5_Omni_DrugHarvestYield, "Omni_V_DrugHarvestYield", 1.9f);
            Scribe_Values.Look(ref tier_5_Omni_ConstructSuccessChance, "Omni_V_MiningYield", 1.6f);
            Scribe_Values.Look(ref tier_5_Omni_MedicalSurgerySuccessChance, "Omni_V_ConstructSuccessChance", 1.9f);
            Scribe_Values.Look(ref tier_5_Omni_MedicalSurgerySuccessChance, "Omni_V_SurgerySuccess", 1.9f);

        }

        #endregion

    }
}
    
