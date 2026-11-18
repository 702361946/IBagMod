using System;
using System.Collections.Generic;

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
    public readonly string Name;
    public readonly string Desc;
    public readonly List<AttributeType> AttributeTypes;
    public readonly List<List<List<int>>> AttributeCurveFuncList;
    public readonly string BarColorStr;
    public readonly string NumColorStr;
    public readonly int IsLive;
    // public float BasicPriceCoef = 1f;
    // public List<int> PicIdList = [1];
    // public float ThrowPowerCoef;
    // public int ArrowFade;
    // public ItemEquipPosition EquipPosition = ItemEquipPosition.None;
    // public int WeaponType;

    public ModItemModule(
        string name,
        string description,
        List<AttributeType> attributeTypes,
        List<List<List<int>>> attributeCurveFuncList,
        string barColorStr,
        string numColorStr,
        int isLive
    )
    {
        Name = name ?? throw new Exception("name is null");
        Desc = description ?? "";
        
        attributeTypes ??= [];
        attributeCurveFuncList ??= [];
        AttributeCheck(
            out var rAttributeTypes,
            out var rAttributeCurveFuncList,
            attributeTypes,
            attributeCurveFuncList
        );
        AttributeTypes = rAttributeTypes;
        AttributeCurveFuncList = rAttributeCurveFuncList;
        
        BarColorStr = barColorStr ?? "#FFFFFF";
        NumColorStr = numColorStr ?? "#FFFFFF";
        IsLive = isLive;
    }

    private static void AttributeCheck(
        out List<AttributeType> attributeTypes,
        out List<List<List<int>>> attributeCurveFuncList,
        List<AttributeType> fAttributeTypes,
        List<List<List<int>>> fAttributeCurveFuncList
    )
    {
        if (fAttributeCurveFuncList.Count == fAttributeTypes.Count)
        {
            attributeTypes = fAttributeTypes;
            attributeCurveFuncList = fAttributeCurveFuncList;
        }
        else if (fAttributeCurveFuncList.Count > fAttributeTypes.Count)
        {
            attributeTypes = fAttributeTypes;
            attributeCurveFuncList = fAttributeCurveFuncList.GetRange(0, fAttributeTypes.Count);
        }
        else
        {
            attributeTypes = fAttributeTypes.GetRange(0, fAttributeCurveFuncList.Count);
            attributeCurveFuncList = fAttributeCurveFuncList;
        }
    }
}