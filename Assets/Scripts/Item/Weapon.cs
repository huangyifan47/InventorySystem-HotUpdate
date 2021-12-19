using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int damage { get; set; }
    public WeqponType wpType { get; set; }

    public Weapon(int id, string name, ItemType type, ItemQuality quality, string des, 
        int capacity, int buy, int sell, int damage, WeqponType wpType, string sprite)
    : base(id, name, type, quality, des, capacity, buy, sell,sprite)
    {
        this.damage = damage;
        this.wpType = wpType;
    }



    public enum WeqponType
    {
        None,MainHand,OffHand
    }

    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();

        string weaponText = "";
        switch (wpType)
        {
            case WeqponType.MainHand:
                weaponText = "主手";
                break;
            case WeqponType.OffHand:
                weaponText = "副手";
                break;
            default:
                break;
        }

        string newText = string.Format("{0}\n武器类型 : {1}\n攻击力 : {2}", text, weaponText, damage);

        return newText;
    }
}
