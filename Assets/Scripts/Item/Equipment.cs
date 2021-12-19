using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    public int strength { get; set; }
    public int intellect { get; set; }
    public int agility { get; set; }
    public int stamina { get; set; }
    public EquipmentType equipType { get; set; }

    public Equipment(int id, string name, ItemType type, ItemQuality quality, string des, 
        int capacity, int buy, int sell,int strength,int intellect,int agility,int stamina,EquipmentType equipType, string sprite)
        : base(id, name, type, quality, des, capacity, buy, sell,sprite)
    {
        this.strength = strength;
        this.intellect = intellect;
        this.agility = agility;
        this.stamina = stamina;
        this.equipType = equipType;

    }

    public enum EquipmentType
    {
        None,
        Head,
        Neck,
        Ring,
        Bracer,
        Glove,
        Chest,
        Belt,
        Leg,
        Boots,
        Shoulder
    }

    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();
        string equipText = "";
        switch (equipType)
        {
            case EquipmentType.Head:
                equipText = "头部";
                break;
            case EquipmentType.Neck:
                equipText = "脖子";
                break;
            case EquipmentType.Ring:
                equipText = "戒指";
                break;
            case EquipmentType.Bracer:
                equipText = "护腕";
                break;
            case EquipmentType.Glove:
                equipText = "手套";
                break;
            case EquipmentType.Chest:
                equipText = "胸部";
                break;
            case EquipmentType.Belt:
                equipText = "腰带";
                break;
            case EquipmentType.Leg:
                equipText = "腿部";
                break;
            case EquipmentType.Boots:
                equipText = "靴子";
                break;
            default:
                break;
        }

        string newText = string.Format("{0}\n\n装备类型{1}力量 : {2}\n智力 : {3}\n敏捷 : {4}\n体力 : {5}\n", text, equipText, strength, intellect, agility, stamina);

        return newText;
    }

}
