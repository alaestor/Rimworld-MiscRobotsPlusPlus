using HarmonyLib;
using MiscRobotsPlusPlus.Patches;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices.ComTypes;
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
            //ApplySettings(MiscModsSettings.cleanerList, MiscModsSettings.cleanerStats, MiscModsSettings.cleanerDefaultSettings);
            //ApplySettings(MiscModsSettings.crafterList, MiscModsSettings.crafterStats, MiscModsSettings.crafterDefaultSettings);
            //ApplySettings(MiscModsSettings.buildersList, MiscModsSettings.builderStats, MiscModsSettings.builderDefaultSettings);
            //ApplySettings(MiscModsSettings.kitchenList, MiscModsSettings.kitchenStats, MiscModsSettings.kitchenDefaultSettings);
            //ApplySettings(MiscModsSettings.ERList, MiscModsSettings.ERStats, MiscModsSettings.ERDefaultSettings);
            //ApplySettings(MiscModsSettings.omniList, MiscModsSettings.OmniStats,MiscModsSettings.OmniDefaultSettings);
        }
        #endregion

        public override string SettingsCategory()
        {
            return "MISC_Robots_Category".Translate();
        }
        private bool cleanerSettings = false;
        private bool craftersSettings = false;
        private bool builderSettings = false;
        private bool kitchenSettings = false;
        private bool eRSettings = false;
        private bool omniSettings = false;


        Vector2 scrollPos;
        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            Listing_Standard guiStandard = new Listing_Standard();
            guiStandard.Begin(inRect);
            {
                guiStandard.Label("MISC_WIP".Translate());
                guiStandard.Label("W".Translate());
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

                        guiStandard.CheckboxLabeled("Cleaner_Settings".Translate(), ref cleanerSettings);
                        if (cleanerSettings)
                        {
                            DrawingSettings(guiStandard, MiscModsSettings.cleanerData, 0.01f, 100f);
                        }
                        guiStandard.CheckboxLabeled("Builder_Settings".Translate(), ref builderSettings);
                        if (builderSettings)
                        {
                            DrawingSettings(guiStandard, MiscModsSettings.buildersData,0.01f, 100);
                        }
                        guiStandard.CheckboxLabeled("Crafter_Settings".Translate(), ref craftersSettings);
                        if (craftersSettings)
                        {
                            DrawingSettings(guiStandard, MiscModsSettings.crafterData, 0.01f, 100);
                        }
                        guiStandard.CheckboxLabeled("Kitcen_Settings".Translate(), ref kitchenSettings);
                        if (kitchenSettings)
                        {
                            DrawingSettings(guiStandard, MiscModsSettings.kitchensData, 0.01f, 100);
                        }
                        guiStandard.CheckboxLabeled("ER_Settings".Translate(), ref eRSettings);
                        if (eRSettings)
                        {
                            DrawingSettings(guiStandard, MiscModsSettings.eRData, 0.01f, 100);
                        }
                        guiStandard.CheckboxLabeled("Omni_Settings".Translate(), ref omniSettings);
                        if (omniSettings)
                        {
                            DrawingSettings(guiStandard, MiscModsSettings.omniData, 0.01f, 100);
                        }

                    }
                    guiStandard.End();
                }
                Widgets.EndScrollView();
            }
            guiStandard.End();
        }
        public static void DrawingSettings(Listing_Standard listing, RobotsData data, float min, float max)
        {
            for (int i = 0; i < data.defThing.Length; i++)
            {
                listing.Label(data.defThing[i].Translate());
                for (int x = 0; x < data.statsData.Length; x++)
                {
                    listing.Label((data.statsData[x].defName + data.defThing[i] + "_" + i).Translate(data.settingsValue[i, x]));
                    listing.Slider(data.settingsValue[i, x], min, max);
                }
            }
            //RobotsData.SetBuffers(data);
        }
        void GetSettings()
        {
            GetSettings<MiscModsSettings>();
        }
        private void ApplySettings(string[] thingDefs, StatDef[] stat,float[,] setting)
        {
            StatModifier[,] statModifier = new StatModifier[thingDefs.Length,stat.Length];
            for (int i = 0; i < thingDefs.Length; i++)
            {
                for (int x = 0; x < stat.Length; x++)
                {
                    foreach (var pawnStat in DefDatabase<ThingDef>.GetNamed(thingDefs[i]).statBases)
                    {
                        if (pawnStat.stat == stat[x])
                        {
                            statModifier[i, x] = pawnStat;
                            break;
                        }
                    }
                    if (statModifier != null)
                    {
                        statModifier[i, x].value = setting[i, x];
                    }
                }          
            }
        }
    }
}




