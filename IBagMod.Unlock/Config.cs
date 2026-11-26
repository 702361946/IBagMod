using BepInEx.Configuration;

namespace IBagMod.Unlock;

public static class Config
{
    public static ConfigEntry<bool> UnlockResolutionLimit { get; private set; }
    
    public static ConfigEntry<bool> UnlockAllStoryState { get; private set; }

    public static void Init(ConfigFile config)
    {
        UnlockResolutionLimit = config.Bind(
            "IBagMod.Unlock",
            nameof(UnlockResolutionLimit),
            true,
            "Skip the 540x960 resolution check in PreLoad.Update."
        );
        
        UnlockAllStoryState = config.Bind(
            "IBagMod.Unlock",
            nameof(UnlockAllStoryState),
            false,
            "Unlock all unlockable story nodes"
        );
    }
}