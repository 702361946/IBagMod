using HarmonyLib;
using UnityEngine;

namespace IBagMod.UnlockAllStoryState;

[HarmonyPatch(typeof(StoryCompleteState), "Load")]
public static class Patch
{
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once UnusedMember.Global
    public static void Postfix(StoryCompleteState __instance)
    {
        if (__instance == null)
            return;
        
        __instance.FullStoryState();
        
        GameSlot.storyCompleteState = __instance;
        
        PlayerPrefs.SetString("storyCompleteState", __instance.DataStr);
        PlayerPrefs.Save();
    }
}