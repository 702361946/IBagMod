using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IBagMod.ContentInjectionFramework.Modules;
using Newtonsoft.Json.Linq;

namespace IBagMod.ContentInjectionFramework.Loading;

public static class LoadingItemConfig
{
    public static List<ModItemModule> LoadingItemModule(string configPath)
    {
        if (!ItemValidityCheck(configPath, out var iConfig))
        {
            return null;
        }

        List<ModItemModule> rm = [];

        foreach (var c in iConfig)
        {
            if (c.Value is not JObject itemObj)
            {
                Plugin.Logger.LogWarning($"Invalid item config: {c.Key}");
                continue;
            }
            
            try
            {
                rm.Add(new ModItemModule(
                    itemObj,
                    c.Key,
                    itemObj["Desc"]?.ToString() ?? "",
                    itemObj["AttributeTypes"]?
                        .Select(v => v.ToObject<AttributeType>())
                        .ToList() ?? [],
                    itemObj["AttributeCurveFuncList"]?
                        .ToObject<List<List<List<float>>>>() ?? [],
                    itemObj["BarColorStr"]?.ToString() ?? "#000000",
                    itemObj["NumColorStr"]?.ToString() ?? "#000000",
                    itemObj["IsLive"]?.ToObject<int>() ?? 0
                ));
            } catch (Exception e)
            {
                Plugin.Logger.LogWarning($"Invalid item config, key: {c.Key}, error: {e}");
            }
        }

        return rm;
    }

    private static JObject LoadingItemJson(out bool flag, string configPath)
    {
        flag = false;

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

    private static bool ItemValidityCheck(
        string itemConfigPath,
        out JObject config
    )
    {
        config = null;
        
        var rConfig = LoadingItemJson(out var flag, itemConfigPath);
        if (!flag)
        {
            return false;
        }

        List<string> eKey = [];
        foreach (var c in rConfig)
        {
            if (!string.IsNullOrWhiteSpace(c.Key)) continue;

            Plugin.Logger.LogError($"item name error, name is {c.Key}");
            eKey.Add(c.Key);
        }
        
        foreach (var k in eKey)
        {
            rConfig.Remove(k);
        }

        config = rConfig;
        return true;
    }
}
