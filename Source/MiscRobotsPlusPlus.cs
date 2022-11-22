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
        public override void WriteSettings()
        {
            base.WriteSettings();
            
        } 
        public override string SettingsCategory()
        {
            return "MISC_Robots_Category".Translate();
        }
        #region Settings for gui in Mod Options
        bool cleanerSettings = false;
        bool haulerSettings = false;
        bool craftersSettings = false;
        bool buildersSettings = false;
        bool kitchensSettings = false;
        bool omniSettings = false;
        #endregion
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard guiStandard = new Listing_Standard() 
            {
                ColumnWidth = inRect.width
            };

            guiStandard.Begin(inRect);
            guiStandard.Label("MISC_WIP".Translate());

            Rect rec1 = guiStandard.GetRect(Text.LineHeight);
            Rect lef1 = rec1.LeftHalf().Rounded();
            Rect right1 = rec1.RightHalf().Rounded();
            Widgets.CheckboxLabeled(lef1, "MISC_Cleaning_Settings".Translate(), ref cleanerSettings);
            if(cleanerSettings)
            {
                guiStandard.BeginSection(125);
                Widgets.Label(new Rect(lef1.xMin,lef1.y,lef1.width,lef1.height), "MISC_CleaningTeir_I_Speed".Translate(MiscModsSettings.tier_1_CleaningSpeed * 100));
                MiscModsSettings.tier_1_CleaningSpeed = Widgets.HorizontalSlider(new Rect(right1.xMin + right1.height + 10f, right1.y, right1.width - (right1.height * 2f + 20f), right1.height), MiscModsSettings.tier_1_CleaningSpeed, 0.1f, 15f, true);
                guiStandard.Gap(1);
                Widgets.Label(new Rect(lef1.xMin, lef1.y + 20, lef1.width, lef1.height), "MISC_CleaningTeir_II_Speed".Translate(MiscModsSettings.tier_2_CleaningSpeed * 100));
                MiscModsSettings.tier_2_CleaningSpeed = Widgets.HorizontalSlider(new Rect(right1.xMin + right1.height + 10f, right1.y  +20, right1.width - (right1.height * 2f + 20f), right1.height), MiscModsSettings.tier_2_CleaningSpeed, 0.1f, 15f, true);
                guiStandard.Gap(1);
                Widgets.Label(new Rect(lef1.xMin, lef1.y + 40, lef1.width, lef1.height), "MISC_CleaningTeir_III_Speed".Translate(MiscModsSettings.tier_3_CleaningSpeed * 100));
                MiscModsSettings.tier_3_CleaningSpeed = Widgets.HorizontalSlider(new Rect(right1.xMin + right1.height + 10f, right1.y + 40, right1.width - (right1.height * 2f + 20f), right1.height), MiscModsSettings.tier_3_CleaningSpeed, 0.1f, 15f, true);
                guiStandard.Gap(1);
                Widgets.Label(new Rect(lef1.xMin, lef1.y + 60, lef1.width, lef1.height), "MISC_CleaningTeir_VI_Speed".Translate(MiscModsSettings.tier_4_CleaningSpeed * 100));
                MiscModsSettings.tier_4_CleaningSpeed = Widgets.HorizontalSlider(new Rect(right1.xMin + right1.height + 10f, right1.y + 60, right1.width - (right1.height * 2f + 20f), right1.height), MiscModsSettings.tier_4_CleaningSpeed, 0.1f, 15f, true);
                guiStandard.Gap(1);
                Widgets.Label(new Rect(lef1.xMin, lef1.y + 80, lef1.width, lef1.height), "MISC_CleaningTeir_V_Speed".Translate(MiscModsSettings.tier_5_CleaningSpeed * 100));
                MiscModsSettings.tier_5_CleaningSpeed = Widgets.HorizontalSlider(new Rect(right1.xMin + right1.height + 10f, right1.y + 80, right1.width - (right1.height * 2f + 20f), right1.height), MiscModsSettings.tier_5_CleaningSpeed, 0.1f, 15f, true);
                guiStandard.EndSection(guiStandard);
            }
            Rect rec2 = guiStandard.GetRect(Text.LineHeight);
            Rect left2 = rec2.LeftHalf().Rounded();
            Rect right2 = rec2.RightHalf().Rounded();
            Widgets.CheckboxLabeled(left2, "MISC_Crafters_Settings".Translate(), ref craftersSettings);
            if (craftersSettings)
            {
                guiStandard.BeginSection(125);
                Widgets.Label(new Rect(left2.xMin, left2.y, left2.width, left2.height), "MISC_CrafterLaborTeir_I_Speed".Translate(MiscModsSettings.tier_1_CrafterLaborSpeed * 100));
                MiscModsSettings.tier_1_CrafterLaborSpeed = Widgets.HorizontalSlider(new Rect(right2.xMin + right2.height + 10f, right2.y, right2.width - (right2.height * 2f + 20f), right2.height), MiscModsSettings.tier_1_CrafterLaborSpeed, 0.1f, 15f, true);
                guiStandard.Gap(1);
                Widgets.Label(new Rect(left2.xMin, left2.y + 20, left2.width, left2.height), "MISC_CrafterLaborTeir_II_Speed".Translate(MiscModsSettings.tier_2_CrafterLaborSpeed * 100));
                MiscModsSettings.tier_2_CrafterLaborSpeed = Widgets.HorizontalSlider(new Rect(right2.xMin + right2.height + 10f, right2.y + 20, right2.width - (right2.height * 2f + 20f), right2.height), MiscModsSettings.tier_2_CrafterLaborSpeed, 0.1f, 15f, true);
                guiStandard.Gap(1);
                Widgets.Label(new Rect(left2.xMin, left2.y + 40, left2.width, left2.height), "MISC_CrafterLaborTeir_III_Speed".Translate(MiscModsSettings.tier_3_CrafterLaborSpeed * 100));
                MiscModsSettings.tier_3_CrafterLaborSpeed = Widgets.HorizontalSlider(new Rect(right2.xMin + right2.height + 10f, right2.y + 40, right2.width - (right2.height * 2f + 20f), right2.height), MiscModsSettings.tier_3_CrafterLaborSpeed, 0.1f, 15f, true);
                guiStandard.Gap(1);
                Widgets.Label(new Rect(left2.xMin, left2.y + 60, left2.width, left2.height), "MISC_CrafterLaborTeir_IV_Speed".Translate(MiscModsSettings.tier_4_CrafterLaborSpeed * 100));
                MiscModsSettings.tier_4_CrafterLaborSpeed = Widgets.HorizontalSlider(new Rect(right2.xMin + right2.height + 10f, right2.y + 60, right2.width - (right2.height * 2f + 20f), right2.height), MiscModsSettings.tier_4_CrafterLaborSpeed, 0.1f, 15f, true);
                guiStandard.Gap(1);
                Widgets.Label(new Rect(left2.xMin, left2.y + 80, left2.width, lef1.height), "MISC_CrafterLaborTeir_V_Speed".Translate(MiscModsSettings.tier_5_CrafterLaborSpeed * 100));
                MiscModsSettings.tier_5_CrafterLaborSpeed = Widgets.HorizontalSlider(new Rect(right2.xMin + right2.height + 10f, right2.y + 80, right2.width - (right2.height * 2f + 20f), right2.height), MiscModsSettings.tier_5_CrafterLaborSpeed, 0.1f, 15f, true);
                guiStandard.EndSection(guiStandard);
            }
                guiStandard.End();

            base.DoSettingsWindowContents(inRect);
        }
        void GetSettings()
        {
            GetSettings<MiscModsSettings>();
        }

    }
}
