using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : Inventory
{
    public int[] itemArray;

    private Player player;

    #region 单例模式
    private static Vendor _instance;
    public static Vendor Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("VendorPanel").GetComponent<Vendor>();
            }

            return _instance;
        }
    }
    #endregion

    public override void Start()
    {
        base.Start();
        InitShop();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Hide();
    }

    private void InitShop()
    {
        foreach(int id in itemArray)
        {
            SaveItem(id);
        }
    }
    /// <summary>
    /// 主角购买
    /// </summary>
    /// <param name="item"></param>
    public void BuyItem(Item item)
    {
        bool isSuccess = player.ConsumeCoin(item.buyPrice);
        if(isSuccess)
        {
            Knapsack.Instance.SaveItem(item);
        }
    }

    public void SellItem()
    {
        int amount = 1;
        if(Input.GetKey(KeyCode.LeftControl))
        {
            amount = 1;
        }
        else
        {
            amount = InventoryManager.Instance.PickedItem.Amount;
        }
        int count = InventoryManager.Instance.PickedItem.Item.sellPrice * InventoryManager.Instance.PickedItem.Amount;
        player.EarnCoin(amount);
        InventoryManager.Instance.PickedItem.ReduceAmount(amount);
        if(InventoryManager.Instance.PickedItem.Amount <= 0)
        {
            InventoryManager.Instance.RemoveItem(amount);
        }
    }
}
