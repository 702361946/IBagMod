using System;
using System.Collections.Generic;
using System.IO;
using IBagMod.CIF.Modules;
using Newtonsoft.Json.Linq;

namespace IBagMod.CIF.Loading;

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

        try
        {
            foreach (var modPath in Directory.GetDirectories(modRoot))
            {
                if (!ModValidityCheck(modPath, out var config, out var modName)) continue;

                modNameAtModPath.Add(new KeyValuePair<string, string>(modName, modPath));
                modNameAtModConfig.Add(new KeyValuePair<string, JObject>(modName, config));
            }
        }
        catch (Exception exception)
        {
            Plugin.Logger.LogError($"An error occurred while scanning all mods: {exception}");
            return false;
        }

        return true;
    }

    public static ModModule LoadMod(out bool tryFlag, string modPath, JObject modConfig)
    {
        tryFlag = false;

        var modName = modConfig.GetValue("name", StringComparison.OrdinalIgnoreCase)?.ToString();
        if (string.IsNullOrWhiteSpace(modName))
        {
            return null;
        }

        List<ModItemModule> modItemModules = [];
        if (modConfig.GetValue("ItemConfig") is not JArray itemConfigs)
        {
            tryFlag = true;
            return new ModModule(modName, modConfig, modItemModules);
        }

        foreach (var itemConfig in itemConfigs)
        {
            var fullPath = Path.GetFullPath(Path.Combine(modPath, itemConfig.ToString()));

            if (!fullPath.StartsWith(modPath, StringComparison.OrdinalIgnoreCase))
            {
                Plugin.Logger.LogWarning($"ItemConfig path escapes mod directory: {itemConfig}");
                continue;
            }

            try
            {
                var modules = LoadingItemConfig.LoadingItemModule(fullPath);
                if (modules is not null)
                {
                    modItemModules.AddRange(modules);
                }
            }
            catch (Exception e)
            {
                Plugin.Logger.LogError($"Failed to load item config, error: {e}");
            }
        }

        tryFlag = true;
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
            Plugin.Logger.LogError(exception);
            return null;
        }
    }
}
