using HarmonyLib;

namespace IBagMod.UnlockResolutionLimit;

[HarmonyPatch(typeof(PreLoad), "Update")]
public static class Patch
{
    private static readonly AccessTools.FieldRef<PreLoad, bool> HasStartRef =
        AccessTools.FieldRefAccess<PreLoad, bool>("hasStart");

    // ReSharper disable once InconsistentNaming
    // ReSharper disable once UnusedMember.Global
    public static bool Prefix(PreLoad __instance)
    {
        if (HasStartRef(__instance))
        {
            return false;
        }

        __instance.LoadGame();
        return false;
    }
}