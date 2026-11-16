using BepInEx;
using HarmonyLib;

namespace IBagMod;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string PluginGuid = "702361946.IBagMod";
    private const string PluginName = "IBagMod";
    private const string PluginVersion = "1.0.0";
    
    private void Awake()
    {
        IBagMod.Config.Init(Config);

        try
        {
            ContentInjectionFramework.InjectionManager.Init();
            Harmony.CreateAndPatchAll(typeof(ContentInjectionFramework.MapDataLibLoadPatch));
        }
        catch (System.Exception exception)
        {
            Logger.LogError($"CIF 初始化失败：{exception}");
        }

        if (IBagMod.Config.UnlockResolutionLimit.Value)
        {
            Harmony.CreateAndPatchAll(typeof(UnlockResolutionLimit.Patch));
        }
    }
}
