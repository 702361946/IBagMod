using BepInEx.Configuration;

namespace IBagMod;

public static class Config
{
    public static ConfigEntry<bool> UnlockResolutionLimit { get; private set; }

    public static void Init(ConfigFile config)
    {
        UnlockResolutionLimit = config.Bind(
            "IBagMod",
            nameof(UnlockResolutionLimit),
            true,
            "Skip the 540x960 resolution check in PreLoad.Update."
        );
    }
}