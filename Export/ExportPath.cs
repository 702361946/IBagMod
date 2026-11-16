using System.IO;
using BepInEx;

namespace Export;

public static class ExportPath
{
    private static readonly string RootPath = InitRootPath();
    public static readonly string OutputPath = InitOutPath();

    private static string InitRootPath()
    {
        var dllPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var dllDir = Path.GetDirectoryName(dllPath) ?? Paths.PluginPath;
        return Path.GetFullPath(dllDir);
    }
    
    private static string InitOutPath()
    {
        return Path.Combine(RootPath, "out");
    }
}