using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using IBagMod.ContentInjectionFramework;
using IBagMod.ContentInjectionFramework.Injection;

namespace IBagMod;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string PluginGuid = "702361946.IBagMod";
    private const string PluginName = "IBagMod";
    private const string PluginVersion = "1.0.0";

    public new static readonly ManualLogSource Logger = BepInEx.Logging.Logger.CreateLogSource("IBagMod");
    
    private void Awake()
    {
        IBagMod.Config.Init(Config);
        if (!Manager.Init())
        {
            Logger.LogError("CIF init failed");
        }
        
        try
        {
            Harmony.CreateAndPatchAll(typeof(MapDataLibLoadPatch));
        }
        catch (Exception exception)
        {
            Logger.LogError($"CIF init error: {exception}");
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
    }
}
