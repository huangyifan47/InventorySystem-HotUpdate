using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品基类
/// </summary>
public class Item
{
    public int ID { get; set; }
    public string itemName { get; set; }

    public ItemType itemType { get; set; }

    public ItemQuality quality { get; set; }
    public string description { get; set; }
    public int capacity { get; set; }
    public int buyPrice { get; set; }
    public int sellPrice { get; set; }
    public string sprite { get; set; }

    public Item()
    {
        this.ID = -1;
    }

    public Item(int id,string name,ItemType type,ItemQuality quality,string des,
        int capacity,int buy,int sell,string sprite)
    {
        this.ID = id;
        this.itemName = name;
        this.itemType = type;
        this.quality = quality;
        this.description = des;
        this.capacity = capacity;
        this.buyPrice = buy;
        this.sellPrice = sell;
        this.sprite = sprite;
    }

    public enum ItemType
    {
        Consumable,
        Equipment,
        Weapon,
        Material
    }

    public enum ItemQuality
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Artifact
    }

    /// <summary>
    /// 得到提示面板显示的内容
    /// </summary>
    /// <returns></returns>
    public virtual string GetToolTipText()
    {
        
        string color = "";
        switch (quality)
        {
            case ItemQuality.Common:
                color = "gray";
                break;
            case ItemQuality.Rare:
                color = "lime";
                break;
            case ItemQuality.Epic:
                color = "yellow";
                break;
            case ItemQuality.Legendary:
                color = "orange";
                break;
            case ItemQuality.Artifact:
                color = "red";
                break;
        }
        string text = string.Format("<color={4}>{0}</color>\n购买价格：{1}  出售价格：{2}\n<size=10>{3}</size>",itemName,buyPrice,sellPrice,description,color);
        //text += itemName + "\n";
        //text += "价格 ：" + sellPrice + "\n";
        //text += description + "\n";
        //text += itemName + "\n";
        return text;
    }
}
