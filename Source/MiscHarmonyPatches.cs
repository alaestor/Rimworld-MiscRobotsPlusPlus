using AIRobot;
using HarmonyLib;
using MiscRobotsPlusPlus.Patches;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI;

namespace MiscRobotsPlusPlus
{
    [HarmonyPatch(typeof(WorkGiver_PatientGoToBedTreatment), nameof(WorkGiver_PatientGoToBedTreatment.AnyAvailableDoctorFor))]
    static class MiscHarmonyPatches
    {

        
        [HarmonyPrefix]
        static bool Prefix(Pawn pawn, ref bool __result) //pass the __result by ref to alter it.
        {
            __result = true;
            Map mapHeld = pawn.MapHeld;
            if (mapHeld == null)
            {
                return false;
            } 
            List<Pawn> list = mapHeld.mapPawns.SpawnedPawnsInFaction(Faction.OfPlayer);
            for (int i = 0; i < list.Count; i++)
            {
                Pawn pawn2 = list[i];
                if (pawn2 != pawn && (pawn2.RaceProps.Humanlike || pawn2 is X2_AIRobot && pawn2.IsColonyMech|| pawn2.IsColonyMechPlayerControlled) && !pawn2.Downed && pawn2.Awake() && !pawn2.InBed() && !pawn2.InMentalState && !pawn2.IsPrisoner && pawn2.workSettings != null && pawn2.workSettings.EverWork && pawn2.workSettings.WorkIsActive(WorkTypeDefOf.Doctor) && pawn2.health.capacities.CapableOf(PawnCapacityDefOf.Manipulation) && pawn2.CanReach(pawn, PathEndMode.Touch, Danger.Deadly))
                {
                    __result = true;
                }
            } 
            return false; //return false to skip execution of the original.
        }
    }

    

}
