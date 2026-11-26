using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace IBagMod.Unlock;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string PluginGuid = "702361946.IBagMod.Unlock";
    private const string PluginName = "IBagMod.Unlock";
    private const string PluginVersion = "1.0.0";
        
    public new static readonly ManualLogSource Logger = BepInEx.Logging.Logger.CreateLogSource("IBagMod");
    
    private void Awake()
    {
        IBagMod.Unlock.Config.Init(Config);
        
        // ReSharper disable once InvertIf
        if (Unlock.Config.UnlockResolutionLimit.Value)
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
        
        if (Unlock.Config.UnlockAllStoryState.Value)
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
    }
}
