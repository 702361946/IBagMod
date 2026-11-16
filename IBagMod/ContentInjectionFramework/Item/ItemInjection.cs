using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

namespace IBagMod.ContentInjectionFramework.Item;

public static class ItemInjection
{
    public static MapDataItem Add(ItemDefinition definition)
    {
        if (definition is null)
        {
            throw new ArgumentNullException(nameof(definition));
        }

        var itemLib = MapDataLib.mdItemLib
                      ?? throw new InvalidOperationException("MapDataLib.mdItemLib is not loaded.");

        var itemId = itemLib.item.Count + 1;

        NormalizeAttributeListLengths(definition);
        Validate(definition);

        var item = CreateItem(definition, itemId);
        RegisterEquipRanges(itemLib, item, definition);
        RegisterThrowPower(itemLib, item, definition.ThrowPowerCoef);
        RegisterArrowFade(itemLib, item, definition.ArrowFade);

        itemLib.item.Add(item);
        itemLib.count = itemLib.item.Count;

        RegisterKeyword(item.name);
        ExtendWikiState(itemLib.item.Count);

        return item;
    }

    private static void NormalizeAttributeListLengths(ItemDefinition definition)
    {
        if (definition.AttributeTypes is null || definition.AttributeCurveFuncList is null)
        {
            return;
        }

        var attributeCount = definition.AttributeTypes.Count;
        var curveCount = definition.AttributeCurveFuncList.Count;

        if (attributeCount == curveCount)
        {
            return;
        }

        var keepCount = Math.Min(attributeCount, curveCount);
        var removedAttributeCount = attributeCount - keepCount;
        var removedCurveCount = curveCount - keepCount;

        Debug.LogWarning(
            $"[IBagMod] 物品 {definition.Name} 的 AttributeTypes({attributeCount}) 与 AttributeCurveFuncList({curveCount}) 数量不一致，"
            + $"已保留前 {keepCount} 项，丢弃多余属性 {removedAttributeCount} 个、曲线 {removedCurveCount} 组。"
        );

        if (removedAttributeCount > 0)
        {
            definition.AttributeTypes.RemoveRange(keepCount, removedAttributeCount);
        }

        if (removedCurveCount > 0)
        {
            definition.AttributeCurveFuncList.RemoveRange(keepCount, removedCurveCount);
        }
    }

    private static void Validate(ItemDefinition definition)
    {
        if (string.IsNullOrWhiteSpace(definition.Name))
        {
            throw new ArgumentException("Item name must not be empty.", nameof(definition));
        }

        if (definition.AttributeTypes is null)
        {
            throw new ArgumentException("AttributeTypes must not be null.", nameof(definition));
        }

        if (definition.AttributeCurveFuncList is null)
        {
            throw new ArgumentException("AttributeCurveFuncList must not be null.", nameof(definition));
        }

        if (definition.PicIdList is null || definition.PicIdList.Count == 0)
        {
            throw new ArgumentException("PicIdList must contain at least one texture ID.", nameof(definition));
        }

        if (definition.PicIdList.Any(picId => picId <= 0))
        {
            throw new ArgumentException("PicIdList texture IDs must be positive.", nameof(definition));
        }

        if (definition.AttributeTypes.Count != definition.AttributeCurveFuncList.Count)
        {
            throw new ArgumentException(
                "AttributeTypes and AttributeCurveFuncList must have the same number of entries.",
                nameof(definition)
            );
        }

        if (definition.AttributeTypes.Distinct().Count() != definition.AttributeTypes.Count)
        {
            throw new ArgumentException("AttributeTypes must not contain duplicates.", nameof(definition));
        }

        for (var index = 0; index < definition.AttributeTypes.Count; index++)
        {
            var attributeType = definition.AttributeTypes[index];

            if (!Enum.IsDefined(typeof(AttributeType), attributeType))
            {
                throw new ArgumentException(
                    $"AttributeTypes[{index}] contains an undefined AttributeType value: {(int)attributeType}.",
                    nameof(definition)
                );
            }

            ValidateAttributeCurves(definition.AttributeCurveFuncList[index], index);
        }

        if (float.IsNaN(definition.BasicPriceCoef) || float.IsInfinity(definition.BasicPriceCoef))
        {
            throw new ArgumentException("BasicPriceCoef must be a finite number.", nameof(definition));
        }

        if (definition.ArrowFade < 0)
        {
            throw new ArgumentException("ArrowFade must not be negative.", nameof(definition));
        }

        if (!Enum.IsDefined(typeof(ItemEquipPosition), definition.EquipPosition))
        {
            throw new ArgumentException(
                $"Undefined EquipPosition value: {(int)definition.EquipPosition}.",
                nameof(definition)
            );
        }

        if (definition.WeaponType is < 0 or > 4)
        {
            throw new ArgumentException("WeaponType must be between 0 and 4.", nameof(definition));
        }

        if (definition.EquipPosition != ItemEquipPosition.Weapon && definition.WeaponType != 0)
        {
            throw new ArgumentException(
                "WeaponType can only be set when EquipPosition is Weapon.",
                nameof(definition)
            );
        }
    }

    private static void ValidateAttributeCurves(List<List<int>> attributeCurves, int attributeIndex)
    {
        if (attributeCurves is null || attributeCurves.Count == 0)
        {
            throw new ArgumentException(
                $"AttributeCurveFuncList[{attributeIndex}] must contain at least one curve."
            );
        }

        for (var curveIndex = 0; curveIndex < attributeCurves.Count; curveIndex++)
        {
            var curve = attributeCurves[curveIndex];

            if (curve is null)
            {
                throw new ArgumentException(
                    $"AttributeCurveFuncList[{attributeIndex}][{curveIndex}] must not be null."
                );
            }

            if (curve.Count is not (1 or 2 or 3 or 4 or 6))
            {
                throw new ArgumentException(
                    $"AttributeCurveFuncList[{attributeIndex}][{curveIndex}] must contain 1, 2, 3, 4 or 6 coefficients, but got {curve.Count}."
                );
            }

            if (curve.Count is 4 or 6 && curve[3] <= 0)
            {
                throw new ArgumentException(
                    $"AttributeCurveFuncList[{attributeIndex}][{curveIndex}] uses a cycle period that must be greater than 0."
                );
            }
        }
    }

    private static MapDataItem CreateItem(ItemDefinition definition, int itemId)
    {
        var item = new MapDataItem
        {
            id = itemId,
            name = definition.Name,
            desc = definition.Desc,
            attriTypeStr = string.Join(
                "|",
                definition.AttributeTypes.Select(type => ((int)type).ToString(CultureInfo.InvariantCulture))
            ),
            attriFuncCoefStr = FormatAttributeCurveFuncList(definition.AttributeCurveFuncList),
            barColorStr = definition.BarColorStr,
            numColorStr = definition.NumColorStr,
            basicPriceCoef = definition.BasicPriceCoef,
            isLive = definition.IsLive
        };

        item.attriTypeList.AddRange(definition.AttributeTypes);

        foreach (var attributeCurves in definition.AttributeCurveFuncList)
        {
            item.attriFuncCoefList.Add(
                [
                    .. attributeCurves
                        .Select(curve => curve.Select(coefficient => (float)coefficient).ToList())
                ]
            );
        }

        item.picIdList.AddRange(definition.PicIdList);
        item.containCrystalId = item.picIdList.Count >= 2 ? item.picIdList[1] : 0;

        if (ColorUtility.TryParseHtmlString(definition.BarColorStr, out var barColor))
        {
            item.barColor = barColor;
        }

        if (ColorUtility.TryParseHtmlString(definition.NumColorStr, out var numColor))
        {
            item.numColor = numColor;
        }

        return item;
    }

    private static string FormatAttributeCurveFuncList(List<List<List<int>>> attributeCurveFuncList)
    {
        return string.Join(
            "|",
            attributeCurveFuncList.Select(
                attributeCurves => string.Join(
                    ",",
                    attributeCurves.Select(
                        curve => string.Join(
                            "#",
                            curve.Select(coef => coef.ToString(CultureInfo.InvariantCulture))
                        )
                    )
                )
            )
        );
    }

    private static void RegisterEquipRanges(
        MapDataItemLib itemLib,
        MapDataItem item,
        ItemDefinition definition
    )
    {
        EnsureEquipRangeSlots(itemLib);

        for (var index = 0; index < itemLib.equipIdRangeList.Count; index++)
        {
            itemLib.equipIdRangeList[index].Remove(item.id);
            itemLib.equipIdRangeStr[index] = FormatIdRange(itemLib.equipIdRangeList[index]);
        }

        var equipIndex = (int)definition.EquipPosition - 1;
        if (equipIndex >= 0)
        {
            itemLib.equipIdRangeList[equipIndex].Add(item.id);
            itemLib.equipIdRangeStr[equipIndex] = FormatIdRange(itemLib.equipIdRangeList[equipIndex]);
        }

        foreach (var t in itemLib.weaponIdRangeList)
        {
            t.Remove(item.id);
        }

        if (definition.EquipPosition == ItemEquipPosition.Weapon
            && definition.WeaponType is >= 1 and <= 3)
        {
            var weaponIndex = definition.WeaponType - 1;
            itemLib.weaponIdRangeList[weaponIndex].Add(item.id);
        }

        for (var index = 0; index < itemLib.weaponIdRangeList.Count; index++)
        {
            itemLib.weaponIdRangeStr[index] = FormatIdRange(itemLib.weaponIdRangeList[index]);
        }
    }

    private static void EnsureEquipRangeSlots(MapDataItemLib itemLib)
    {
        const int equipPositionCount = 5;
        const int weaponTypeCount = 3;

        while (itemLib.equipIdRangeList.Count < equipPositionCount)
        {
            itemLib.equipIdRangeList.Add([]);
        }

        while (itemLib.equipIdRangeStr.Count < itemLib.equipIdRangeList.Count)
        {
            itemLib.equipIdRangeStr.Add("");
        }

        while (itemLib.weaponIdRangeList.Count < weaponTypeCount)
        {
            itemLib.weaponIdRangeList.Add([]);
        }

        while (itemLib.weaponIdRangeStr.Count < itemLib.weaponIdRangeList.Count)
        {
            itemLib.weaponIdRangeStr.Add("");
        }
    }

    private static void RegisterThrowPower(
        MapDataItemLib itemLib,
        MapDataItem item,
        float throwPowerCoef
    )
    {
        item.throwPowerCoef = throwPowerCoef;

        if (throwPowerCoef <= 0f)
        {
            return;
        }

        var coefEntry = itemLib.throwPowerCoefList.FirstOrDefault(
            entry => Math.Abs(entry.throwCoef - throwPowerCoef) < 0.0001f
        );

        if (coefEntry is null)
        {
            coefEntry = new MapDataThrowCoef { throwCoef = throwPowerCoef };
            itemLib.throwPowerCoefList.Add(coefEntry);
        }

        if (!coefEntry.idList.Contains(item.id))
        {
            coefEntry.idList.Add(item.id);
        }
    }

    private static void RegisterArrowFade(MapDataItemLib itemLib, MapDataItem item, int arrowFade)
    {
        item.arrowFade = arrowFade;

        if (arrowFade <= 0)
        {
            return;
        }

        var fadeEntry = itemLib.arrowFadeCoefList.FirstOrDefault(
            entry => entry.arrowFadeCoef == arrowFade
        );

        if (fadeEntry is null)
        {
            fadeEntry = new MapDataArrowFadeCoef(
                arrowFade,
                item.id.ToString(CultureInfo.InvariantCulture)
            );
            itemLib.arrowFadeCoefList.Add(fadeEntry);
            return;
        }

        if (!fadeEntry.idList.Contains(item.id))
        {
            fadeEntry.idList.Add(item.id);
        }
    }

    private static void RegisterKeyword(string itemName)
    {
        if (!MapDataKeyword.itemName.Contains(itemName))
        {
            MapDataKeyword.itemName.Add(itemName);
        }
    }

    private static void ExtendWikiState(int itemCount)
    {
        var wikiState = GameSlot.wikiCompleteState;

        if (wikiState is null)
        {
            return;
        }

        wikiState.itemCollection ??= [];
        wikiState.itemRead ??= [];

        while (wikiState.itemCollection.Count < itemCount)
        {
            wikiState.itemCollection.Add(0);
        }

        while (wikiState.itemRead.Count < itemCount)
        {
            wikiState.itemRead.Add(0);
        }
    }

    private static string FormatIdRange(List<int> itemIds)
    {
        return string.Join("#", itemIds.Select(id => id.ToString(CultureInfo.InvariantCulture)));
    }
}
