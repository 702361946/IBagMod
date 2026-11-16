using HarmonyLib;

namespace IBagMod.ContentInjectionFramework;

[HarmonyPatch(typeof(MapDataLib), nameof(MapDataLib.Load))]
public static class MapDataLibLoadPatch
{
    [HarmonyPostfix]
    // ReSharper disable once UnusedMember.Global
    public static void Postfix()
    {
        InjectionManager.ApplyPendingItems();
    }
}
