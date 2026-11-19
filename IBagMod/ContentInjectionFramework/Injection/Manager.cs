using System;
using System.Collections.Generic;
using System.Linq;
using IBagMod.ContentInjectionFramework.Modules;

namespace IBagMod.ContentInjectionFramework.Injection;

public class Manager
{
    private static List<KeyValuePair<string, ModModule>> AllLoadMod = [];
    private static bool _init;

    public static void ClearAllInit()
    {
        _init = false;
        AllLoadMod.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="forceReinitialization">When set to true, the initialized flag will be ignored,
    /// and all initialized content will be cleared after the pre-check is completed</param>
    /// <returns></returns>
    public static bool Init(bool forceReinitialization = false)
    {
        if (_init && !forceReinitialization) return true;

        if (
            LoadingModConfig.ScanAllMod(
                out var modNameAtModPath,
                out var modNameAtModConfig
            )
        ) return false;
        
        ClearAllInit();
        
        List<KeyValuePair<string, ModModule>> modNameAtModModule = [];
        List<string> conflictMod = [];
        List<KeyValuePair<string, string>> conflictModNameAtModPath = [];

        foreach (var mod in modNameAtModConfig)
        {
            if (conflictMod.Contains(mod.Key))
            {
                continue;
            }
            
            var modPaths = modNameAtModPath
                .Where(kv => kv.Key == mod.Key)
                .ToList();
            if (modPaths.Count != 1)
            {
                conflictMod.AddRange(modPaths.Select(kv => kv.Key));
                conflictModNameAtModPath.AddRange(modPaths);
                continue;
            }
            var modPath = modPaths[0].Value;

            var modModule = LoadingModConfig.LoadMod(out var flag, modPath, mod.Value);
            if (!flag) continue;
            
            modNameAtModModule.Add(new KeyValuePair<string, ModModule>(mod.Key, modModule));
        }

        AllLoadMod.AddRange(modNameAtModModule);
        _init = true;
        
        // 冲突输出
        if (conflictModNameAtModPath.Count <= 0) return true;

        var separator = new string('-', 50);
        var conflictLines = string.Join(
            Environment.NewLine,
            conflictModNameAtModPath.Select(kv => $"{kv.Key}:{kv.Value}")
        );

        Plugin.Logger.LogWarning(
            $"\n{separator}\nConflicts have been detected with the following mods"
            + $"\n{conflictLines}\n{separator}"
        );

        return true;
    }

    public static void Injection()
    {
        if (!Init())
        {
            Plugin.Logger.LogError("Injection Init failure");
            return;
        }

        List<MapDataItem> injectionAllItem =
        [
            .. AllLoadMod.SelectMany(
                kv =>kv.Value.ModItems.Select(ic => ic.ModuleToGameItem())
            )
        ];

        if (!InjectionItem.Injection(injectionAllItem))
        {
            Plugin.Logger.LogWarning("Injection item anomaly");
        }
    }
}