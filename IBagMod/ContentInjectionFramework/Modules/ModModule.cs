using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace IBagMod.ContentInjectionFramework.Modules;

public class ModModule(
    string modName,
    JObject modConfig,
    List<ModItemModule> modItems
)
{
    // ReSharper disable once UnusedMember.Global
    public string ModName = modName;
    // ReSharper disable once UnusedMember.Global
    public JObject ModConfig = modConfig;
    public readonly List<ModItemModule> ModItems = modItems ?? [];
}