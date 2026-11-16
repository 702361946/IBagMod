using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace IBagMod.ContentInjectionFramework;

public static class LoadingModConfig
{
    public static List<string> ScanAllMod()
    {
        var result = new List<string>();
        var modRoot = PluginPath.ModPath;

        if (!Directory.Exists(modRoot))
        {
            return result;
        }

        try
        {
            var modPaths = Directory.GetDirectories(modRoot);
            Array.Sort(modPaths, StringComparer.OrdinalIgnoreCase);

            result.AddRange(
                modPaths.Where(
                    modPath => File.Exists(Path.Combine(modPath, "config.json"))
                )
            );
        }
        catch (Exception exception)
        {
            Debug.LogError($"[IBagMod] 扫描 Mod 目录失败：{modRoot}\n{exception}");
        }

        return result;
    }

    public static ModModule LoadMod(out bool tryFlag, string modPath)
    {
        tryFlag = false;

        try
        {
            var configPath = ResolveConfigPath(modPath);
            var modDirectory = Path.GetDirectoryName(configPath) ?? modPath;
            var config = JObject.Parse(File.ReadAllText(configPath));

            var modName = ReadString(config, "name");
            if (string.IsNullOrWhiteSpace(modName))
            {
                Debug.LogError($"[IBagMod] Mod 配置缺少必填字段 name：{configPath}");
                return null;
            }

            var itemConfigPaths = ReadItemConfigPaths(config, modDirectory);
            tryFlag = true;
            return new ModModule(modName, modDirectory, itemConfigPaths);
        }
        catch (Exception exception)
        {
            Debug.LogError($"[IBagMod] 加载 Mod 配置失败：{modPath}\n{exception}");
            return null;
        }
    }

    private static string ResolveConfigPath(string modPath)
    {
        if (File.Exists(modPath))
        {
            return Path.GetFullPath(modPath);
        }

        var configPath = Path.Combine(modPath, "config.json");
        return !File.Exists(configPath)
            ? throw new FileNotFoundException(
                "config.json not found.", configPath
            )
            : Path.GetFullPath(configPath);
    }

    private static string ReadString(JObject config, string key)
    {
        return config.GetValue(key, StringComparison.OrdinalIgnoreCase)?.Value<string>();
    }

    private static List<string> ReadItemConfigPaths(JObject config, string modDirectory)
    {
        var result = new List<string>();
        var itemConfig = config.GetValue("ItemConfig", StringComparison.OrdinalIgnoreCase);

        if (itemConfig is null || itemConfig.Type == JTokenType.Null)
        {
            return result;
        }

        if (itemConfig.Type == JTokenType.String)
        {
            AddItemConfigPath(result, modDirectory, itemConfig.Value<string>());
            return result;
        }

        if (itemConfig is not JArray itemConfigArray)
        {
            Debug.LogWarning("[IBagMod] config.json 中的 ItemConfig 必须是字符串或字符串数组。");
            return result;
        }

        foreach (var itemConfigToken in itemConfigArray)
        {
            if (itemConfigToken.Type != JTokenType.String)
            {
                continue;
            }

            AddItemConfigPath(result, modDirectory, itemConfigToken.Value<string>());
        }

        return result;
    }

    private static void AddItemConfigPath(
        List<string> result,
        string modDirectory,
        string itemConfigPath
    )
    {
        if (string.IsNullOrWhiteSpace(itemConfigPath))
        {
            return;
        }

        try
        {
            var fullPath = Path.GetFullPath(
                Path.IsPathRooted(itemConfigPath)
                    ? itemConfigPath
                    : Path.Combine(modDirectory, itemConfigPath)
            );
            var modRoot = Path.GetFullPath(modDirectory);
            var modRootPrefix =
                modRoot.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                + Path.DirectorySeparatorChar;

            if (!fullPath.StartsWith(modRootPrefix, StringComparison.OrdinalIgnoreCase))
            {
                Debug.LogWarning($"[IBagMod] ItemConfig 路径越界，已忽略：{itemConfigPath}");
                return;
            }

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning($"[IBagMod] ItemConfig 文件不存在：{fullPath}");
                return;
            }

            result.Add(fullPath);
        }
        catch (Exception exception)
        {
            Debug.LogWarning($"[IBagMod] ItemConfig 路径无效：{itemConfigPath}\n{exception.Message}");
        }
    }
}