using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace LadiesCanFlirtToo;

[HarmonyPatch(typeof(Pawn_RelationsTracker), nameof(Pawn_RelationsTracker.LovinAgeFactor))]
public static class Pawn_RelationsTracker__LovinAgeFactor
{
    public static bool Prefix(Pawn ___pawn, Pawn otherPawn, ref float __result)
    {
        var ageBiologicalYearsFloat = ___pawn.ageTracker.AgeBiologicalYearsFloat;
        var ageBiologicalYearsFloat2 = otherPawn.ageTracker.AgeBiologicalYearsFloat;
        var num = (ageBiologicalYearsFloat / 2f) + 7f;
        var num2 = (ageBiologicalYearsFloat - 7f) * 2f;
        var lower = Mathf.Lerp(num, ageBiologicalYearsFloat, 0.6f);
        var upper = Mathf.Lerp(ageBiologicalYearsFloat, num2, 0.4f);
        __result = GenMath.FlatHill(0.2f, num, lower, upper, num2, 0.2f, ageBiologicalYearsFloat2);
        return false;
    }
}