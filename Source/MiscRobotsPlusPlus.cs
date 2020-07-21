using HarmonyLib;
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
        }
    }
}
