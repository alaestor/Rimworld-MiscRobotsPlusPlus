using HarmonyLib;
using MiscRobotsPlusPlus.GUITweaks;
using MiscRobotsPlusPlus.Patches;
using System.Reflection;
using Verse;

namespace MiscRobotsPlusPlus
{
    [StaticConstructorOnStartup]
    public class MiscRobotsPlusPlus
    {
        static MiscRobotsPlusPlus()
        {
            var harmony = new Harmony("MiscRobotsPlusPlus");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            PatchGeneratePawnRestrictionOptions.Patch(harmony);

            ClassInjector.Init();
            Compatibility.Setup.Initialize(harmony);
        }
    }
}
