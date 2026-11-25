using System;
using System.Collections;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using IBagMod.ContentInjectionFramework.Injection;
using UnityEngine;

namespace IBagMod;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string PluginGuid = "702361946.IBagMod";
    private const string PluginName = "IBagMod";
    private const string PluginVersion = "1.0.2";

    public new static readonly ManualLogSource Logger = BepInEx.Logging.Logger.CreateLogSource("IBagMod");
    
    private void Awake()
    {
        IBagMod.Config.Init(Config);
        if (!Manager.Init())
        {
            Logger.LogError("CIF init failed");
        }

        // ReSharper disable once InvertIf
        if (IBagMod.Config.UnlockResolutionLimit.Value)
        {
            try
            {
                Harmony.CreateAndPatchAll(typeof(UnlockResolutionLimit.Patch));
            }
            catch (Exception e)
            {
                Logger.LogError($"The application of the UnlockResolutionLimit patch failed: {e}");
            }
        }
        
        if (IBagMod.Config.UnlockAllStoryState.Value)
        {
            try
            {
                Harmony.CreateAndPatchAll(typeof(UnlockAllStoryState.Patch));
            }
            catch (Exception e)
            {
                Logger.LogError($"The application of the UnlockAllStoryState patch failed: {e}");
            }
        }
        
        StartCoroutine(ExportWhenGameDataReady());
    }
    
    private static IEnumerator ExportWhenGameDataReady()
    {
        Logger.LogInfo("Waiting for data loading");

        while (
            MapDataLib.mdItemLib == null ||
            !GameStatus.hasLoadMapData
        )
            yield return new WaitForSecondsRealtime(0.1f);

        Manager.Injection();
    }
}
