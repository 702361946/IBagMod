using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Export.MapDataItem;

public static class Export
{
    public static List<JObject> Main(MapDataItemLib mapDataItemLib)
    {
        List<JObject> rs =
        [
            .. mapDataItemLib.item.Select(
                mapDataItem => new Model(mapDataItem)
            ).Select(model => model.OutputJson())
        ];

        return rs;
    }
}