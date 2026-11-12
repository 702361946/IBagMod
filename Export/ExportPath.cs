using BepInEx;

namespace Export;

public class ExportPath
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public static string RootPath = InitRootPath();
    public static string OutputPath = InitOutPath();

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