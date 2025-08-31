using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace LadiesCanFlirtToo;

[HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), nameof(InteractionWorker_RomanceAttempt.RandomSelectionWeight))]
public static class InteractionWorker_RomanceAttempt__RandomSelectionWeight
{
    private static readonly MethodInfo methodCalculate =
        AccessTools.Method(typeof(InteractionWorker_RomanceAttempt__RandomSelectionWeight),
            nameof(CalculateAttractionFactor));

    public static float CalculateAttractionFactor(Pawn initiator, Pawn recipient)
    {
        bool initiatorInterested;
        bool recipientInterested;
        if (initiator.gender == recipient.gender)
        {
            initiatorInterested = initiator.story.traits.HasTrait(TraitDefOf.Gay) ||
                                  initiator.story.traits.HasTrait(TraitDefOf.Bisexual);
            recipientInterested = recipient.story.traits.HasTrait(TraitDefOf.Gay) ||
                                  recipient.story.traits.HasTrait(TraitDefOf.Bisexual);
        }
        else
        {
            initiatorInterested = !initiator.story.traits.HasTrait(TraitDefOf.Gay) &&
                                  !initiator.story.traits.HasTrait(TraitDefOf.Asexual);
            recipientInterested = !recipient.story.traits.HasTrait(TraitDefOf.Gay) &&
                                  !recipient.story.traits.HasTrait(TraitDefOf.Asexual);
        }

        if (!(initiatorInterested && recipientInterested))
        {
            return 0.15f;
        }

        return 1f;
    }

    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var list = instructions.ToList();
        for (var num = list.Count - 1; num > 0; num--)
        {
            if (list[num].opcode != OpCodes.Ldc_R4 || (float)list[num].operand != 1.15f)
            {
                continue;
            }

            list.InsertRange(++num, [
                new CodeInstruction(OpCodes.Ldc_R4, 1f),
                new CodeInstruction(OpCodes.Stloc_S, 4),
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Ldarg_2),
                new CodeInstruction(OpCodes.Call, methodCalculate),
                new CodeInstruction(OpCodes.Stloc_S, 7)
            ]);
            return list.AsEnumerable();
        }

        throw new Exception(
            "Could not locate the correct instruction to patch - a mod incompatibility or game update broke it.");
    }
}