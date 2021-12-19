using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 消耗品类
/// </summary>
public class Consumable : Item
{
    public int HP { get; set; }
    public int MP { get; set; }

    public Consumable(int id, string name, ItemType type, ItemQuality quality, string des, 
        int capacity, int buy, int sell,int hp,int mp,string sprite)
        :base(id,name,type,quality,des,capacity,buy,sell,sprite)
    {
        this.HP = hp;
        this.MP = mp;
    }

    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();

        string newText = string.Format("{0}\n<color=red>加血 : {1}</color>\n<color=blue>加蓝 : {2}</blue>", text,HP,MP);

        return newText;
    }

    public override string ToString()
    {
        string s = "" + ID + " " + itemType + " " + HP;
        return base.ToString();
    }
}
