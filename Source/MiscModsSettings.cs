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

        internal static float tier_1_CleaningSpeed = 1f;
        internal static float Tier_1_CleanerMarket = 1000;
        internal static float tier_2_CleaningSpeed = 1.5f;
        internal static float tier_3_CleaningSpeed = 2f;
        internal static float tier_4_CleaningSpeed = 3f;
        internal static float tier_5_CleaningSpeed = 4f;
        #endregion

        #region Crafter
        internal static float tier_1_CrafterLaborSpeed = 1f;
        internal static float Tier_1_Crafter_WorkTableWorkSpeed = 1f;
        internal static float tier_2_CrafterLaborSpeed = 2f;
        internal static float Tier_2_Crafter_WorkTableWorkSpeed = 2f;
        internal static float tier_3_CrafterLaborSpeed = 2.5f;
        internal static float Tier_3_Crafter_WorkTableWorkSpeed = 2.5f;
        internal static float tier_4_CrafterLaborSpeed = 3f;
        internal static float Tier_4_Crafter_WorkTableWorkSpeed = 3f;
        internal static float tier_5_CrafterLaborSpeed = 4f;
        internal static float Tier_5_Crafter_WorkTableWorkSpeed = 4f;
        #endregion

        #region ER
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
        internal static float tier_1_KitchenGeneralLaborSpeed = 1f;
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
            Scribe_Values.Look(ref tier_1_CleaningSpeed, "MISC_Cleaner_I_Speed", 1f);
            Scribe_Values.Look(ref tier_2_CleaningSpeed, "MISC_Cleaner_II_Speed", 1.5f);
            Scribe_Values.Look(ref tier_3_CleaningSpeed, "MISC_Cleaner_III_Speed", 2f);
            Scribe_Values.Look(ref tier_4_CleaningSpeed, "MISC_Cleaner_IV_Speed", 3f);
            Scribe_Values.Look(ref tier_5_CleaningSpeed, "MISC_Cleaner_V_Speed", 4f);
            //Crafter
            Scribe_Values.Look(ref tier_1_CrafterLaborSpeed, "MISC_Crafter_I_Speed", 1f);
            Scribe_Values.Look(ref tier_2_CrafterLaborSpeed, "MISC_Crafter_II_Speed", 2f);
            Scribe_Values.Look(ref tier_3_CrafterLaborSpeed, "MISC_Crafter_III_Speed", 2.5f);
            Scribe_Values.Look(ref tier_4_CrafterLaborSpeed, "MISC_Crafter_IV_Speed", 3f);
            Scribe_Values.Look(ref tier_5_CrafterLaborSpeed, "MISC_Crafter_V_Speed", 4f);
            //ER
            Scribe_Values.Look(ref tier_1_ERMedicalSurgerySuccessChance, "MISC_ER_I_SurgeryChance", 1f);
            Scribe_Values.Look(ref tier_2_ERMedicalSurgerySuccessChance, "MISC_ER_II_SurgeryChance", 1.25f);
            Scribe_Values.Look(ref tier_3_ERMedicalSurgerySuccessChance, "MISC_ER_III_SurgeryChance", 1.5f);
            Scribe_Values.Look(ref tier_4_ERMedicalSurgerySuccessChance, "MISC_ER_IV_SurgeryChance", 1.75f);
            Scribe_Values.Look(ref tier_5_ERMedicalSurgerySuccessChance, "MISC_ER_V_SurgeryChance", 2f);
            //Kitchen
            Scribe_Values.Look(ref tier_1_KitchenGeneralLaborSpeed, "MISC_Kitchen_I_GeneralLaborSpeed", 1f);
            Scribe_Values.Look(ref tier_2_KitchenGeneralLaborSpeed, "MISC_Kitchen_II_GeneralLaborSpeed", 2f);
            Scribe_Values.Look(ref tier_3_KitchenGeneralLaborSpeed, "MISC_Kitchen_III_GeneralLaborSpeed", 2.5f);
            Scribe_Values.Look(ref tier_4_KitchenGeneralLaborSpeed, "MISC_Kitchen_IV_GeneralLaborSpeed", 3f);
            Scribe_Values.Look(ref tier_5_KitchenGeneralLaborSpeed, "MISC_Kitchen_V_GeneralLaborSpeed", 4f);

            Scribe_Values.Look(ref tier_1_KitchenPlantWorkSpeed, "MISC_Kitchen_I_PlantWorkSpeed", 1f);
            Scribe_Values.Look(ref tier_2_KitchenPlantWorkSpeed, "MISC_Kitchen_II_PlantWorkSpeed", 2f);
            Scribe_Values.Look(ref tier_3_KitchenPlantWorkSpeed, "MISC_Kitchen_III_PlantWorkSpeed", 2.5f);
            Scribe_Values.Look(ref tier_4_KitchenPlantWorkSpeed, "MISC_Kitchen_IV_PlantWorkSpeed", 3f);
            Scribe_Values.Look(ref tier_5_KitchenPlantWorkSpeed, "MISC_Kitchen_V_PlantWorkSpeed", 4f);

            Scribe_Values.Look(ref tier_1_KitchenPlantHarvestYield, "MISC_Kitchen_I_PlantHarvestYield", 1f);
            Scribe_Values.Look(ref tier_2_KitchenPlantHarvestYield, "MISC_Kitchen_II_PlantHarvestYield", 1.25f);
            Scribe_Values.Look(ref tier_3_KitchenPlantHarvestYield, "MISC_Kitchen_III_PlantHarvestYield", 1.5f);
            Scribe_Values.Look(ref tier_4_KitchenPlantHarvestYield, "MISC_Kitchen_IV_PlantHarvestYield", 1.75f);
            Scribe_Values.Look(ref tier_5_KitchenPlantHarvestYield, "MISC_Kitchen_V_PlantHarvestYield", 2f);

            Scribe_Values.Look(ref tier_1_KitchenDrugHarvestYield, "MISC_Kitchen_I_DrugHarvestYield", 1f);
            Scribe_Values.Look(ref tier_2_KitchenDrugHarvestYield, "MISC_Kitchen_II_DrugHarvestYield", 1.25f);
            Scribe_Values.Look(ref tier_3_KitchenDrugHarvestYield, "MISC_Kitchen_III_DrugHarvestYield", 1.5f);
            Scribe_Values.Look(ref tier_4_KitchenDrugHarvestYield, "MISC_Kitchen_IV_DrugHarvestYield", 1.75f);
            Scribe_Values.Look(ref tier_5_KitchenDrugHarvestYield, "MISC_Kitchen_V_DrugHarvestYield", 2f);
            //Builder
            Scribe_Values.Look(ref tier_1_Builder_ConstructionSpeed, "MISC_Builder_I_ConstructionSpeed", 1f);
            Scribe_Values.Look(ref tier_2_Builder_ConstructionSpeed, "MISC_Builder_II_ConstructionSpeed", 1.5f);
            Scribe_Values.Look(ref tier_3_Builder_ConstructionSpeed, "MISC_Builder_III_ConstructionSpeed", 2f);
            Scribe_Values.Look(ref tier_4_Builder_ConstructionSpeed, "MISC_Builder_IV_ConstructionSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Builder_ConstructionSpeed, "MISC_Builder_V_ConstructionSpeed", 4f);

            Scribe_Values.Look(ref tier_1_Builder_DeepDrillingSpeed, "MISC_Builder_I_DeepDrillingSpeed", 1f);
            Scribe_Values.Look(ref tier_2_Builder_DeepDrillingSpeed, "MISC_Builder_II_DeepDrillingSpeed", 1.5f);
            Scribe_Values.Look(ref tier_3_Builder_DeepDrillingSpeed, "MISC_Builder_III_DeepDrillingSpeed", 2f);
            Scribe_Values.Look(ref tier_4_Builder_DeepDrillingSpeed, "MISC_Builder_IV_DeepDrillingSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Builder_DeepDrillingSpeed, "MISC_Builder_V_DeepDrillingSpeed", 4f);

            Scribe_Values.Look(ref tier_5_Builder_GeneralLaborSpeed, "MISC_Builder_I_GeneralLaborSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Builder_GeneralLaborSpeed, "MISC_Builder_II_GeneralLaborSpeed", 1.5f);
            Scribe_Values.Look(ref tier_2_Builder_GeneralLaborSpeed, "MISC_Builder_III_GeneralLaborSpeed", 2f);
            Scribe_Values.Look(ref tier_3_Builder_GeneralLaborSpeed, "MISC_Builder_IV_GeneralLaborSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Builder_GeneralLaborSpeed, "MISC_Builder_V_GeneralLaborSpeed", 4f);

            Scribe_Values.Look(ref tier_1_Builder_SmoothingSpeed, "MISC_Builder_I_SmoothingSpeed", 1f);
            Scribe_Values.Look(ref tier_2_Builder_SmoothingSpeed, "MISC_Builder_II_SmoothingSpeed", 1.5f);
            Scribe_Values.Look(ref tier_3_Builder_SmoothingSpeed, "MISC_Builder_III_SmoothingSpeed", 2f);
            Scribe_Values.Look(ref tier_4_Builder_SmoothingSpeed, "MISC_Builder_IV_SmoothingSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Builder_SmoothingSpeed, "MISC_Builder_V_SmoothingSpeed", 4f);

            Scribe_Values.Look(ref tier_1_Builder_MiningYield, "MISC_Builder_I_MiningYield", 1f);
            Scribe_Values.Look(ref tier_2_Builder_MiningYield, "MISC_Builder_II_MiningYield", 1.2f);
            Scribe_Values.Look(ref tier_3_Builder_MiningYield, "MISC_Builder_III_MiningYield", 1.4f);
            Scribe_Values.Look(ref tier_4_Builder_MiningYield, "MISC_Builder_IV_MiningYield", 1.6f);
            Scribe_Values.Look(ref tier_5_Builder_MiningYield, "MISC_Builder_V_MiningYield", 1.8f);

            //Omni
            Scribe_Values.Look(ref tier_1_Omni_WorkTableWorkSpeedFactor, "MISC_Omni_I_WorkSpeedFactor", 1f);
            Scribe_Values.Look(ref tier_1_Omni_GeneralLaborSpeed, "MISC_Omni_I_GeneralLaborSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_CleaningSpeed, "MISC_Omni_I_CleaningSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_ConstructionSpeed, "MISC_Omni_I_ConstructionSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_DeepDrillingSpeed, "MISC_Omni_I_DeepDrillingSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_SmoothingSpeed, "MISC_Omni_I_SmoothingSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_PlantWorkSpeed, "MISC_Omni_I_PlantWorkSpeed", 1f);
            Scribe_Values.Look(ref tier_1_Omni_MiningYield, "MISC_Omni_I_MiningYield", 1f);
            Scribe_Values.Look(ref tier_1_Omni_PlantHarvestYield, "MISC_Omni_I_PlantHarvestYield", 1f);
            Scribe_Values.Look(ref tier_1_Omni_DrugHarvestYield, "MISC_Omni_I_DrugHarvestYield", 1f);
            Scribe_Values.Look(ref tier_1_Omni_ConstructSuccessChance, "MISC_Omni_I_ConstructSuccessChance", 1f);
            Scribe_Values.Look(ref tier_1_Omni_MedicalSurgerySuccessChance, "MISC_Omni_I_SurgerySuccess", 1f);

            Scribe_Values.Look(ref tier_2_Omni_WorkTableWorkSpeedFactor, "MISC_Omni_II_WorkSpeedFactor", 2f);
            Scribe_Values.Look(ref tier_2_Omni_GeneralLaborSpeed, "MISC_Omni_II_GeneralLaborSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_CleaningSpeed, "MISC_Omni_II_CleaningSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_ConstructionSpeed, "MISC_Omni_II_ConstructionSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_DeepDrillingSpeed, "MISC_Omni_II_DeepDrillingSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_SmoothingSpeed, "MISC_Omni_II_SmoothingSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_PlantWorkSpeed, "MISC_Omni_II_PlantWorkSpeed", 2f);
            Scribe_Values.Look(ref tier_2_Omni_MiningYield, "MISC_Omni_II_MiningYield", 1.3f);
            Scribe_Values.Look(ref tier_2_Omni_PlantHarvestYield, "MISC_Omni_II_PlantHarvestYield", 1.3f);
            Scribe_Values.Look(ref tier_2_Omni_DrugHarvestYield, "MISC_Omni_II_DrugHarvestYield", 1.3f);
            Scribe_Values.Look(ref tier_2_Omni_ConstructSuccessChance, "MISC_Omni_II_ConstructSuccessChance", 1.3f);
            Scribe_Values.Look(ref tier_2_Omni_MedicalSurgerySuccessChance, "MISC_Omni_II_SurgerySuccess", 1.3f);

            Scribe_Values.Look(ref tier_3_Omni_WorkTableWorkSpeedFactor, "MISC_Omni_III_WorkSpeedFactor", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_GeneralLaborSpeed, "MISC_Omni_III_GeneralLaborSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_CleaningSpeed, "MISC_Omni_III_CleaningSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_ConstructionSpeed, "MISC_Omni_III_ConstructionSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_DeepDrillingSpeed, "MISC_Omni_III_DeepDrillingSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_SmoothingSpeed, "MISC_Omni_III_SmoothingSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_PlantWorkSpeed, "MISC_Omni_III_PlantWorkSpeed", 2.5f);
            Scribe_Values.Look(ref tier_3_Omni_MiningYield, "MISC_Omni_III_MiningYield", 1.6f);
            Scribe_Values.Look(ref tier_3_Omni_PlantHarvestYield, "MISC_Omni_III_PlantHarvestYield", 1.6f);
            Scribe_Values.Look(ref tier_3_Omni_DrugHarvestYield, "MISC_Omni_III_DrugHarvestYield", 1.6f);
            Scribe_Values.Look(ref tier_3_Omni_ConstructSuccessChance, "MISC_Omni_III_ConstructSuccessChance", 1.6f);
            Scribe_Values.Look(ref tier_3_Omni_MedicalSurgerySuccessChance, "MISC_Omni_III_SurgerySuccess", 1.6f);

            Scribe_Values.Look(ref tier_4_Omni_WorkTableWorkSpeedFactor, "MISC_Omni_IV_WorkSpeedFactor", 3f);
            Scribe_Values.Look(ref tier_4_Omni_GeneralLaborSpeed, "MISC_Omni_IV_GeneralLaborSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_CleaningSpeed, "MISC_Omni_IV_CleaningSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_ConstructionSpeed, "MISC_Omni_IV_ConstructionSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_DeepDrillingSpeed, "MISC_Omni_IV_DeepDrillingSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_SmoothingSpeed, "MISC_Omni_IV_SmoothingSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_PlantWorkSpeed, "MISC_Omni_IV_PlantWorkSpeed", 3f);
            Scribe_Values.Look(ref tier_4_Omni_MiningYield, "MISC_Omni_IV_MiningYield", 1.9f);
            Scribe_Values.Look(ref tier_4_Omni_PlantHarvestYield, "MISC_Omni_IV_PlantHarvestYield", 1.9f);
            Scribe_Values.Look(ref tier_4_Omni_DrugHarvestYield, "MISC_Omni_IV_DrugHarvestYield", 1.9f);
            Scribe_Values.Look(ref tier_4_Omni_ConstructSuccessChance, "MISC_Omni_IV_ConstructSuccessChance", 1.6f);
            Scribe_Values.Look(ref tier_4_Omni_MedicalSurgerySuccessChance, "MISC_Omni_IV_SurgerySuccess", 1.9f);

            Scribe_Values.Look(ref tier_5_Omni_WorkTableWorkSpeedFactor, "MISC_Omni_V_WorkSpeedFactor", 3f);
            Scribe_Values.Look(ref tier_5_Omni_GeneralLaborSpeed, "MISC_Omni_V_GeneralLaborSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_CleaningSpeed, "MISC_Omni_V_CleaningSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_ConstructionSpeed, "MISC_Omni_V_ConstructionSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_DeepDrillingSpeed, "MISC_Omni_V_DeepDrillingSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_SmoothingSpeed, "MISC_Omni_V_SmoothingSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_PlantWorkSpeed, "MISC_Omni_V_PlantWorkSpeed", 3f);
            Scribe_Values.Look(ref tier_5_Omni_MiningYield, "MISC_Omni_V_MiningYield", 1.9f);
            Scribe_Values.Look(ref tier_5_Omni_PlantHarvestYield, "MISC_Omni_V_PlantHarvestYield", 1.9f);
            Scribe_Values.Look(ref tier_5_Omni_DrugHarvestYield, "MISC_Omni_V_DrugHarvestYield", 1.9f);
            Scribe_Values.Look(ref tier_5_Omni_ConstructSuccessChance, "MISC_Omni_V_MiningYield", 1.6f);
            Scribe_Values.Look(ref tier_5_Omni_MedicalSurgerySuccessChance, "MISC_Omni_V_ConstructSuccessChance", 1.9f);
            Scribe_Values.Look(ref tier_5_Omni_MedicalSurgerySuccessChance, "MISC_Omni_V_SurgerySuccess", 1.9f);

        }

        #endregion

    }
}
    
