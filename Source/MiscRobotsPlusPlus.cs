using HarmonyLib;
using MiscRobotsPlusPlus.GUITweaks;
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

            ClassInjector.Init();
            Compatibility.Setup.Initialize(harmony);
        }
    }
}
