using HarmonyLib;

namespace MiscRobotsPlusPlus.Compatibility
{
    class Setup
    {
        public static void Initialize(Harmony harmony)
        {
            PatchWorkTab.Patch(harmony);
        }
    }
}
