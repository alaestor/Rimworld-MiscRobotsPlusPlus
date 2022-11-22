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
            return "MiscRobots";
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard guiStandard = new Listing_Standard() 
            {
                ColumnWidth = inRect.width
            };
 
            guiStandard.Begin(inRect);
            guiStandard.Label("MISC_WIP" );
            guiStandard.Label("MISC_GlobalTeirs");
            guiStandard.Label("MISC_Tier1"); 
            Rect rect = guiStandard.GetRect(Text.LineHeight);
            Rect rect2 = rect.LeftHalf().Rounded();
            Rect rect3 = rect.RightHalf().Rounded();

            //Builders
            
           
            //Add Ability To translat later
       
            
            guiStandard.End();

            base.DoSettingsWindowContents(inRect);
        }
        void GetSettings()
        {
            GetSettings<MiscModsSettings>();
        }

    }
}
