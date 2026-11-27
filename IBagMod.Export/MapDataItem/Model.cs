using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace IBagMod.Export.MapDataItem;

public class Model(global::MapDataItem mapDataItem)
{
    // ReSharper disable once UnusedMember.Global
    public List<List<string>> AttributeCurveFuncList =
    [
        .. mapDataItem.attriFuncCoefList
            .Select(v => v
                .Select(__AttributeCurveFuncToString)
                .ToList()
            )
    ];

    // ReSharper disable once UnusedMember.Global
    public List<string> AttributeTypes =
    [
        .. mapDataItem.attriTypeList.Select(v => Enum.GetName(typeof(AttributeType), v)
        )
    ];

    // ReSharper disable once UnusedMember.Global
    public string Desc = mapDataItem.desc;

    // ReSharper disable once UnusedMember.Global
    public int ID = mapDataItem.id;

    // ReSharper disable once UnusedMember.Global
    public List<string> InferredAttribute = __GetAllInferredAttribute(mapDataItem);

    // ReSharper disable once UnusedMember.Global
    public string Name = mapDataItem.name;

    public JObject OutputJson()
    {
        return JObject.FromObject(this);
    }

    private static string __AttributeCurveFuncToString(List<float> q)
    {
        return q.Count switch
        {
            1 => $"f({q[0]})",
            2 => $"f({q[0]} + lv * {q[1]})",
            3 => $"f({q[0]} * lv^{q[1]} + {q[2]})",
            4 => $"f({q[0]} * (lv % {q[3]}) ^ 2 + {q[1]} * (lv % {q[3]}) + {q[2]})",
            6 => $"f({q[0]} * (lv % {q[3]}) ^ 2 + {q[1]} * (lv % {q[3]}) + {q[2]} + lv*{q[4]} + {q[5]})",
            _ => ""
        };
    }

    private static List<string> __GetAllInferredAttribute(global::MapDataItem mapDataItem)
    {
        List<string> rl = [];

        if (mapDataItem.isLive > 0) rl.Add("Live");
        if (mapDataItem.IsFood) rl.Add("Food");
        if (mapDataItem.IsCurePotion) rl.Add("CurePotion");
        if (mapDataItem.IsFixPotion) rl.Add("FixPotion");
        if (mapDataItem.IsBuffPotion) rl.Add("BuffPotion");
        if (mapDataItem.IsPoisonItem) rl.Add("PoisonItem");
        if (mapDataItem.IsStoneItem) rl.Add("StoneItem");
        if (mapDataItem.IsTrap) rl.Add("Trap");
        if (mapDataItem.IsBuff) rl.Add("Buff");
        if (mapDataItem.IsWeapon) rl.Add("Weapon");
        if (mapDataItem.IsOnHead) rl.Add("OnHead");
        if (mapDataItem.IsOnBody) rl.Add("OnBody");
        if (mapDataItem.IsOnLeg) rl.Add("OnLeg");
        if (mapDataItem.IsOnFoot) rl.Add("OnFoot");
        if (mapDataItem.IsArrowBag) rl.Add("ArrowBag");
        if (mapDataItem.IsCrystal) rl.Add("Crystal");
        if (mapDataItem.IsJewel) rl.Add("Jewel");

        return rl;
    }
}