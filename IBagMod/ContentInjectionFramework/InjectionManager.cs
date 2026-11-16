using System;
using System.Collections.Generic;
using IBagMod.ContentInjectionFramework.Item;
using UnityEngine;

namespace IBagMod.ContentInjectionFramework;

public static class InjectionManager
{
    private static readonly List<ModModule> LoadedModules = [];
    private static readonly List<ItemDefinition> PendingItems = [];
    private static MapDataItemLib _appliedItemLib;
    private static bool _initialized;

    public static void Init()
    {
        if (_initialized)
        {
            return;
        }

        _initialized = true;

        try
        {
            foreach (var modPath in LoadingModConfig.ScanAllMod())
            {
                var module = LoadingModConfig.LoadMod(out var success, modPath);
                if (!success || module is null)
                {
                    continue;
                }

                LoadItems(module);
                LoadedModules.Add(module);
                PendingItems.AddRange(module.ItemDefinitions);
            }
        }
        catch (Exception exception)
        {
            Debug.LogError($"[IBagMod] 初始化 CIF 失败\n{exception}");
        }

        Debug.Log(
            $"[IBagMod] CIF 已扫描 {LoadedModules.Count} 个 Mod，待注入物品 {PendingItems.Count} 个。"
        );
    }

    public static void ApplyPendingItems()
    {
        var itemLib = MapDataLib.mdItemLib;
        if (itemLib is null || ReferenceEquals(_appliedItemLib, itemLib))
        {
            return;
        }

        _appliedItemLib = itemLib;

        if (PendingItems.Count == 0)
        {
            return;
        }

        var successCount = 0;

        foreach (var definition in PendingItems)
        {
            try
            {
                ItemInjection.Add(definition);
                successCount++;
            }
            catch (Exception exception)
            {
                Debug.LogError(
                    $"[IBagMod] 注入物品失败：Name={definition.Name}\n{exception}"
                );
            }
        }

        Debug.Log($"[IBagMod] CIF 物品注入完成：成功 {successCount}/{PendingItems.Count} 个。");
    }

    private static void LoadItems(ModModule module)
    {
        foreach (var itemConfigPath in module.ModItemConfigPaths)
        {
            try
            {
                module.ItemDefinitions.AddRange(ItemConfigLoader.Load(itemConfigPath));
            }
            catch (Exception exception)
            {
                Debug.LogError(
                    $"[IBagMod] 加载物品配置失败：{itemConfigPath}\n{exception}"
                );
            }
        }
    }
}
