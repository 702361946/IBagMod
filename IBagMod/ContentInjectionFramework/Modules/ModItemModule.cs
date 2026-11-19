using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace IBagMod.ContentInjectionFramework.Modules;

// public enum ItemEquipPosition
// {
//     None = 0,
//     Weapon = 1,
//     Head = 2,
//     Body = 3,
//     Leg = 4,
//     Foot = 5
// }

public class ModItemModule
{
    // ReSharper disable once NotAccessedField.Local
    private readonly JObject _config;
    private readonly List<List<List<float>>> _attributeCurveFuncList;
    private readonly List<AttributeType> _attributeTypes;
    private readonly string _desc;
    private readonly int _isLive;
    private readonly string _name;
    private readonly Color _barColor;
    private readonly Color _numColor;
    private readonly string _barColorStr;
    private readonly string _numColorStr;
    // public float BasicPriceCoef = 1f;
    // public List<int> PicIdList = [1];
    // public float ThrowPowerCoef;
    // public int ArrowFade;
    // public ItemEquipPosition EquipPosition = ItemEquipPosition.None;
    // public int WeaponType;

    public ModItemModule(
        JObject config,
        string name,
        string description,
        List<AttributeType> attributeTypes,
        List<List<List<float>>> attributeCurveFuncList,
        string barColorStr,
        string numColorStr,
        int isLive
    )
    {
        _config = config;
        _name = name ?? throw new Exception("name is null");
        _desc = description ?? "";

        attributeTypes ??= [];
        attributeCurveFuncList ??= [];
        AttributeCheck(
            out var rAttributeTypes,
            out var rAttributeCurveFuncList,
            attributeTypes,
            attributeCurveFuncList
        );
        _attributeTypes = rAttributeTypes;
        _attributeCurveFuncList = rAttributeCurveFuncList;

        barColorStr ??= "#000000";
        numColorStr ??= "#000000";

        if (barColorStr.Length != 7 && barColorStr.Length != 9 || barColorStr[0] != '#')
        {
            Plugin.Logger.LogWarning($"Non-standard color string: {barColorStr}");
            barColorStr = "#000000";
        }

        if (numColorStr.Length != 7 && numColorStr.Length != 9 || numColorStr[0] != '#')
        {
            Plugin.Logger.LogWarning($"Non-standard color string: {numColorStr}");
            numColorStr = "#000000";
        }
        
        _barColorStr = barColorStr;
        _numColorStr = numColorStr;
        
        if (!ColorUtility.TryParseHtmlString(barColorStr, out var color))
        {
            Plugin.Logger.LogWarning($"Invalid color string: {barColorStr}");
            color = Color.black;
        }

        _barColor = color;
        
        if (!ColorUtility.TryParseHtmlString(numColorStr, out var color2))
        {
            Plugin.Logger.LogWarning($"Invalid color string: {numColorStr}");
            color2 = Color.black;
        }
        
        _numColor = color2;
        
        _isLive = isLive;
    }

    private static void AttributeCheck(
        out List<AttributeType> attributeTypes,
        out List<List<List<float>>> attributeCurveFuncList,
        List<AttributeType> fAttributeTypes,
        List<List<List<float>>> fAttributeCurveFuncList
    )
    {
        if (fAttributeCurveFuncList.Count == fAttributeTypes.Count)
        {
            attributeTypes = fAttributeTypes;
            attributeCurveFuncList = fAttributeCurveFuncList;
        }
        else if (fAttributeCurveFuncList.Count > fAttributeTypes.Count)
        {
            Plugin.Logger.LogWarning(
                "AttributeCurveFuncList has exceeded AttributeTypes in length, "
                + "and the exceeding part will be discarded"
                );
            attributeTypes = fAttributeTypes;
            attributeCurveFuncList = fAttributeCurveFuncList.GetRange(0, fAttributeTypes.Count);
        }
        else
        {
            Plugin.Logger.LogWarning(
                "AttributeTypes has exceeded AttributeCurveFuncList in length, "
                + "and the exceeding part will be discarded");
            attributeTypes = fAttributeTypes.GetRange(0, fAttributeCurveFuncList.Count);
            attributeCurveFuncList = fAttributeCurveFuncList;
        }
    }

    /// <summary>
    ///     No ID has been assigned. Please pay attention to assigning one
    /// </summary>
    /// <returns></returns>
    public MapDataItem ModuleToGameItem()
    {
        return new MapDataItem
        {
            name = _name,
            desc = _desc,
            attriTypeList = _attributeTypes,
            attriFuncCoefList = _attributeCurveFuncList,
            barColorStr = _barColorStr,
            numColorStr = _numColorStr,
            barColor = _barColor,
            numColor = _numColor,
            isLive = _isLive
        };
    }
}