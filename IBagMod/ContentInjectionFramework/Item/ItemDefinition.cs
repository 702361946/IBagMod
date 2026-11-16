using System.Collections.Generic;

namespace IBagMod.ContentInjectionFramework.Item;

public enum ItemEquipPosition
{
    None = 0,
    Weapon = 1,
    Head = 2,
    Body = 3,
    Leg = 4,
    Foot = 5
}

public sealed class ItemDefinition
{
    public string Name = "";
    public string Desc = "";
    public List<AttributeType> AttributeTypes = [];
    public List<List<List<int>>> AttributeCurveFuncList = [];
    public string BarColorStr = "#FFFFFF";
    public string NumColorStr = "#FFFFFF";
    public float BasicPriceCoef = 1f;
    public List<int> PicIdList = [1];
    public int IsLive;
    public float ThrowPowerCoef;
    public int ArrowFade;
    public ItemEquipPosition EquipPosition = ItemEquipPosition.None;
    public int WeaponType;
}
