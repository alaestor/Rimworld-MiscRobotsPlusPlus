using HarmonyLib;
using System.Reflection;
using Verse;

namespace MiscRobotsPlusPlus
{
    [StaticConstructorOnStartup]
    public class MiscRobotsPlusPlus
    {
        static MiscRobotsPlusPlus()
        {
            new Harmony("MiscRobotsPlusPlus").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
