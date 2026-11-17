using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Export.MapDataStoryKnot;

public static class Export
{
    public static List<JObject> Main(MapDataStoryKnotLib mapDataStoryKnotLib)
    {
        List<JObject> rs =
        [
            .. mapDataStoryKnotLib.knotList.Select(u => new Model(u)
            ).Select(model => model.OutputJson())
        ];

        return rs;
    }
}