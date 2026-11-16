using System.Collections.Generic;
using IBagMod.ContentInjectionFramework.Item;

namespace IBagMod.ContentInjectionFramework;

public class ModModule(
    string modName,
    string modPath,
    List<string> modItemConfigPaths
)
{
    // ReSharper disable once UnusedMember.Global
    public string ModName = modName;
    // ReSharper disable once UnusedMember.Global
    public string ModPath = modPath;
    public readonly List<string> ModItemConfigPaths = modItemConfigPaths ?? [];
    public readonly List<ItemDefinition> ItemDefinitions = [];
}