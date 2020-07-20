using RimWorld;
using Verse;

namespace MiscRobotsPlusPlus.GUITweaks
{
    public static class ClassInjector
    {
        public static void Init()
        {
            UITweaks();
        }

        private static void UITweaks()
        {
            // Replace robots window with tabbed version
            var robotsTab = DefDatabase<MainButtonDef>.GetNamed("AIRobots");
            MainTabWindow_MiscRobotsPlusPlus_Tweak.MainTabWindowType = robotsTab.tabWindowClass;
            robotsTab.tabWindowClass = typeof(MainTabWindow_MiscRobotsPlusPlus_Tweak);
        }
    }
}
