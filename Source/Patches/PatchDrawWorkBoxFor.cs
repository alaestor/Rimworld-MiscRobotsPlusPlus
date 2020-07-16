﻿using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using MiscRobotsPlusPlus.Core;
using RimWorld;
using Verse;

namespace MiscRobotsPlusPlus.Patches
{
    /*[HarmonyPatch(typeof(WidgetsWork))]
    [HarmonyPatch("DrawWorkBoxFor")]
    [HarmonyPatch(new[] { typeof(float), typeof(float), typeof(Pawn), typeof(WorkTypeDef), typeof(bool) })]
    internal class Patch_WorkDisable
    {
        private static IEnumerable<CodeInstruction> Transpiler(ILGenerator gen, MethodBase mBase,
            IEnumerable<CodeInstruction> instr)
        {
            // Define label to the begining of the original code
            var jumpTo = gen.DefineLabel();
            yield return new CodeInstruction(OpCodes.Ldarg_2);
            yield return new CodeInstruction(OpCodes.Ldarg_3);
            yield return new CodeInstruction(OpCodes.Call,
                typeof(WorkSettings).GetMethod(nameof(WorkSettings.WorkDisabled), new[] { typeof(Pawn), typeof(WorkTypeDef) }));
            //If false continue
            yield return new CodeInstruction(OpCodes.Brfalse, jumpTo);
            //Return
            yield return new CodeInstruction(OpCodes.Ret);

            var first = true;
            foreach (var ci in instr)
            {
                if (first)
                {
                    first = false;
                    ci.labels.Add(jumpTo);
                }
                yield return ci;
            }
        }
    }*/
}
