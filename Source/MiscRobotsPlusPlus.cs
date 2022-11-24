using HarmonyLib;
using MiscRobotsPlusPlus.Patches;
using RimWorld;
using System.Linq;
using System.Reflection;
using System.Runtime;
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
        private bool eRSettings = false;
        private bool cleanerSettings = false;
        private bool craftersSettings = false;
        private bool kitchenSettings = false;
        private bool BuilderSettings = false;
        private Vector2 crafterPos;
        float RemainingHeight;
        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            Rect outRect;
            Listing_Standard guiStandard = new Listing_Standard();
            guiStandard.Begin(inRect);
            {
                guiStandard.Label("MISC_WIP".Translate());
                guiStandard.GapLine();
                guiStandard.CheckboxLabeled("MISC_Crafters_Settings".Translate(), ref craftersSettings);

                RemainingHeight = inRect.height - guiStandard.CurHeight;
                outRect = guiStandard.GetRect(RemainingHeight);
                Rect viewRect = new Rect(outRect)
                {
                    width = inRect.width - 16,
                    height = guiStandard.CurHeight * 6
                };
               
                Widgets.BeginScrollView(outRect, ref crafterPos, viewRect);
                {
                    guiStandard.Begin(viewRect);
                    {
                        guiStandard.BeginSection(35);
                        if (craftersSettings)
                        {
                            guiStandard.Label("MISC_CrafterLaborTeir_I_Speed".Translate(MiscModsSettings.tier_1_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_1_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_1_CrafterLaborSpeed, 0.1f, 15f);
                            guiStandard.GapLine();
                            guiStandard.Label("MISC_CrafterLaborTeir_II_Speed".Translate(MiscModsSettings.tier_2_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_2_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_2_CrafterLaborSpeed, 0.1f, 15);
                            guiStandard.GapLine();
                            guiStandard.Label("MISC_CrafterLaborTeir_III_Speed".Translate(MiscModsSettings.tier_3_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_3_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_3_CrafterLaborSpeed, 0.1f, 15f);
                            guiStandard.GapLine();
                            guiStandard.Label("MISC_CrafterLaborTeir_IV_Speed".Translate(MiscModsSettings.tier_4_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_4_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_4_CrafterLaborSpeed, 0.1f, 15f);
                            guiStandard.GapLine();
                            guiStandard.Label("MISC_CrafterLaborTeir_V_Speed".Translate(MiscModsSettings.tier_5_CrafterLaborSpeed * 100));
                            MiscModsSettings.tier_5_CrafterLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_5_CrafterLaborSpeed, 0.1f, 15f);
                        }
                        guiStandard.EndSection(guiStandard);
                    }
                    guiStandard.End();
                }
                Widgets.EndScrollView();
                Rect out2 = guiStandard.GetRect(outRect.height);
                Vector2 view2Pos = craftersSettings ? Vector2.zero : new Vector2(outRect.x, outRect.y - out2.y);
                Rect view2 = new Rect(out2.x, out2.y - outRect.y, viewRect.width - 16, out2.width);
                guiStandard.CheckboxLabeled("MISC_Cleaning_Settings".Translate(), ref cleanerSettings);
                Widgets.BeginScrollView(out2, ref view2Pos, view2);
                {
                    guiStandard.Begin(viewRect);
                    {
                        if (cleanerSettings)
                        {
                            guiStandard.Label("MISC_CleaningTeir_I_Speed".Translate(MiscModsSettings.tier_1_CleaningSpeed * 100));
                            MiscModsSettings.tier_1_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_1_CleaningSpeed, 0.1f, 15f);
                            guiStandard.GapLine();
                            guiStandard.Label("MISC_CleaningTeir_II_Speed".Translate(MiscModsSettings.tier_2_CleaningSpeed * 100));
                            MiscModsSettings.tier_2_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_2_CleaningSpeed, 0.1f, 15f);
                            guiStandard.GapLine();
                            guiStandard.Label("MISC_CleaningTeir_III_Speed".Translate(MiscModsSettings.tier_3_CleaningSpeed * 100));
                            MiscModsSettings.tier_3_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_3_CleaningSpeed, 0.1f, 15f);
                            guiStandard.GapLine();
                            guiStandard.Label("MISC_CleaningTeir_IV_Speed".Translate(MiscModsSettings.tier_4_CleaningSpeed * 100));
                            MiscModsSettings.tier_4_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_4_CleaningSpeed, 0.1f, 15f);
                            guiStandard.GapLine();
                            guiStandard.Label("MISC_CleaningTeir_V_Speed".Translate(MiscModsSettings.tier_5_CleaningSpeed * 100));
                            MiscModsSettings.tier_5_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_5_CleaningSpeed, 0.1f, 15f);
                        }
                    }
                    guiStandard.End();
                    Widgets.EndScrollView();
                };
                guiStandard.End();

            }
        }

            //guiStandard.CheckboxLabeled("MISC_Cleaning_Settings".Translate(), ref cleanerSettings);
            //if (cleanerSettings)
            //{
            //    guiStandard.Label("MISC_CleaningTeir_I_Speed".Translate(MiscModsSettings.tier_1_CleaningSpeed * 100));
            //    MiscModsSettings.tier_1_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_1_CleaningSpeed, 0.1f, 15f);
            //    guiStandard.GapLine();
            //    guiStandard.Label("MISC_CleaningTeir_II_Speed".Translate(MiscModsSettings.tier_2_CleaningSpeed * 100));
            //    MiscModsSettings.tier_2_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_2_CleaningSpeed, 0.1f, 15f);
            //    guiStandard.GapLine();
            //    guiStandard.Label("MISC_CleaningTeir_III_Speed".Translate(MiscModsSettings.tier_3_CleaningSpeed * 100));
            //    MiscModsSettings.tier_3_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_3_CleaningSpeed, 0.1f, 15f);
            //    guiStandard.GapLine();
            //    guiStandard.Label("MISC_CleaningTeir_IV_Speed".Translate(MiscModsSettings.tier_4_CleaningSpeed * 100));
            //    MiscModsSettings.tier_4_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_4_CleaningSpeed, 0.1f, 15f);
            //    guiStandard.GapLine();
            //    guiStandard.Label("MISC_CleaningTeir_V_Speed".Translate(MiscModsSettings.tier_5_CleaningSpeed * 100));
            //    MiscModsSettings.tier_5_CleaningSpeed = guiStandard.Slider(MiscModsSettings.tier_5_CleaningSpeed, 0.1f, 15f);
            //}
            //guiStandard.CheckboxLabeled("MISC_ER_Settings".Translate(), ref eRSettings);
            //if (eRSettings)
            //{
            //    guiStandard.Label("MISC_ER_TendSpeed_I".Translate(MiscModsSettings.tier_1_ERTendingLaborSpeed * 100));
            //    MiscModsSettings.tier_1_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_1_ERTendingLaborSpeed, 0.1f, 15f);
            //    guiStandard.Label("MISC_ER_SurgerySucces_I".Translate(MiscModsSettings.tier_2_ERMedicalSurgerySuccessChance * 100));
            //    MiscModsSettings.tier_1_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_1_ERMedicalSurgerySuccessChance, 0.1f, 15f);

            //    guiStandard.GapLine();

            //    guiStandard.Label("MISC_ER_TendSpeed_II".Translate(MiscModsSettings.tier_2_ERTendingLaborSpeed * 100));
            //    MiscModsSettings.tier_2_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_2_ERTendingLaborSpeed, 0.1f, 15f);
            //    guiStandard.Label("MISC_ER_SurgerySucces_II".Translate(MiscModsSettings.tier_2_ERMedicalSurgerySuccessChance * 100));
            //    MiscModsSettings.tier_2_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_2_ERMedicalSurgerySuccessChance, 0.1f, 15f);

            //    guiStandard.GapLine();

            //    guiStandard.Label("MISC_ER_TendSpeed_III".Translate(MiscModsSettings.tier_3_ERTendingLaborSpeed * 100));
            //    MiscModsSettings.tier_3_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_3_ERTendingLaborSpeed, 0.1f, 15f);
            //    guiStandard.Label("MISC_ER_SurgerySucces_III".Translate(MiscModsSettings.tier_3_ERMedicalSurgerySuccessChance * 100));
            //    MiscModsSettings.tier_3_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_3_ERMedicalSurgerySuccessChance, 0.1f, 15f);

            //    guiStandard.GapLine();

            //    guiStandard.Label("MISC_ER_TendSpeed_IV".Translate(MiscModsSettings.tier_4_ERTendingLaborSpeed * 100));
            //    MiscModsSettings.tier_4_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_4_ERTendingLaborSpeed, 0.1f, 15f);
            //    guiStandard.Label("MISC_ER_SurgerySucces_IV".Translate(MiscModsSettings.tier_4_ERMedicalSurgerySuccessChance * 100));
            //    MiscModsSettings.tier_4_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_4_ERMedicalSurgerySuccessChance, 0.1f, 15f);

            //    guiStandard.GapLine();

            //    guiStandard.Label("MISC_ER_TendSpeed_V".Translate(MiscModsSettings.tier_5_ERTendingLaborSpeed * 100));
            //    MiscModsSettings.tier_5_ERTendingLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_5_ERTendingLaborSpeed, 0.1f, 15f);
            //    guiStandard.Label("MISC_ER_SurgerySucces_V".Translate(MiscModsSettings.tier_5_ERMedicalSurgerySuccessChance * 100));
            //    MiscModsSettings.tier_5_ERMedicalSurgerySuccessChance = guiStandard.Slider(MiscModsSettings.tier_5_ERMedicalSurgerySuccessChance, 0.1f, 15f);

            //}
            //guiStandard.CheckboxLabeled("MISC_Kitchen_Settings".Translate(), ref kitchenSettings);
            //if (kitchenSettings)
            //{
            //    Widgets.BeginScrollView(outRect, ref crafterPos, viewRect);
            //    guiStandard.Label("MISC_Kitchen_GeneralLabor_I".Translate(MiscModsSettings.tier_1_KitchenGeneralLaborSpeed * 100));
            //     MiscModsSettings.tier_1_KitchenGeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_1_KitchenGeneralLaborSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_I".Translate(MiscModsSettings.tier_1_KitchenPlantWorkSpeed * 100));
            //    MiscModsSettings.tier_1_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_1_KitchenPlantWorkSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantHarvestYield_I".Translate(MiscModsSettings.tier_1_KitchenPlantHarvestYield * 100));
            //    MiscModsSettings.tier_1_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_KitchenPlantHarvestYield, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_DrugHarvestYield_I".Translate(MiscModsSettings.tier_1_KitchenDrugHarvestYield * 100));
            //    MiscModsSettings.tier_1_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_KitchenDrugHarvestYield, 0.1f, 15f);

            //    guiStandard.GapLine();

            //    guiStandard.Label("MISC_Kitchen_GeneralLabor_II".Translate(MiscModsSettings.tier_2_KitchenGeneralLaborSpeed * 100));
            //    MiscModsSettings.tier_2_KitchenGeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_2_KitchenGeneralLaborSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_II".Translate(MiscModsSettings.tier_2_KitchenPlantWorkSpeed * 100));
            //    MiscModsSettings.tier_2_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_2_KitchenPlantWorkSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantHarvestYield_II".Translate(MiscModsSettings.tier_2_KitchenPlantHarvestYield * 100));
            //    MiscModsSettings.tier_2_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_KitchenPlantHarvestYield, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_DrugHarvestYield_II".Translate(MiscModsSettings.tier_2_KitchenDrugHarvestYield * 100));
            //    MiscModsSettings.tier_2_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_2_KitchenDrugHarvestYield, 0.1f, 15f);


            //    guiStandard.GapLine();

            //    guiStandard.Label("MISC_Kitchen_GeneralLabor_III".Translate(MiscModsSettings.tier_3_KitchenGeneralLaborSpeed * 100));
            //    MiscModsSettings.tier_3_KitchenGeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_3_KitchenGeneralLaborSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_III".Translate(MiscModsSettings.tier_3_KitchenPlantWorkSpeed * 100));
            //    MiscModsSettings.tier_3_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_3_KitchenPlantWorkSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantHarvestYield_III".Translate(MiscModsSettings.tier_3_KitchenPlantHarvestYield * 100));
            //    MiscModsSettings.tier_3_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_KitchenPlantHarvestYield, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_DrugHarvestYield_III".Translate(MiscModsSettings.tier_3_KitchenDrugHarvestYield * 100));
            //    MiscModsSettings.tier_3_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_2_KitchenDrugHarvestYield, 0.1f, 15f);

            //    guiStandard.GapLine();

            //    guiStandard.Label("MISC_Kitchen_GeneralLabor_IV".Translate(MiscModsSettings.tier_4_KitchenGeneralLaborSpeed * 100));
            //    MiscModsSettings.tier_4_KitchenGeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_4_KitchenGeneralLaborSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_IV".Translate(MiscModsSettings.tier_4_KitchenPlantWorkSpeed * 100));
            //    MiscModsSettings.tier_4_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_4_KitchenPlantWorkSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantHarvestYield_IV".Translate(MiscModsSettings.tier_4_KitchenPlantHarvestYield * 100));
            //    MiscModsSettings.tier_4_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_KitchenPlantHarvestYield, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_DrugHarvestYield_IV".Translate(MiscModsSettings.tier_4_KitchenDrugHarvestYield * 100));
            //    MiscModsSettings.tier_4_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_2_KitchenDrugHarvestYield, 0.1f, 15f);

            //    guiStandard.GapLine();

            //    guiStandard.Label("MISC_Kitchen_GeneralLabor_V".Translate(MiscModsSettings.tier_5_KitchenGeneralLaborSpeed * 100));
            //    MiscModsSettings.tier_5_KitchenGeneralLaborSpeed = guiStandard.Slider(MiscModsSettings.tier_5_KitchenGeneralLaborSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantWorkSpeed_V".Translate(MiscModsSettings.tier_5_KitchenPlantWorkSpeed * 100));
            //    MiscModsSettings.tier_5_KitchenPlantWorkSpeed = guiStandard.Slider(MiscModsSettings.tier_5_KitchenPlantWorkSpeed, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_PlantHarvestYield_V".Translate(MiscModsSettings.tier_5_KitchenPlantHarvestYield * 100));
            //    MiscModsSettings.tier_5_KitchenPlantHarvestYield = guiStandard.Slider(MiscModsSettings.tier_1_KitchenPlantHarvestYield, 0.1f, 15f);

            //    guiStandard.Label("MISC_Kitchen_DrugHarvestYield_V".Translate(MiscModsSettings.tier_5_KitchenDrugHarvestYield * 100));
            //    MiscModsSettings.tier_5_KitchenDrugHarvestYield = guiStandard.Slider(MiscModsSettings.tier_2_KitchenDrugHarvestYield, 0.1f, 15f);

            //    Widgets.EndScrollView();
            //}






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
