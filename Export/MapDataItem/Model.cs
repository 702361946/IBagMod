using Newtonsoft.Json.Linq;

namespace Export.MapDataItem;

public class Model(global::MapDataItem mapDataItem)
{
    public int ID = mapDataItem.id;
    public string Name = mapDataItem.name;
    public string Desc = mapDataItem.desc;

    public List<string> AttributeTypes = [
        .. mapDataItem.attriTypeList.Select(
            v => Enum.GetName(typeof(AttributeType), v)
        )
    ];
    
    public List<List<string>> AttributeCurveFuncList =
    [
        .. mapDataItem.attriFuncCoefList
            .Select(v => v
                .Select(__AttributeCurveFuncToString)
                .ToList()
            )
    ];

    public List<string> InferredAttribute = __GetAllInferredAttribute(mapDataItem);
    
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