using HarmonyLib;
using RimWorld;
using System.Reflection;
using UnityEngine;
using Verse;

namespace MiscRobotsPlusPlus
{
    [StaticConstructorOnStartup]
    public class MiscRobotsPlusPlusMod : Mod
    {
        static MiscRobotsPlusPlusMod()
        {
            var har = new Harmony("MiscRobotsPlusPlus");
            har.PatchAll(Assembly.GetExecutingAssembly());
        }

        public MiscRobotsPlusPlusMod(ModContentPack content) : base(content)
        {
            LongEventHandler.ExecuteWhenFinished(GetSettings);
            LongEventHandler.ExecuteWhenFinished(PushDatabase);
        }
        private void PushDatabase()
        {
            MiscPlusPlusSettings.database = DefDatabase<ThingDef>.AllDefsListForReading;
        }
        public override void WriteSettings()
        {
            base.WriteSettings();
            MiscPlusPlusSettings.WriteSettings();

        }
        public override string SettingsCategory()
        {
            return "MISC_Robots_Category".Translate();
        }
        float optionsViewRectHeight;
        Vector2 optionsScrollPosition;
        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            bool flag = optionsViewRectHeight > inRect.height;
            Rect viewRect = new Rect(inRect.x, inRect.y, inRect.width - (flag ? 26f : 0f), optionsViewRectHeight);
            Widgets.BeginScrollView(inRect, ref optionsScrollPosition, viewRect);
            Listing_Standard listing_Standard = new Listing_Standard();
            Rect rect = new Rect(viewRect.x, viewRect.y, viewRect.width, 999999f);
            listing_Standard.Begin(rect);
            MiscPlusPlusSettings.DoOptionsCategoryContents(listing_Standard);
            optionsViewRectHeight = listing_Standard.CurHeight;
            listing_Standard.End();
            Widgets.EndScrollView();
        }
        void GetSettings()
        {
            GetSettings<MiscPlusPlusSettings>();
        }
       
    }
}