using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : Inventory
{
    private EquipmentSlot mainHandSlot;
    private EquipmentSlot offHandSlot;

    private Text propertyText;
    private Player player;

    #region 单例模式
    private static CharacterPanel _instance;

    public static CharacterPanel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("CharacterPanel").GetComponent<CharacterPanel>();
            }

            return _instance;
        }

    }
    #endregion

    public override void Start()
    {
        base.Start();
        mainHandSlot = transform.Find("MainHand").GetComponent<EquipmentSlot>();
        offHandSlot = transform.Find("OffHand").GetComponent<EquipmentSlot>();

        propertyText = transform.Find("PropertyPanel/Text").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        UpdatePropertyText();
    }

    public void PutOn(Item item)
    {
        Item exitedItem = null;
        foreach(Slot slot in slotList)
        {
            EquipmentSlot equipSlot = (EquipmentSlot)slot;
            if(equipSlot.JudgeItem(item))
            {
                if(equipSlot.transform.childCount > 0)
                {
                    exitedItem = equipSlot.transform.GetChild(0).GetComponent<ItemUI>().Item;
                    equipSlot.transform.GetChild(0).GetComponent<ItemUI>().SetItem(item, 1);
                }
                else
                {
                    equipSlot.StoreItem(item);
                }
                break;
            }
        }
        Knapsack.Instance.SaveItem(exitedItem);

        UpdatePropertyText();
    }

    public void PutOff(Item item)
    {
        Knapsack.Instance.SaveItem(item);
        UpdatePropertyText();
    }

    private void UpdatePropertyText()
    {
        Debug.Log("updateproperty");
        int strength = 0, intellect = 0, agility = 0,stamina = 0, damage = 0;
        foreach(EquipmentSlot slot in slotList)
        {
            if(slot.transform.childCount > 0)
            {
                Item item = slot.transform.GetChild(0).GetComponent<ItemUI>().Item;
                if(item is Equipment)
                {
                    Equipment e = (Equipment)item;
                    strength += e.strength;
                    intellect += e.intellect;
                    agility += e.agility;
                    stamina += e.stamina;
                }
                else if(item is Weapon)
                {
                    damage += ((Weapon)item).damage;
                }
            }
        }
        strength += player.BasicStrength;
        intellect += player.BasicIntellect;
        agility += player.BasicAgility;
        stamina += player.BasicStamina;
        damage += player.BasicDamage;
        string text = string.Format("力量：{0}\n智力：{1}\n敏捷：{2}\n体力：{3}\n攻击力：{4}",strength,intellect,agility,stamina,damage);
        propertyText.text = text;
    }




}
