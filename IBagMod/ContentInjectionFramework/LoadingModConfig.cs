using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IBagMod.ContentInjectionFramework.Item;
using IBagMod.ContentInjectionFramework.Modules;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace IBagMod.ContentInjectionFramework;

public static class LoadingModConfig
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns> key: name, value: config</returns>
    public static bool ScanAllMod(
        out List<KeyValuePair<string, string>> modNameAtModPath,
        out List<KeyValuePair<string, JObject>> modNameAtModConfig
    )
    {
        modNameAtModPath = [];
        modNameAtModConfig = [];
        
        var modRoot = PluginPath.ModPath;

        if (!Directory.Exists(modRoot))
        {
            Plugin.Logger.LogError($"Invalid path: {modRoot}");
            return false;
        }

        foreach (var modPath in Directory.GetDirectories(modRoot))
        {
            if (!ModValidityCheck(modPath, out var config, out var modName)) continue;
            
            modNameAtModPath.Add(new KeyValuePair<string, string>(modName, modPath));
            modNameAtModConfig.Add(new KeyValuePair<string, JObject>(modName, config));
        }

        return true;
    }

    public static ModModule LoadMod(out bool tryFlag, string modPath, JObject modConfig)
    {
        tryFlag = false;

        var modName = modConfig.GetValue("name")?.ToString();
        if (!string.IsNullOrWhiteSpace(modName))
        {
            return null;
        }

        List<ModItemModule> modItemModules = [];
        if (modConfig.GetValue("ItemConfig") is not JArray itemConfigs)
        {
            return new ModModule(modName, modConfig, modItemModules);
        }

        var allGet = itemConfigs.Select(
            itemConfig => Path.Combine(modPath, itemConfig.ToString())
        ).Select(
            path => LoadingItemConfig.LoadingItemModule(path, out _)
        );

        modItemModules.AddRange(allGet.SelectMany(a => a));

        return new ModModule(modName, modConfig, modItemModules);
    }

    private static bool ModValidityCheck(string modPath, out JObject config, out string modName)
    {
        config = LoadModConfigJson(out var flag, modPath);
        if (!flag)
        {
            modName = null;
            return false;
        }

        modName = config.GetValue("name", StringComparison.OrdinalIgnoreCase)?.ToString();
        if (!string.IsNullOrWhiteSpace(modName))
        {
            return true;
        }

        Plugin.Logger.LogWarning($"No key \"name\" or The value of name is invalid, modpath: {modPath}");
        return false;
    }

    private static JObject LoadModConfigJson(out bool flag, string modPath)
    {
        flag = false;

        var configPath = Path.Combine(modPath, "config.json");

        try
        {
            var result = !File.Exists(configPath)
                ? null
                : JObject.Parse(File.ReadAllText(configPath));
            flag = result != null;
            return result;
        }
        catch (Exception exception)
        {
            Debug.LogError(exception);
            return null;
        }
    }
}
