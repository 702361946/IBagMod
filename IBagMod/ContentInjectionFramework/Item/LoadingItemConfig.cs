using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IBagMod.ContentInjectionFramework.Modules;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace IBagMod.ContentInjectionFramework.Item;

public static class LoadingItemConfig
{
    public static List<ModItemModule> LoadingItemModule(string configPath, out JObject config)
    {
        config = null;
        
        if (!ItemValidityCheck(configPath, out var iConfig))
        {
            return null;
        }

        List<ModItemModule> rm = [];

        foreach (var c in iConfig)
        {
            rm.Add(new ModItemModule(
                c.Key,
                c.Value!["Desc"]?.ToString() ?? "",
                c.Value["AttributeTypes"]?
                    .Select(v => (AttributeType)v.ToObject<int>())
                    .ToList() ?? [],
                c.Value["AttributeCurveFuncList"]?
                    .ToObject<List<List<List<int>>>>() ?? [],
                c.Value["BarColorStr"]?.ToString(),
                c.Value["NumColorStr"]?.ToString(),
                c.Value["IsLive"]?.ToObject<int>() ?? 0
            ));
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
            Debug.LogError(exception);
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

            Debug.LogError($"item name error, name is {c.Key}");
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
