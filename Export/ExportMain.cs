using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BepInEx;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using MapDataItemExporter = global::Export.MapDataItem.Export;

namespace Export;

[BepInPlugin("702361946.IBagMod.Export", "IBagMod.Export", "1.0.0")]
public class ExportMain : BaseUnityPlugin
{
    private const string MapDataItemFileName = "MapDataItem.json";
    private const float PollIntervalSeconds = 0.5f;

    private bool _exported;

    private void Awake()
    {
        Logger.LogInfo("IBagMod.Export启动");
        StartCoroutine(ExportWhenGameDataReady());
    }

    private void StartExport()
    {
        if (_exported) return;

        var mapDataItemLib = MapDataLib.mdItemLib;
        if (mapDataItemLib == null)
        {
            Logger.LogWarning("MapDataItemLib 尚未加载，跳过导出");
            return;
        }

        try
        {
            Directory.CreateDirectory(ExportPath.OutputPath);

            var itemJsonList = MapDataItemExporter.Main(mapDataItemLib);
            var outputFile = Path.Combine(ExportPath.OutputPath, MapDataItemFileName);
            var json = BuildJsonArray(itemJsonList);

            File.WriteAllText(outputFile, json, new UTF8Encoding(false));
            _exported = true;
            Logger.LogInfo($"MapDataItem 导出完成：{itemJsonList.Count} 条 -> {outputFile}");
        }
        catch (Exception exception)
        {
            Logger.LogError($"MapDataItem 导出失败：{exception}");
        }
    }

    private IEnumerator ExportWhenGameDataReady()
    {
        Logger.LogInfo("等待游戏数据加载完成");

        while (MapDataLib.mdItemLib == null || !GameStatus.hasLoadMapData)
        {
            yield return new WaitForSecondsRealtime(PollIntervalSeconds);
        }

        StartExport();
    }

    private static string BuildJsonArray(List<JObject> jsonItems)
    {
        var jsonArray = new JArray();
        foreach (var itemJson in jsonItems)
        {
            jsonArray.Add(itemJson);
        }

        using var stringWriter = new StringWriter();
        using var jsonWriter = new JsonTextWriter(stringWriter);
        jsonWriter.Formatting = Formatting.Indented;
        jsonWriter.Indentation = 4;
        jsonArray.WriteTo(jsonWriter);
        return stringWriter.ToString();
    }
}