using System.IO;
using BepInEx;

namespace IBagMod;

public static class PluginPath
{
    private static readonly string RootPath = InitRootPath();
    public static readonly string ModPath = InitModPath();

    private static string InitRootPath()
    {
        var dllPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var dllDir = Path.GetDirectoryName(dllPath) ?? Paths.PluginPath;
        return Path.GetFullPath(dllDir);
    }
    
    private static string InitModPath()
    {
        return Path.Combine(RootPath, "Mod");
    }
}