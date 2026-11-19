using System.Collections.Generic;
using System.Linq;

namespace IBagMod.ContentInjectionFramework.Injection;

public static class InjectionItem
{
    public static bool Injection(List<MapDataItem> items)
    {
        if (items is null)
        {
            Plugin.Logger.LogWarning("The injected content is not provided");
            return false;
        }
        var itemLib = MapDataLib.mdItemLib;
        if (itemLib is null)
        {
            Plugin.Logger.LogError("ItemLib is null");
            return false;
        }
        if (itemLib.item is null)
        {
            Plugin.Logger.LogError("ItemLib.Item is null");
            return false;
        }

        var idFlag = itemLib.item.Count == 0
            ? 0
            : itemLib.item.Where(i => i is not null).Max(i => i.id) + 1;

        foreach (var item in items)
        {
            item.id = idFlag;
            idFlag++;
            itemLib.item.Add(item);
        }
        
        return true;
    }
}