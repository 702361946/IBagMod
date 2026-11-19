using System.Collections.Generic;

namespace IBagMod.ContentInjectionFramework.Injection;

public static class InjectionItem
{
    public static bool Injection(List<MapDataItem> items)
    {
        var itemLib = MapDataLib.mdItemLib;
        if (itemLib is null)
        {
            Plugin.Logger.LogError("ItemLib is null");
            return false;
        }
        
        itemLib.item.AddRange(items);
        return true;
    }
}