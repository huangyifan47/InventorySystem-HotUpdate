using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region property
    private int basicStrength = 10;
    private int basicIntellect = 10;
    private int basicAgility = 10;
    private int basicStamina = 10;
    private int basicDamage = 10;

    public int BasicStrength
    {
        get
        {
            return basicStrength;
        }
    }
    public int BasicIntellect
    {
        get
        {
            return basicIntellect;
        }
    }
    public int BasicAgility
    {
        get
        {
            return basicAgility;
        }
    }
    public int BasicStamina
    {
        get
        {
            return basicStamina;
        }
    }
    public int BasicDamage
    {
        get
        {
            return basicDamage;
        }
    }
    #endregion

    private int coinAmount = 100;

    private Text coinText;

    public int CoinAmount
    {
        get
        {
            return coinAmount;
        }
        set
        {
            coinAmount = value;
            coinText.text = coinAmount.ToString();
        }
    }

    

    private void Start()
    {
        coinText = GameObject.Find("Coin").GetComponentInChildren<Text>();
        coinText.text = coinAmount.ToString();
    }

    void Update()
    {
        //随机一个物品放入背包
        if(Input.GetKeyDown(KeyCode.G))
        {
            int id = Random.Range(1, 17);
            Knapsack.Instance.SaveItem(id);
        }

        //控制背包显示和隐藏
        if(Input.GetKeyDown(KeyCode.T))
        {
            Knapsack.Instance.DisplaySwitch();
        }

        //控制箱子显示和隐藏
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Chest.Instance.DisplaySwitch();
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            CharacterPanel.Instance.DisplaySwitch();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Vendor.Instance.DisplaySwitch();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Forge.Instance.DisplaySwitch();
        }
    }

    /// <summary>
    /// 花费金币
    /// </summary>
    /// <param name="amount"></param>
    public bool ConsumeCoin(int amount)
    {
        if(coinAmount >= amount)
        {
            coinAmount -= amount;
            coinText.text = coinAmount.ToString();
            return true;
        }

        return true;
    }
    /// <summary>
    /// 获得金币
    /// </summary>
    /// <param name="amount"></param>
    public void EarnCoin(int amount)
    {
        coinAmount += amount;
        coinText.text = coinAmount.ToString();
    }
}
