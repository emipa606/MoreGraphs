# GitHub Copilot Instructions for More Graphs (Continued) Mod

## Mod Overview and Purpose

The More Graphs (Continued) mod is an update of natbob1's mod, enhancing the graphical representation of colony data in the History tab of the RimWorld game. This mod provides additional insights into your colony's performance through a variety of graphs. It is designed to be compatible with existing saves and can be safely removed without affecting the game's functionality.

## Key Features and Systems

### Item Wealth Breakdown
- **Categories**: Materials, Manufactured, Food, Medical / Drugs, Apparel, and Weapons.
- **Functionality**: Shows a breakdown of your colony's wealth from items.

### Food Breakdown
- **Categories**: Vegetarian, Meat, Animal Products, and Meals.
- **Functionality**: Shows a breakdown of stored food by nutrition.

### Power Usage
- **Functionality**: Shows excess energy and stored energy over time.

### Materials
- **Categories**: Wood, Steel, Plasteel, Uranium, Gold, and Jade.
- **Functionality**: Shows counts of materials over time.

### Manufactured
- **Categories**: Components, Advanced Components, Medicine, and Drugs.
- **Functionality**: Shows counts of manufactured items over time.

### Silver
- **Functionality**: Shows your silver reserves over time.

## Coding Patterns and Conventions

1. **Mod Structure**: 
   - The mod is organized into various subdirectories, each focusing on different aspects such as `Environment`, `ItemWealthTracker`, `Manufactured`, etc.
   - C# files are located under the `Source` directory, and XML files are located under the `Defs` and `Patches` directories.

2. **Class and Method Naming**:
   - Classes are named according to their functionality, e.g., `HistoryAutoRecorderWorker_MoreGraphs_Environment_Rain`.
   - Methods are descriptive, e.g., `PullRecord`, `getThingCategoryMap`.

3. **Code Comments**:
   - Comments are used to explain complex logic, particularly in methods like `PullRecord` and `ItemWealthByCategory`.

4. **Error Handling**:
   - Basic error handling is included, especially in methods that interact with game data.

## XML Integration

The mod uses XML files to define various aspects of the game, such as history recorders. Key XML files include:

- `HistoryAutoRecorders_Manufactured.xml`: Defines history recorders for manufactured items.
- `HistoryAutoRecorders_Materials.xml`: Defines history recorders for materials.
- `HistoryAutoRecorders_WealthItems.xml`: Defines history recorders for wealth items.
- `HistoryAutoRecorders_Nutrition.xml`: Defines history recorders for nutrition.
- `patches.xml`: Contains Harmony patches.

### Example XML Definition

xml
<HistoryAutoRecorderDef>
    <defName>MoreGraphs_Manufactured_Components</defName>
    <group>Manufactured</group>
    <titleKey>MoreGraphs_Manufactured_Components_Title</titleKey>
    <descriptionKey>MoreGraphs_Manufactured_Components_Description</descriptionKey>
    <autoRecorderClass>HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Components</autoRecorderClass>
</HistoryAutoRecorderDef>


## Harmony Patching

The mod uses Harmony patching to extend the functionality of the game without modifying the original codebase. Harmony patches are defined in the `patches.xml` file. Here is an example of a Harmony patch:

xml
<Patch>
    <description>More Graphs - Add research graph</description>
    <modNamespace>Mlie.MoreGraphs</modNamespace>
    <operation>MethodPrefix</operation>
    <targetMethod>ResearchManager.ResearchCompleted</targetMethod>
    <prefixClass>MoreGraphs.Patches.ResearchManager_Patch</prefixClass>
    <prefixMethod>Prefix</prefixMethod>
</Patch>


### Example Harmony Patch Class

csharp
namespace MoreGraphs.Patches
{
    public static class ResearchManager_Patch
    {
        public static void Prefix(ResearchProjectDef project)
        {
            // Custom logic to record research completion
        }
    }
}


## Suggestions for Copilot

1. **Code Snippets**:
   - Provide snippets for creating new history recorders and Harmony patches.
   - Include examples of how to integrate new data categories into existing graphs.

2. **Translation Updates**:
   - Offer guidance on how to update translations for new features, ensuring consistency with existing translations.

3. **Debugging Tips**:
   - Provide common debugging techniques and error messages to help users resolve issues related to mod integration.

4. **Best Practices**:
   - Offer best practices for maintaining and updating the mod, including code organization and documentation.

By following these guidelines, GitHub Copilot can effectively assist developers working on the More Graphs (Continued) mod, helping them to create, maintain, and extend the mod's features efficiently.

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

