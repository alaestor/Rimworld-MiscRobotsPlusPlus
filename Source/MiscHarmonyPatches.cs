using AIRobot;
using HarmonyLib;
using MiscRobotsPlusPlus.Patches;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI;

namespace MiscRobotsPlusPlus
{
    [HarmonyPatch(typeof(WorkGiver_PatientGoToBedTreatment))]
    [HarmonyPatch(nameof(WorkGiver_PatientGoToBedTreatment.AnyAvailableDoctorFor))]
    internal class MiscHarmonyPatches
    {
        [HarmonyPostfix]
        static bool AnyAvailableDoctorFor(Pawn pawn)
        {
            Map mapHeld = pawn.MapHeld;
            if (mapHeld == null)
            {
                return false;
            }
            List<Pawn> list = mapHeld.mapPawns.SpawnedPawnsInFaction(Faction.OfPlayer);
            for (int i = 0; i < list.Count; i++)
            {
                Pawn pawn2 = list[i];
                if (pawn2 != pawn && (pawn2.RaceProps.Humanlike || pawn2.IsColonyMechPlayerControlled || pawn2 is X2_AIRobot) && !pawn2.Downed && pawn2.Awake() && !pawn2.InBed() && !pawn2.InMentalState && !pawn2.IsPrisoner && pawn2.workSettings != null && pawn2.workSettings.EverWork && pawn2.workSettings.WorkIsActive(WorkTypeDefOf.Doctor) && pawn2.health.capacities.CapableOf(PawnCapacityDefOf.Manipulation) && pawn2.CanReach(pawn, PathEndMode.Touch, Danger.Deadly))
                {
                    return true;
                }
            }
            return false;
        }

        public static void Patch(string WhatClass)
        {
            var harmony = new Harmony(WhatClass);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            PatchGeneratePawnRestrictionOptions.Patch(harmony);
        }
    }
   
}
