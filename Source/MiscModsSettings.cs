using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.GUILayout;
using Verse;
using RimWorld;
using System.Linq;
using Verse.Noise;

namespace MiscRobotsPlusPlus
{
    public class MiscModsSettings : ModSettings
    {

        //Contains list of all bots by DefName
        //Remember to keep same names as in XML files
        //It throws error if it does not match
        #region Bots Def Names
        internal static readonly string[] cleanerList = new string[5] { "AIRobot_Cleaner", "AIRobot_Cleaner_II", "AIRobot_Cleaner_III", "AIRobot_Cleaner_IV", "AIRobot_Cleaner_V" };
        internal static readonly string[] crafterList = new string[5] { "RPP_Bot_Crafter_I", "RPP_Bot_Crafter_II", "RPP_Bot_Crafter_III", "RPP_Bot_Crafter_IV", "RPP_Bot_Crafter_V" };
        internal static readonly string[] kitchenList = new string[5] { "RPP_Bot_Kitchen_I", "RPP_Bot_Kitchen_II", "RPP_Bot_Kitchen_III", "RPP_Bot_Kitchen_IV", "RPP_Bot_Kitchen_V" };
        internal static readonly string[] buildersList = new string[5] { "RPP_Bot_Builder_I", "RPP_Bot_Builder_II", "RPP_Bot_Builder_III", "RPP_Bot_Builder_IV", "RPP_Bot_Builder_V" };
        internal static readonly string[] ERList = new string[5] { "RPP_Bot_ER_I", "RPP_Bot_ER_II", "RPP_Bot_ER_III", "RPP_Bot_ER_IV", "RPP_Bot_ER_V" };
        internal static readonly string[] omniList = new string[5] { "RPP_Bot_Omni_I", "RPP_Bot_Omni_II", "RPP_Bot_Omni_III", "RPP_Bot_Omni_IV", "RPP_Bot_Omni_V" };
        #endregion

        // Must be saved in same order as List of Stats in float table;
        #region Non Readable Settings

        #region Cleaner Compleated Settings
        internal static StatDef[] cleanerStats = new StatDef[2] { StatDefOf.CleaningSpeed, StatDefOf.MarketValue };

        internal static float[,] cleanerDefaultSettings = new float[5, 2] {

                { tier_1_CleaningSpeed, Tier_1_CleanerMarket  },
                { tier_2_CleaningSpeed, Tier_2_CleanerMarket  },
                { tier_3_CleaningSpeed, Tier_3_CleanerMarket  },
                { tier_4_CleaningSpeed, Tier_4_CleanerMarket  },
                { tier_5_CleaningSpeed, Tier_5_CleanerMarket  }

        };
        #endregion

        #region Crafter Compleated Match
        internal static StatDef[] crafterStats = new StatDef[2] { StatDefOf.GeneralLaborSpeed, StatDefOf.MarketValue };
        // Must be saved in same order as List of Stats in float table;
        internal static float[,] crafterDefaultSettings = new float[5, 2] {

                { tier_1_CrafterLaborSpeed,  Tier_1_CrafterMarket  },
                { tier_2_CrafterLaborSpeed,  Tier_2_CrafterMarket  },
                { tier_3_CrafterLaborSpeed,  Tier_3_CrafterMarket  },
                { tier_4_CrafterLaborSpeed,  Tier_4_CrafterMarket  },
                { tier_5_CrafterLaborSpeed,  Tier_5_CrafterMarket  }

        };
        #endregion

        #region Kitchen Compleated Match

        internal static StatDef[] kitchenStats = new StatDef[5] { StatDefOf.GeneralLaborSpeed, StatDefOf.PlantWorkSpeed, StatDefOf.PlantHarvestYield, StatDefOf.DrugHarvestYield, StatDefOf.MarketValue, };
        // Must be saved in same order as List of Stats in float table;
        internal static float[,] kitchenDefaultSettings = new float[5, 5] {

                { tier_1_KitchenGeneralLaborSpeed, tier_1_KitchenPlantWorkSpeed, tier_1_KitchenPlantHarvestYield , tier_1_KitchenDrugHarvestYield, tier_1_Kitcen_MarketValue },
                { tier_2_KitchenGeneralLaborSpeed, tier_2_KitchenPlantWorkSpeed, tier_2_KitchenPlantHarvestYield , tier_2_KitchenDrugHarvestYield, tier_2_Kitcen_MarketValue },
                { tier_3_KitchenGeneralLaborSpeed, tier_3_KitchenPlantWorkSpeed, tier_3_KitchenPlantHarvestYield , tier_3_KitchenDrugHarvestYield, tier_3_Kitcen_MarketValue },
                { tier_4_KitchenGeneralLaborSpeed, tier_4_KitchenPlantWorkSpeed, tier_4_KitchenPlantHarvestYield , tier_4_KitchenDrugHarvestYield, tier_4_Kitcen_MarketValue },
                { tier_5_KitchenGeneralLaborSpeed, tier_5_KitchenPlantWorkSpeed, tier_5_KitchenPlantHarvestYield , tier_5_KitchenDrugHarvestYield, tier_5_Kitcen_MarketValue }
        };
        #endregion

        #region Builder Compleated Match

        internal static StatDef[] builderStats = new StatDef[5] { StatDefOf.ConstructionSpeed, StatDefOf.DeepDrillingSpeed, StatDefOf.SmoothingSpeed, StatDefOf.MiningYield, StatDefOf.MarketValue, };
        // Must be saved in same order as List of Stats in float table;
        internal static float[,] builderDefaultSettings = new float[5, 5] {

                { tier_1_Builder_ConstructionSpeed, tier_1_Builder_DeepDrillingSpeed, tier_1_Builder_SmoothingSpeed , tier_1_Builder_MiningYield, tier_1_Builder_MarketValue },
                { tier_2_Builder_ConstructionSpeed, tier_2_Builder_DeepDrillingSpeed, tier_2_Builder_SmoothingSpeed , tier_2_Builder_MiningYield, tier_2_Builder_MarketValue },
                { tier_3_Builder_ConstructionSpeed, tier_3_Builder_DeepDrillingSpeed, tier_3_Builder_SmoothingSpeed , tier_3_Builder_MiningYield, tier_3_Builder_MarketValue },
                { tier_4_Builder_ConstructionSpeed, tier_4_Builder_DeepDrillingSpeed, tier_4_Builder_SmoothingSpeed , tier_4_Builder_MiningYield, tier_4_Builder_MarketValue },
                { tier_5_Builder_ConstructionSpeed, tier_5_Builder_DeepDrillingSpeed, tier_5_Builder_SmoothingSpeed , tier_5_Builder_MiningYield, tier_5_Builder_MarketValue }
        };
        #endregion

        #region ER Compleated Match
        internal static StatDef[] ERStats = new StatDef[3] { StatDefOf.MedicalTendSpeed, StatDefOf.MedicalSurgerySuccessChance, StatDefOf.MarketValue, };

        internal static float[,] ERDefaultSettings = new float[5, 3] {

                { tier_1_ERTendingLaborSpeed, tier_1_ERMedicalSurgerySuccessChance, Tier_1_ERMarket  },
                { tier_2_ERTendingLaborSpeed, tier_2_ERMedicalSurgerySuccessChance, Tier_2_ERMarket  },
                { tier_3_ERTendingLaborSpeed, tier_3_ERMedicalSurgerySuccessChance, Tier_3_ERMarket  },
                { tier_4_ERTendingLaborSpeed, tier_4_ERMedicalSurgerySuccessChance, Tier_4_ERMarket  },
                { tier_5_ERTendingLaborSpeed, tier_5_ERMedicalSurgerySuccessChance, Tier_5_ERMarket  }

        };
        #endregion

        #region Omni Compleated Match

        internal static StatDef[] OmniStats = new StatDef[12] { StatDefOf.MedicalTendSpeed, StatDefOf.MedicalSurgerySuccessChance, StatDefOf.ConstructionSpeed, StatDefOf.DeepDrillingSpeed, StatDefOf.SmoothingSpeed, StatDefOf.MiningYield, StatDefOf.PlantHarvestYield, StatDefOf.DrugHarvestYield, StatDefOf.CleaningSpeed,StatDefOf.WorkTableWorkSpeedFactor,StatDefOf.PlantWorkSpeed,StatDefOf.MarketValue, };
        internal static float[,] OmniDefaultSettings = new float[5, 12] {

             {tier_1_Omni_TendingSpeed, tier_1_Omni_MedicalSurgerySuccessChance, tier_1_Omni_ConstructionSpeed, tier_1_Omni_DeepDrillingSpeed, tier_1_Omni_SmoothingSpeed, tier_1_Omni_MiningYield, tier_1_Omni_PlantHarvestYield, tier_1_Omni_DrugHarvestYield, tier_1_Omni_CleaningSpeed,tier_1_Omni_WorkTableWorkSpeedFactor, tier_1_Omni_PlantWorkSpeed, tier_1_Omni_MarketValue },
             {tier_2_Omni_TendingSpeed, tier_2_Omni_MedicalSurgerySuccessChance, tier_2_Omni_ConstructionSpeed, tier_2_Omni_DeepDrillingSpeed, tier_2_Omni_SmoothingSpeed, tier_2_Omni_MiningYield, tier_2_Omni_PlantHarvestYield, tier_2_Omni_DrugHarvestYield, tier_2_Omni_CleaningSpeed,tier_2_Omni_WorkTableWorkSpeedFactor, tier_2_Omni_PlantWorkSpeed, tier_2_Omni_MarketValue },
             {tier_3_Omni_TendingSpeed, tier_3_Omni_MedicalSurgerySuccessChance, tier_3_Omni_ConstructionSpeed, tier_3_Omni_DeepDrillingSpeed, tier_3_Omni_SmoothingSpeed, tier_3_Omni_MiningYield, tier_3_Omni_PlantHarvestYield, tier_3_Omni_DrugHarvestYield, tier_3_Omni_CleaningSpeed,tier_3_Omni_WorkTableWorkSpeedFactor, tier_3_Omni_PlantWorkSpeed, tier_3_Omni_MarketValue },
             {tier_4_Omni_TendingSpeed, tier_4_Omni_MedicalSurgerySuccessChance, tier_4_Omni_ConstructionSpeed, tier_4_Omni_DeepDrillingSpeed, tier_4_Omni_SmoothingSpeed, tier_4_Omni_MiningYield, tier_4_Omni_PlantHarvestYield, tier_4_Omni_DrugHarvestYield, tier_4_Omni_CleaningSpeed,tier_4_Omni_WorkTableWorkSpeedFactor, tier_4_Omni_PlantWorkSpeed, tier_4_Omni_MarketValue },
             {tier_5_Omni_TendingSpeed, tier_5_Omni_MedicalSurgerySuccessChance, tier_5_Omni_ConstructionSpeed, tier_5_Omni_DeepDrillingSpeed, tier_5_Omni_SmoothingSpeed, tier_5_Omni_MiningYield, tier_5_Omni_PlantHarvestYield, tier_5_Omni_DrugHarvestYield, tier_5_Omni_CleaningSpeed,tier_5_Omni_WorkTableWorkSpeedFactor, tier_5_Omni_PlantWorkSpeed, tier_5_Omni_MarketValue }

        };
        #endregion

        #endregion

        internal static RobotsData cleanerData = new RobotsData(cleanerList, cleanerStats);
        internal static RobotsData crafterData = new RobotsData(crafterList, crafterStats);
        internal static RobotsData kitchensData = new RobotsData(kitchenList, kitchenStats);
        internal static RobotsData buildersData = new RobotsData(buildersList, builderStats);
        internal static RobotsData eRData = new RobotsData(ERList, ERStats);
        internal static RobotsData omniData = new RobotsData(omniList, OmniStats);

        #region Robots Readable Default Settings

        #region Cleaner Settings
        static float tier_1_CleaningSpeed = 1f;
        static float tier_2_CleaningSpeed = 1.5f;
        static float tier_3_CleaningSpeed = 2f;
        static float tier_4_CleaningSpeed = 3f; 
        static float tier_5_CleaningSpeed = 4f;

        static int Tier_1_CleanerMarket = 1000;
        static int Tier_2_CleanerMarket = 5000;
        static int Tier_3_CleanerMarket = 15000;
        static int Tier_4_CleanerMarket = 35000;
        static int Tier_5_CleanerMarket = 50000;
        #endregion

        #region Crafter
        static int Tier_1_CrafterMarket = 1000;
        static int Tier_2_CrafterMarket = 5000;
        static int Tier_3_CrafterMarket = 15000;
        static int Tier_4_CrafterMarket = 35000;
        static int Tier_5_CrafterMarket = 50000;

        static float tier_1_CrafterLaborSpeed = 1f;
        static float tier_2_CrafterLaborSpeed = 2f;
        static float tier_3_CrafterLaborSpeed = 2.5f;
        static float tier_4_CrafterLaborSpeed = 3f;
        static float tier_5_CrafterLaborSpeed = 4f;
        #endregion

        #region ER
 

        static float tier_1_ERMedicalSurgerySuccessChance = 1f;
        static float tier_2_ERMedicalSurgerySuccessChance = 1.25f;
        static float tier_3_ERMedicalSurgerySuccessChance = 1.5f;
        static float tier_4_ERMedicalSurgerySuccessChance = 1.75f;
        static float tier_5_ERMedicalSurgerySuccessChance = 2f;

        static float tier_1_ERTendingLaborSpeed = 1f;
        static float tier_2_ERTendingLaborSpeed = 2f;
        static float tier_3_ERTendingLaborSpeed = 2.5f;
        static float tier_4_ERTendingLaborSpeed = 3f;
        static float tier_5_ERTendingLaborSpeed = 4f;

        static int Tier_1_ERMarket = 1000;
        static int Tier_2_ERMarket = 5000;
        static int Tier_3_ERMarket = 15000;
        static int Tier_4_ERMarket = 35000;
        static int Tier_5_ERMarket = 50000;
        #endregion

        #region Kitchen

        static float tier_1_KitchenGeneralLaborSpeed = 1f;
        static float tier_2_KitchenGeneralLaborSpeed = 2f;
        static float tier_3_KitchenGeneralLaborSpeed = 2.5f;
        static float tier_4_KitchenGeneralLaborSpeed = 3f;
        static float tier_5_KitchenGeneralLaborSpeed = 4f;

        static float tier_1_KitchenPlantWorkSpeed = 1f;
        static float tier_2_KitchenPlantWorkSpeed = 2f;
        static float tier_3_KitchenPlantWorkSpeed = 2.5f;
        static float tier_4_KitchenPlantWorkSpeed = 3f;
        static float tier_5_KitchenPlantWorkSpeed = 4f;

        static float tier_1_KitchenPlantHarvestYield = 1f;
        static float tier_2_KitchenPlantHarvestYield = 1.25f;
        static float tier_3_KitchenPlantHarvestYield = 1.5f;
        static float tier_4_KitchenPlantHarvestYield = 1.75f;
        static float tier_5_KitchenDrugHarvestYield = 2f;

        static float tier_1_KitchenDrugHarvestYield = 1f;
        static float tier_2_KitchenDrugHarvestYield = 1.25f;
        static float tier_3_KitchenDrugHarvestYield = 1.5f;
        static float tier_4_KitchenDrugHarvestYield = 1.75f;
        static float tier_5_KitchenPlantHarvestYield = 2f;

        static int tier_1_Kitcen_MarketValue = 1000;
        static int tier_2_Kitcen_MarketValue = 5000;
        static int tier_3_Kitcen_MarketValue = 15000;
        static int tier_4_Kitcen_MarketValue = 35000;
        static int tier_5_Kitcen_MarketValue = 50000;
        #endregion

        #region Builder
        //Used in Builder anywhere?
        //static float tier_5_Builder_GeneralLaborSpeed = 1f;
        //static float tier_1_Builder_GeneralLaborSpeed = 1.5f;
        //static float tier_2_Builder_GeneralLaborSpeed = 2f;
        //static float tier_3_Builder_GeneralLaborSpeed = 3f;
        //static float tier_4_Builder_GeneralLaborSpeed = 4f;


        static int tier_1_Builder_MarketValue = 1000;
        static int tier_2_Builder_MarketValue = 5000;
        static int tier_3_Builder_MarketValue = 15000;
        static int tier_4_Builder_MarketValue = 35000;
        static int tier_5_Builder_MarketValue = 50000;

        static float tier_1_Builder_ConstructionSpeed = 1f;
        static float tier_2_Builder_ConstructionSpeed = 1.5f;
        static float tier_3_Builder_ConstructionSpeed = 2f;
        static float tier_4_Builder_ConstructionSpeed = 3f;
        static float tier_5_Builder_ConstructionSpeed = 4f;
        
        static float tier_1_Builder_DeepDrillingSpeed = 1f;
        static float tier_2_Builder_DeepDrillingSpeed = 1.5f;
        static float tier_3_Builder_DeepDrillingSpeed = 2f;
        static float tier_4_Builder_DeepDrillingSpeed = 3f;
        static float tier_5_Builder_DeepDrillingSpeed = 4f;

        static float tier_1_Builder_SmoothingSpeed = 1f;
        static float tier_2_Builder_SmoothingSpeed = 1.5f;
        static float tier_3_Builder_SmoothingSpeed = 2f;
        static float tier_4_Builder_SmoothingSpeed = 3f;
        static float tier_5_Builder_SmoothingSpeed = 4f;

        static float tier_1_Builder_MiningYield = 1f;
        static float tier_2_Builder_MiningYield = 1.25f;
        static float tier_3_Builder_MiningYield = 1.5f;
        static float tier_4_Builder_MiningYield = 1.75f;
        static float tier_5_Builder_MiningYield = 2.00f;
        #endregion

        #region Omni

        static float tier_1_Omni_TendingSpeed = 1f;
        static float tier_2_Omni_TendingSpeed = 2f;
        static float tier_3_Omni_TendingSpeed = 2.5f;
        static float tier_4_Omni_TendingSpeed = 3f;
        static float tier_5_Omni_TendingSpeed = 4f;

        static float tier_1_Omni_WorkTableWorkSpeedFactor = 1f;
        static float tier_2_Omni_WorkTableWorkSpeedFactor = 2f;
        static float tier_3_Omni_WorkTableWorkSpeedFactor = 2.5f;
        static float tier_4_Omni_WorkTableWorkSpeedFactor = 3f;
        static float tier_5_Omni_WorkTableWorkSpeedFactor = 4f;

        static float tier_1_Omni_CleaningSpeed = 1f;
        static float tier_2_Omni_CleaningSpeed = 2f;
        static float tier_3_Omni_CleaningSpeed = 2.5f;
        static float tier_4_Omni_CleaningSpeed = 3f;
        static float tier_5_Omni_CleaningSpeed = 4f;

        static float tier_1_Omni_ConstructionSpeed = 1f;
        static float tier_2_Omni_ConstructionSpeed = 2f;
        static float tier_3_Omni_ConstructionSpeed = 2.5f;
        static float tier_4_Omni_ConstructionSpeed = 3f;
        static float tier_5_Omni_ConstructionSpeed = 4f;

        static float tier_1_Omni_DeepDrillingSpeed = 1f;
        static float tier_2_Omni_DeepDrillingSpeed = 2f;
        static float tier_3_Omni_DeepDrillingSpeed = 2.5f;
        static float tier_4_Omni_DeepDrillingSpeed = 3f;
        static float tier_5_Omni_DeepDrillingSpeed = 4f;

        static float tier_1_Omni_SmoothingSpeed = 1f;
        static float tier_2_Omni_SmoothingSpeed = 2f;
        static float tier_3_Omni_SmoothingSpeed = 2.5f;
        static float tier_4_Omni_SmoothingSpeed = 3f;
        static float tier_5_Omni_SmoothingSpeed = 4f;

        static float tier_1_Omni_PlantWorkSpeed = 1f;
        static float tier_2_Omni_PlantWorkSpeed = 2f;
        static float tier_3_Omni_PlantWorkSpeed = 2.5f;
        static float tier_4_Omni_PlantWorkSpeed = 3f;
        static float tier_5_Omni_PlantWorkSpeed = 4f;
  
        static float tier_1_Omni_MiningYield = 1f;
        static float tier_2_Omni_MiningYield = 1.25f;
        static float tier_3_Omni_MiningYield = 1.5f;
        static float tier_4_Omni_MiningYield = 1.75f;
        static float tier_5_Omni_MiningYield = 2f;

        static float tier_1_Omni_PlantHarvestYield = 1f;
        static float tier_2_Omni_PlantHarvestYield = 1.25f;
        static float tier_3_Omni_PlantHarvestYield = 1.5f;
        static float tier_4_Omni_PlantHarvestYield = 1.75f;
        static float tier_5_Omni_PlantHarvestYield = 2f;

        static float tier_1_Omni_DrugHarvestYield = 1f;
        static float tier_2_Omni_DrugHarvestYield = 1.25f;
        static float tier_3_Omni_DrugHarvestYield = 1.5f;
        static float tier_4_Omni_DrugHarvestYield = 1.75f;
        static float tier_5_Omni_DrugHarvestYield = 2f;

        static float tier_1_Omni_MedicalSurgerySuccessChance = 1f;
        static float tier_2_Omni_MedicalSurgerySuccessChance = 1.25f;
        static float tier_3_Omni_MedicalSurgerySuccessChance = 1.5f;
        static float tier_4_Omni_MedicalSurgerySuccessChance = 1.75f;
        static float tier_5_Omni_MedicalSurgerySuccessChance = 2f;

        static int tier_1_Omni_MarketValue = 4000;
        static int tier_2_Omni_MarketValue = 8000;
        static int tier_3_Omni_MarketValue = 24000;
        static int tier_4_Omni_MarketValue = 36000;
        static int tier_5_Omni_MarketValue = 92000;

        #endregion

        #endregion


        internal static List<ThingDef> database;

        #region Expose Data

        public void ExposeValues(RobotsData data, float[,] defaultSettings)
        {
            for (int i = 0; i < data.defThing.Length; i++)
            {
                for (int x = 0; x < data.statsData.Length; x++)
                {
                    Scribe_Values.Look(ref data.settingsValue[i,x], data.defThing[i] + "_" + data.statsData[x].defName, defaultSettings[i,x]);
                }
            }
        }
        public override void ExposeData()
        {
            //Stored in XML config file
            base.ExposeData();
            ExposeValues(buildersData,builderDefaultSettings);
            ExposeValues(crafterData, crafterDefaultSettings);
            ExposeValues(cleanerData, cleanerDefaultSettings);
            ExposeValues(kitchensData, kitchenDefaultSettings);
            ExposeValues(eRData, ERDefaultSettings);
            ExposeValues(omniData, OmniDefaultSettings);
        }

#endregion

    }
}
    
