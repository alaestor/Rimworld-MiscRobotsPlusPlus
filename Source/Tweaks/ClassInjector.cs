using RimWorld;
using Verse;

namespace MiscRobotsPlusPlus.Tweaks
{
    public static class ClassInjector
    {
        public static void Init()
        {
            UITweaks();
        }

        private static void UITweaks()
        {
            // Replace work tab with custom one
            var workTab = DefDatabase<MainButtonDef>.GetNamed("Work");
            MainTabWindow_Work_Tweak.MainTabWindowType = workTab.tabWindowClass;
            workTab.tabWindowClass = typeof(MainTabWindow_Work_Tweak);

            /*// Replace assign tab with custom one
            var assignTab = DefDatabase<MainButtonDef>.GetNamed("Restrict");
            MainTabWindow_Restrict_Tweak.MainTabWindowType = assignTab.tabWindowClass;
            assignTab.tabWindowClass = typeof(MainTabWindow_Restrict_Tweak);*/
        }
    }
}
