using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BepInEx;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace IBagMod.Export;

[BepInPlugin("702361946.IBagMod.Export", "IBagMod.Export", "1.0.2")]
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
            var itemJsonList = MapDataItem.Export.Main(mapDataItemLib);
            var storyKnotJsonList = MapDataStoryKnot.Export.Main(mapDataStoryKnotLib);
            var sentencesJson = Sentences.Export.Main(SentenceBank.pack);

            var json = BuildJsonArray(itemJsonList);
            var outputFile = Path.Combine(ExportPath.OutputPath, "ItemData.json");
            File.WriteAllText(outputFile, json, new UTF8Encoding(false));
            Logger.LogInfo($"MapDataItem out ok, len is {itemJsonList.Count} -> {outputFile}");

            json = BuildJsonArray(storyKnotJsonList);
            outputFile = Path.Combine(ExportPath.OutputPath, "StoryKnot.json");
            File.WriteAllText(outputFile, json, new UTF8Encoding(false));
            Logger.LogInfo($"MapDataStoryKnot out ok, len is {storyKnotJsonList.Count} -> {outputFile}");
            
            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            jsonWriter.Formatting = Formatting.Indented;
            jsonWriter.Indentation = 4;
            sentencesJson.WriteTo(jsonWriter);

            json = stringWriter.ToString();
            outputFile = Path.Combine(ExportPath.OutputPath, "Sentences.json");
            File.WriteAllText(outputFile, json, new UTF8Encoding(false));
            Logger.LogInfo($"Sentences out ok, len is {sentencesJson.Count} -> {outputFile}");

            _exported = true;
        }
        catch (Exception exception)
        {
            Logger.LogError($"IBagMod.Export out not ok, error is：{exception}");
        }
    }

    private IEnumerator ExportWhenGameDataReady()
    {
        Logger.LogInfo("Waiting for data loading");

        while (
            MapDataLib.mdItemLib == null ||
            MapDataLib.storyKnots == null ||
            SentenceBank.pack == null ||
            SentenceBank.pack.sentences.Count == 0 ||
            !GameStatus.hasLoadMapData
        )
            yield return new WaitForSecondsRealtime(PollIntervalSeconds);

        StartExport();
    }

    private static string BuildJsonArray(List<JObject> jsonItems)
    {
        JArray jsonArray = [.. jsonItems];

        using var stringWriter = new StringWriter();
        using var jsonWriter = new JsonTextWriter(stringWriter);
        jsonWriter.Formatting = Formatting.Indented;
        jsonWriter.Indentation = 4;
        jsonArray.WriteTo(jsonWriter);
        return stringWriter.ToString();
    }
}