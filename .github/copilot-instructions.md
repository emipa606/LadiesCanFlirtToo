# Ladies Can Flirt Too! (Continued) Copilot Instructions

## Mod Overview and Purpose
**Mod Name:** Ladies Can Flirt Too! (Continued)  
**Description:**  
An update of the original mod by Sea, this mod rebalances the romance initiation mechanics in RimWorld. It ensures women initiate romance as frequently as men and that bisexual pawns have the same likelihood of initiating romance as their straight or gay counterparts. The age-based preferences for partner selection have also been adjusted, adhering to the "half their age plus 7" rule for both genders.

**Purpose:**  
- Promote gender and orientation equality in romance initiation.
- Provide more realistic and varied age-based attraction dynamics.
- Enhance narrative possibilities in RimWorld colonies by preventing imbalanced or unrealistic romantic scenarios.

## Key Features and Systems
- **Equalized Romance Initiation:** Female and bisexual pawns initiate romances at the same rates as male and straight/gay pawns.
- **Age Range Adjustment:** Partners are sought using the "half their age plus 7" rule, offering a balanced mechanism for age preference.
- **Compatibility:** Works alongside multiple mods as long as those mods do not alter romance mechanics.

## Coding Patterns and Conventions
- **Consistent Naming:** Follow C# naming conventions (PascalCase for types and methods).
- **Modularity:** Each C# file is designed to target specific areas, such as random selection weights or age factors.
- **Separation of Concerns:** Logic for different features isolated into dedicated classes and methods.

## XML Integration
- **About.xml:** Contains metadata for the mod, such as name, author, and package information.
- **Configuration:** Additional XML files might be required to manage mod settings or integration with other mods, but currently limited to metadata.

## Harmony Patching
- **Library:** Uses Harmony (brrainz.harmony) for runtime patching of core RimWorld methods.
- **Patch Types:**
  - **Transpiler:** Modifies the IL code of romance attempt selection for randomization.
  - **Prefix:** Adjusts the age factor computations pre-execution to implement new attraction rules.
- **Focus**: Non-destructive and reversible changes preserving original game functionality.

## Suggestions for Copilot
- **Code Generation:** Assist in developing future patches or updates by generating sample Harmony patches or RimWorld-specific C# methods.
- **Error Logging:** Recommend efficient logging practices to trace issues stemming from mod interactions.
- **Integration Assistance:** Suggest structure for potential XML files to manage dynamic configurations and mod settings.
- **Optimization Tips:** Provide guidance or best practices on optimizing patch performance and maintaining compatibility across game updates.

---

For inquiries or issues with the mod, please use the designated Discord for real-time support. Respective logs should be submitted via the log uploader for efficient troubleshooting.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

