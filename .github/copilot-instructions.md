# GitHub Copilot Instructions for Ladies Can Flirt Too! (Continued)

## Mod Overview and Purpose
The "Ladies Can Flirt Too! (Continued)" mod aims to augment the romance dynamic in RimWorld by equalizing the likelihood of romantic initiation across all genders and orientations. The mod also revises the age range preferences for partner selection using the "half their age plus 7" rule, making romance more balanced and less biased by default game mechanics.

## Key Features and Systems
- **Equalized Romance Initiation**: All pawns, regardless of gender or orientation, have an equal chance to initiate romance as long as the pairing is compatible.
- **Age Range Equalization**: Both male and female pawns follow the "half their age plus 7" rule for looking for partners. 
- **Safe for Existing Saves**: The mod can be added to or removed from existing save files without issue.
- **Compatibility Considerations**: The mod is incompatible with Rational Romance and Psychology mods, but can be used alongside Individuality with certain settings disabled.

## Coding Patterns and Conventions
- **Static Class Use**: All classes, such as `InteractionWorker_RomanceAttempt__RandomSelectionWeight` and `Pawn_RelationsTracker__LovinAgeFactor`, are defined as static to focus purely on methods that override or extend existing game behavior.
- **Method Simplicity**: Methods within these classes should aim to be concise and self-contained, ensuring modifications are clear and maintainable.
- **Descriptive Naming**: Use verbose and descriptive method and class names to clearly indicate functionality and intent, following the pattern seen throughout the project.

## XML Integration
While the primary code changes are in C#, XML files might be used to support translations or future configuration options. Ensure that XML node names and attributes are descriptive and follow consistent naming conventions that align with the mod's C# structure.

## Harmony Patching
This mod makes extensive use of Harmony to patch the original game logic without altering the base game files:
- **Transpilers Where Necessary**: Use Harmony transpilers to modify methods' intermediate language when patching simple methods isn't sufficient.
- **Prefix and Postfix Methods**: Implement Harmony's prefix and postfix methods to insert or append logic to existing game functions without removing their original functionality.

## Suggestions for Copilot
- Suggest code patterns for modifying existing static class methods from the vanilla game, especially those related to pawn interactions and relationship dynamics.
- Generate detailed method stubs for calculating romance initiation weights and partner age ranges using the specified rules.
- Assist with creating XML configuration options if needed for future expansibility.
- When providing Harmony patches, suggest appropriate use cases for prefix, postfix, and transpiler methods, balancing mod behavior with performance.
- Offer guidance on implementing compatibility checks when used in conjunction with other mods that modify similar aspects.

### Examples for Specific Use Cases
- Calculate the adjusted romance initiation weight:
  csharp
  public static float AdjustedRomanceWeight(Pawn initiator, Pawn recipient)
  {
      float baseWeight = ...; // Determine base weight from game logic
      return baseWeight * (initiator.gender == recipient.gender ? 1.0f : 0.85f);
  }
  

- Harmony Patch Example:
  csharp
  [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), "RandomSelectionWeight")]
  public static class InteractionWorker_RomanceAttempt__RandomSelectionWeight_Patch
  {
      public static bool Prefix(Pawn initiator, ref float __result)
      {
          __result = AdjustedRomanceWeight(initiator, ...);
          return false; // Skip original logic
      }
  }
  

This documentation should guide developers and Copilot in maintaining the intended functionality and style of the "Ladies Can Flirt Too!" mod.
