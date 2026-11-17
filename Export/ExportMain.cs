using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BepInEx;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using MapDataItemExporter = Export.MapDataItem.Export;

namespace Export;

[BepInPlugin("702361946.IBagMod.Export", "IBagMod.Export", "1.0.1")]
public class ExportMain : BaseUnityPlugin
{
    private const float PollIntervalSeconds = 0.1f;

    private bool _exported;

    private void Awake()
    {
        StartCoroutine(ExportWhenGameDataReady());
    }

    private void StartExport()
    {
        if (_exported) return;

        var mapDataItemLib = MapDataLib.mdItemLib;
        if (mapDataItemLib == null)
        {
            Logger.LogWarning("MapDataItemLib is null");
            return;
        }

        var mapDataStoryKnotLib = MapDataLib.storyKnots;
        if (mapDataStoryKnotLib == null)
        {
            Logger.LogWarning("MapDataStoryKnotLib is null");
            return;
        }

        try
        {
            Directory.CreateDirectory(ExportPath.OutputPath);
        }
        catch (Exception exception)
        {
            Logger.LogWarning($"Create directory error: {exception}");
        }

        try
        {
            var itemJsonList = MapDataItemExporter.Main(mapDataItemLib);
            var storyKnotJsonList = MapDataStoryKnot.Export.Main(mapDataStoryKnotLib);

            var json = BuildJsonArray(itemJsonList);
            var outputFile = Path.Combine(ExportPath.OutputPath, "ItemData.json");
            File.WriteAllText(outputFile, json, new UTF8Encoding(false));
            Logger.LogInfo($"MapDataItem out ok, len is {itemJsonList.Count} -> {outputFile}");

            json = BuildJsonArray(storyKnotJsonList);
            outputFile = Path.Combine(ExportPath.OutputPath, "StoryKnot.json");
            File.WriteAllText(outputFile, json, new UTF8Encoding(false));
            Logger.LogInfo($"MapDataStoryKnot out ok, len is {storyKnotJsonList.Count} -> {outputFile}");

            _exported = true;
        }
        catch (Exception exception)
        {
            Logger.LogError($"MapDataItem or MapDataStoryKnot out not ok, error is：{exception}");
        }
    }

    private IEnumerator ExportWhenGameDataReady()
    {
        Logger.LogInfo("Waiting for data loading");

        while (
            MapDataLib.mdItemLib == null ||
            MapDataLib.storyKnots == null ||
            !GameStatus.hasLoadMapData
        )
            yield return new WaitForSecondsRealtime(PollIntervalSeconds);

        StartExport();
    }

    private static string BuildJsonArray(List<JObject> jsonItems)
    {
        var jsonArray = new JArray();
        foreach (var itemJson in jsonItems) jsonArray.Add(itemJson);

        using var stringWriter = new StringWriter();
        using var jsonWriter = new JsonTextWriter(stringWriter);
        jsonWriter.Formatting = Formatting.Indented;
        jsonWriter.Indentation = 4;
        jsonArray.WriteTo(jsonWriter);
        return stringWriter.ToString();
    }
}