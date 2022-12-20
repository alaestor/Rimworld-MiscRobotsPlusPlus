using System.Collections.Generic;
using UnityEngine;
using RimWorld;
using Verse;

namespace MiscRobotsPlusPlus
{
    public class MiscPlusPlusSettings : ModSettings
    {

        public static SettingsPages currentPage;

        private static bool cleanerTweaks = false;
        private static bool crafterTweaks = false;
        private static bool builderTweaks = false;
        private static bool kitchenTweaks = false;
        private static bool eRTweaks = false;
        private static bool omniTweaks = false;

        private static bool cleanerStationTweaks = false;
        private static bool haulerStationTweaks = false; 
        private static bool crafterStationTweaks = false;
        private static bool builderStationTweaks = false;
        private static bool kitchenStationTweaks = false;
        private static bool eRStationweaks = false;
        private static bool omniStationTweaks = false;

       // private static bool DevTweaks = false;
      
        //Contains list of all bots by DefName
        //Remember to keep same names as in XML files
        //It throws error if it does not match
        #region Def Names
        private static readonly string[] cleanerList = new string[5] { "AIRobot_Cleaner", "AIRobot_Cleaner_II", "AIRobot_Cleaner_III", "AIRobot_Cleaner_IV", "AIRobot_Cleaner_V" };
        private static readonly string[] crafterList = new string[5] { "RPP_Bot_Crafter_I", "RPP_Bot_Crafter_II", "RPP_Bot_Crafter_III", "RPP_Bot_Crafter_IV", "RPP_Bot_Crafter_V" };
        private static readonly string[] kitchenList = new string[5] { "RPP_Bot_Kitchen_I", "RPP_Bot_Kitchen_II", "RPP_Bot_Kitchen_III", "RPP_Bot_Kitchen_IV", "RPP_Bot_Kitchen_V" };
        private static readonly string[] buildersList = new string[5] { "RPP_Bot_Builder_I", "RPP_Bot_Builder_II", "RPP_Bot_Builder_III", "RPP_Bot_Builder_IV", "RPP_Bot_Builder_V" };
        private static readonly string[] ERList = new string[5] { "RPP_Bot_ER_I", "RPP_Bot_ER_II", "RPP_Bot_ER_III", "RPP_Bot_ER_IV", "RPP_Bot_ER_V" };
        private static readonly string[] omniList = new string[5] { "RPP_Bot_Omni_I", "RPP_Bot_Omni_II", "RPP_Bot_Omni_III", "RPP_Bot_Omni_IV", "RPP_Bot_Omni_V" };
        #endregion

        /// <summary>
        /// Settings are saved in same order as stats
        /// </summary>
        #region Robots  Settings

        #region Cleaner Compleated Settings
        private static StatDef[] cleanerStats = new StatDef[2] { StatDefOf.CleaningSpeed, StatDefOf.MarketValue };

        private readonly static float[,] cleanerDefaultSettings = new float[5, 2] {

                { 1f, 1000  },
                { 2f, 2000  },
                { 2.5f, 3500  },
                { 3f, 7000  },
                { 4f, 9000  }

        };
        private static float[,] cleanerSettings = new float[5, 2] {

                { 1f, 1000  },
                { 2f, 2000  },
                { 2.5f, 3500  },
                { 3f, 7000  },
                { 4f, 9000  }

        };

        private static bool[,] CleanerisPrecent = new bool[5, 2]
        {
            {true,false },
            {true,false },
            {true,false },
            {true,false },
            {true,false }
        };
        #endregion

        #region Crafter Compleated Match
        private static StatDef[] crafterStats = new StatDef[2] { StatDefOf.WorkSpeedGlobal, StatDefOf.MarketValue };
        // Must be saved in same order as List of Stats in float table;
        private readonly static float[,] crafterDefaultSettings = new float[5, 2] {

                { 1f,  1000  },
                { 2f,  2000  },
                { 2.5f,3500  },
                { 3f,  7000  },
                { 4f, 14000  }

        };
        private static float[,] crafterSettings = new float[5, 3] {

                { 1f,1f,  1000  },
                { 2f, 2f, 2000  },
                { 2.5f, 2.5f ,3500  },
                { 3f,  3f, 7000  },
                { 4f, 4f, 14000  }

        };
        private static bool[,] crafterIsPrecent = new bool[5, 3]
        {
            {true,true,false },
            {true,true,false },
            {true,true,false },
            {true,true,false },
            {true,true,false }
        };
        #endregion

        #region Kitchen Compleated Match

        private static StatDef[] kitchenStats = new StatDef[5] { StatDefOf.GeneralLaborSpeed, StatDefOf.PlantWorkSpeed, StatDefOf.PlantHarvestYield, StatDefOf.DrugHarvestYield, StatDefOf.MarketValue, };
        // Must be saved in same order as List of Stats in float table;
        private readonly static float[,] kitchenDefaultSettings = new float[5, 5] {

                { 1f, 1f, 1f , 1f, 4000 },
                { 2f, 2f, 1.25f , 1.25f, 8000 },
                { 2.5f, 1.5f, 1.5f , 1.5f, 12000 },
                { 3f, 3f, 1.75f , 1.75f, 18000 },
                { 4f, 4f, 2f , 2f, 30000 }
        };
        private static float[,] kitchenSettings = new float[5, 5] {

                { 1f, 1f, 1f , 1f, 4000 },
                { 2f, 2f, 1.25f , 1.25f, 8000 },
                { 2.5f, 1.5f, 1.5f , 1.5f, 12000 },
                { 3f, 3f, 1.75f , 1.75f, 18000 },
                { 4f, 4f, 2f , 2f, 30000 }
        };
        private static bool[,] kitchenIsPrecent = new bool[5, 5]
    {
            {true,true,true,true,false },
            {true,true,true,true,false },
            {true,true,true,true,false },
            {true,true,true,true,false },
            {true,true,true,true,false }
    };
        #endregion

        #region Builder Compleated Match

        private static StatDef[] builderStats = new StatDef[5] { StatDefOf.ConstructionSpeed, StatDefOf.DeepDrillingSpeed, StatDefOf.SmoothingSpeed, StatDefOf.MiningYield, StatDefOf.MarketValue, };
        // Must be saved in same order as List of Stats in float table;
        private readonly static float[,] builderDefaultSettings = new float[5, 5] {

                { 1f, 1f, 1f , 1f, 4000 },
                { 2f, 2f, 2f , 1.25f, 8000 },
                { 2.5f, 2.5f, 1.5f , 1.5f, 12000 },
                { 3f, 3f, 3f , 1.75f, 11000 },
                { 4f, 4f, 4f , 2f, 30000 }
        };
        private static float[,] builderSettings = new float[5, 5] {

                { 1f, 1f, 1f , 1f, 4000 },
                { 2f, 2f, 2f , 1.25f, 8000 },
                { 2.5f, 2.5f, 1.5f , 1.5f, 4000 },
                { 3f, 3f, 3f , 1.75f, 12000 },
                { 4f, 4f, 4f , 2f, 30000 }
        };
        private static bool[,] builderIsPrecent = new bool[5, 5]
        {
            {true,true,true,true,false },
            {true,true,true,true,false },
            {true,true,true,true,false },
            {true,true,true,true,false },
            {true,true,true,true,false }
        };
        #endregion

        #region ER Compleated Match
        private static StatDef[] ERStats = new StatDef[3] { StatDefOf.MedicalTendSpeed, StatDefOf.MedicalSurgerySuccessChance, StatDefOf.MarketValue, };

        private readonly static float[,] ERDefaultSettings = new float[5, 3] {

                { 1f, 1f, 2000  },
                { 2f, 1.25f, 4000  },
                { 2.5f, 1.5f, 8000  },
                { 3f, 1.75f, 16000  },
                { 4f, 2f, 24000  }

        };
        private  static float[,] ERSettings = new float[5, 3] {

                { 1f, 1f, 2000  },
                { 2f, 1.25f, 4000  },
                { 2.5f, 1.5f, 8000  },
                { 3f, 1.75f, 16000  },
                { 4f, 2f, 24000  }

        };


        private static bool[,] eRIsPrecent = new bool[5, 3]
        {
            {true,true,false },
            {true,true,false },
            {true,true,false },
            {true,true,false },
            {true,true,false }
        };
        #endregion

        #region Omni Compleated Match

        private static StatDef[] OmniStats = new StatDef[6] { StatDefOf.WorkSpeedGlobal,  StatDefOf.MiningYield, StatDefOf.PlantHarvestYield,  StatDefOf.MedicalSurgerySuccessChance, StatDefOf.DrugHarvestYield,  StatDefOf.MarketValue, };
        private readonly static float[,] OmniDefaultSettings = new float[5, 6] {

             {2f,  1f, 1f, 1f, 1f, 8000 },
             {3f, 1.1f, 1.1f, 1.1f, 1.1f, 15000 },
             {4f, 1.2f, 1.2f, 1.2f, .2f, 35000 },
             {5f, 1.3f, 1.3f, 1.3f,1.3f, 80000 },
             {6f, 1.4f, 1.4f, 1.4f, 1.4f, 100000 }

        };
        private static float[,] OmniSettings = new float[5, 6] {

             {2f,  1f, 1f, 1f, 1f, 8000 },
             {3f, 1.1f, 1.1f, 1.1f, 1.1f, 15000 },
             {4f, 1.2f, 1.2f, 1.2f, .2f, 35000 },
             {5f, 1.3f, 1.3f, 1.3f,1.3f, 80000 },
             {6f, 1.4f, 1.4f, 1.4f, 1.4f, 100000 }

        };
        private static bool[,] OmniPrecent = new bool[5, 6]
        {
            {true,true,true,true,true,false },
            {true,true,true,true,true,false },
            {true,true,true,true,true,false },
            {true,true,true,true,true,false },
            {true,true,true,true,true,false },
        };

        #endregion

        #endregion

        private static RobotsData cleanerData = new RobotsData(cleanerList, cleanerStats, cleanerSettings, CleanerisPrecent);
        private static RobotsData crafterData = new RobotsData(crafterList, crafterStats, crafterSettings,crafterIsPrecent);
        private static RobotsData kitchensData = new RobotsData(kitchenList, kitchenStats, kitchenDefaultSettings,kitchenIsPrecent);
        private static RobotsData buildersData = new RobotsData(buildersList, builderStats, builderSettings,builderIsPrecent);
        private static RobotsData eRData = new RobotsData(ERList, ERStats, ERSettings,eRIsPrecent);
        private static RobotsData omniData = new RobotsData(omniList, OmniStats, OmniSettings, OmniPrecent);

        #region Stations Data
        private static bool[,] GeneralStationIsPrecent = new bool[5, 2]
        {
            {false,false },
            {false,false },
            {false,false },
            {false,false },
            {false,false },
        };

        #region cleaner Stations
        private static float[,] cleanerStationSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };

        private static float[,] cleanerStationDefaultSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };
        #endregion

        #region hauler Stations
        private static float[,] haulerStationSettings = new float[5, 2]
       {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

       };


        private static float[,] haulerStationDefaultSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };
        #endregion

        #region Crafter Stations
        private static float[,] CrafterStationSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };


        private static float[,] CrafterStationDefaultSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };
        #endregion

        #region Kitchen Stations
        private static float[,] kitchenStationSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };


        private static float[,] kitchenStationDefaultSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };
        #endregion

        #region builder Stations
        private static float[,] builderStationSettings = new float[5, 2]
       {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

       };


        private static float[,] builderStationDefaultSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };
        #endregion

        #region ER Stations
        private static float[,] erStationSettings = new float[5, 2]
       {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

       };
        private static bool[,] erStationPrecent = new bool[5, 2]
        {
            {false,false },
            {false,false },
            {false,false },
            {false,false },
            {false,false },
         };

        private static float[,] erStationDefaultSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };
        #endregion

        #region Omni Stations
        private static float[,] OmniStationSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };


        private static float[,] OmniStationDefaultSettings = new float[5, 2]
        {
            {100, 1000 },
            {150f, 1000 },
            {200f, 1000 },
            {300f, 1000 },
            {400f, 1000 }

        };
        #endregion

        #endregion

        private static RobotsData cleanerStationData = new RobotsData(new string[5] { "AIRobot_RechargeStation_Cleaner", "AIRobot_RechargeStation_Cleaner_II", "AIRobot_RechargeStation_Cleaner_III", "AIRobot_RechargeStation_Cleaner_IV", "AIRobot_RechargeStation_Cleaner_V" }, new StatDef[2] { StatDefOf.MaxHitPoints, StatDefOf.MarketValue }, cleanerStationSettings, GeneralStationIsPrecent );
        private static RobotsData haulerStationData = new RobotsData(new string[5] { "AIRobot_RechargeStation_Hauler", "AIRobot_RechargeStation_Hauler_II", "AIRobot_RechargeStation_Hauler_III", "AIRobot_RechargeStation_Hauler_IV", "AIRobot_RechargeStation_Hauler_V" }, new StatDef[2] { StatDefOf.MaxHitPoints, StatDefOf.MarketValue }, haulerStationSettings,GeneralStationIsPrecent);
        private static RobotsData crafterStationData = new RobotsData(new string[5] { "RPP_RechargeStation_Crafter_I", "RPP_RechargeStation_Crafter_II", "RPP_RechargeStation_Crafter_III", "RPP_RechargeStation_Crafter_IV", "RPP_RechargeStation_Crafter_V" }, new StatDef[2] { StatDefOf.MaxHitPoints, StatDefOf.MarketValue }, CrafterStationSettings, GeneralStationIsPrecent);
        private static RobotsData builderStationData = new RobotsData(new string[5] { "RPP_RechargeStation_Builder_I", "RPP_RechargeStation_Builder_II", "RPP_RechargeStation_Builder_III", "RPP_RechargeStation_Builder_IV", "RPP_RechargeStation_Builder_V" }, new StatDef[2] { StatDefOf.MaxHitPoints, StatDefOf.MarketValue }, builderStationSettings, GeneralStationIsPrecent);
        private static RobotsData erStationData = new RobotsData(new string[5] { "RPP_RechargeStation_ER_I", "RPP_RechargeStation_ER_II", "RPP_RechargeStation_ER_III", "RPP_RechargeStation_ER_IV", "RPP_RechargeStation_ER_V" }, new StatDef[2] { StatDefOf.MaxHitPoints, StatDefOf.MarketValue }, erStationSettings, GeneralStationIsPrecent);
        private static RobotsData kitchenStationData = new RobotsData(new string[5] { "RPP_RechargeStation_Kitchen_I", "RPP_RechargeStation_Kitchen_II", "RPP_RechargeStation_Kitchen_III", "RPP_RechargeStation_Kitchen_IV", "RPP_RechargeStation_Kitchen_V" }, new StatDef[2] { StatDefOf.MaxHitPoints, StatDefOf.MarketValue }, kitchenStationSettings, GeneralStationIsPrecent);
        private static RobotsData omniStationData = new RobotsData(new string[5] { "RPP_RechargeStation_Omni_I", "RPP_RechargeStation_Omni_II", "RPP_RechargeStation_Omni_III", "RPP_RechargeStation_Omni_IV", "RPP_RechargeStation_Omni_V" }, new StatDef[2] { StatDefOf.MaxHitPoints, StatDefOf.MarketValue }, OmniStationSettings, GeneralStationIsPrecent);


        public override void ExposeData()
        {
            //Stored in XML config file
            base.ExposeData();
            //Robots Settings
            ExposeValues(cleanerData);
            ExposeValues(buildersData);
            ExposeValues(crafterData);
            ExposeValues(kitchensData);
            ExposeValues(eRData);
            ExposeValues(omniData);


            // Robots Stations Settings
            ExposeValues(cleanerStationData);
            ExposeValues(haulerStationData);
            ExposeValues(erStationData);
            ExposeValues(crafterStationData);
            ExposeValues(builderStationData);
            ExposeValues(omniStationData);
        }
        public static void WriteSettings()
        {
            //Robots Settings
            WriteStatSettings(cleanerData);
            WriteStatSettings(crafterData);
            WriteStatSettings(buildersData);
            WriteStatSettings(kitchensData);
            WriteStatSettings(eRData);
            WriteStatSettings(omniData);


            // Robots Stations Settings
            WriteStatSettings(cleanerStationData);
            WriteStatSettings(haulerStationData);
            WriteStatSettings(erStationData);
            WriteStatSettings(crafterStationData);
            WriteStatSettings(builderStationData);
            WriteStatSettings(omniStationData);
        }



        public static List<ThingDef> database;


        public static void ExposeValues(RobotsData data)
        {
            for (int i = 0; i < data.defThing.Length; i++)
            {
                for (int x = 0; x < data.statsData.Length; x++)
                {
                    Scribe_Values.Look(ref data.settingsValue[i, x], data.defThing[i] + "_" + data.statsData[x].defName, data.defaultValues[i, x]);
                }
            }
        }

        private static void WriteStatSettings(RobotsData data)
        {
            StatModifier statModifier = null;
            for (int i = 0; i < data.defThing.Length; i++)
            {
                for (int x = 0; x < data.statsData.Length; x++)
                {
                    foreach (var pawnStat in DefDatabase<ThingDef>.GetNamed(data.defThing[i]).statBases)
                    {
                        if (pawnStat.stat == data.statsData[x])
                        {
                            statModifier = pawnStat;
                            break; //Break For each
                        }
                    }
                    if (statModifier != null)
                    {
                        statModifier.value = data.settingsValue[i, x];
                    }
                }
            }
        }

        /// <summary>
        /// Drawing SettingsGUI
        /// </summary>
        public static void DoOptionsCategoryContents(Listing_Standard listing_Standard)
        {
            listing_Standard.DropDownSettings("Current Page".Translate(), "", currentPage, listing_Standard.ColumnWidth);
            listing_Standard.GapLine();
            switch (currentPage)
            {
                case SettingsPages.Robots_Tweaks:
                    RobotsSettings(listing_Standard);
                    break;
                case SettingsPages.Station_Tweaks:
                    RobotsStationSettings(listing_Standard);
                    break;
                default:
                    break;
            }
        }
        private static void RobotsSettings(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("These settings apply runtime");
            
            listing_Standard.CheckboxLabeled("Cleaner_Settings".Translate(), ref cleanerTweaks);
            if (cleanerTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, cleanerData);      
            }
            listing_Standard.CheckboxLabeled("Crafter_Settings".Translate(), ref crafterTweaks);
            if (crafterTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, crafterData);
            }
            listing_Standard.CheckboxLabeled("Builder_Settings".Translate(), ref builderTweaks);
            if (builderTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, buildersData);
            }

            listing_Standard.CheckboxLabeled("Kitchen_Settings".Translate(), ref kitchenTweaks);
            if (kitchenTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, kitchensData);
            }

            listing_Standard.CheckboxLabeled("ER_Settings".Translate(), ref eRTweaks);
            if (eRTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, eRData);
            }

            listing_Standard.CheckboxLabeled("Omni_Settings".Translate(), ref omniTweaks);
            if (omniTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, omniData);
            }


        }

        private static void RobotsStationSettings(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("These settings apply After Reset");

            listing_Standard.CheckboxLabeled("Cleaner_Station_Settings".Translate(), ref cleanerStationTweaks);
            if (cleanerStationTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, cleanerStationData);

            }
            //listing_Standard.CheckboxLabeled("Hauler_Station_Settings".Translate(), ref haulerStationTweaks);
            if (haulerStationTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, haulerStationData);

            }
            listing_Standard.CheckboxLabeled("Crafter_Station_Settings".Translate(), ref crafterStationTweaks);
            if (crafterStationTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, crafterStationData);
            }
            listing_Standard.CheckboxLabeled("Builder_Station_Settings".Translate(), ref builderStationTweaks);
            if (builderStationTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, builderStationData);
            }

            listing_Standard.CheckboxLabeled("Kitchen_Station_Settings".Translate(), ref kitchenStationTweaks);
            if (kitchenStationTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, kitchenStationData);
            }

            listing_Standard.CheckboxLabeled("ER_Station_Settings".Translate(), ref eRStationweaks);
            if (eRStationweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, erStationData);
            }

            listing_Standard.CheckboxLabeled("Omni_Station_Settings".Translate(), ref omniStationTweaks);
            if (omniStationTweaks == true)
            {
                RobotsData.DrawingSettings(listing_Standard, omniStationData);
            }


        }
    }
}

public enum SettingsPages
{
    Robots_Tweaks,
    Station_Tweaks,
    Others_Tweaks
}