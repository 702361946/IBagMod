// using System.Collections;
using BepInEx;
// using BepInEx.Logging;
// using UnityEngine;

namespace IBagMod;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string PluginGuid = "702361946.IBagMod";
    private const string PluginName = "IBagMod";
    private const string PluginVersion = "1.0.2";

    // public new static readonly ManualLogSource Logger = BepInEx.Logging.Logger.CreateLogSource("IBagMod");
    
    // private void Awake()
    // {
    //     // if (!Manager.Init())
    //     // {
    //     //     Logger.LogError("CIF init failed");
    //     // }
    //     //
    //     // StartCoroutine(ExportWhenGameDataReady());
    // }
    
    // private static IEnumerator ExportWhenGameDataReady()
    // {
        // Logger.LogInfo("Waiting for data loading");
        //
        // while (
        //     MapDataLib.mdItemLib == null ||
        //     !GameStatus.hasLoadMapData
        // )
        //     yield return new WaitForSecondsRealtime(0.1f);
        //
        // Manager.Injection();
    // }
}
