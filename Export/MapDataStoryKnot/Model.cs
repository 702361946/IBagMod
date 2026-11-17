using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Export.MapDataStoryKnot;

public class Model(MapDataStoryKnotUnit unit)
{
    // ReSharper disable once UnusedMember.Global
    public int EndingType = unit.endingType;

    // ReSharper disable once UnusedMember.Global
    public int ID = unit.id;

    // ReSharper disable once UnusedMember.Global
    public int KnotID = unit.knotId;

    // ReSharper disable once UnusedMember.Global
    public string KnotTitle = unit.knotTitle;

    // ReSharper disable once UnusedMember.Global
    public Vector2Int KnotV2Int = unit.knotVector2Int;

    // ReSharper disable once UnusedMember.Global
    public ModelMapDataOfficialSlot OfficialSlot = new(unit.officialSlot);

    // ReSharper disable once UnusedMember.Global
    public int TimeLineID = unit.timeLineId;

    public JObject OutputJson()
    {
        return JObject.FromObject(this);
    }
}

public class ModelMapDataOfficialSlot(MapDataOfficialSlot mapDataOfficialSlot)
{
    // ReSharper disable once UnusedMember.Global
    public int BagExp = mapDataOfficialSlot.bagExp;

    // ReSharper disable once UnusedMember.Global
    public int BagLv = mapDataOfficialSlot.bagLv;

    // ReSharper disable once UnusedMember.Global
    public List<int> IsImportant = mapDataOfficialSlot.isImportant;

    // ReSharper disable once UnusedMember.Global
    public List<int> ItemId = mapDataOfficialSlot.itemId;

    // ReSharper disable once UnusedMember.Global
    public List<int> ItemLv = mapDataOfficialSlot.itemLv;
}