using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    #region 单例模式
    private static InventoryManager _instance;

    public static InventoryManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            }

            return _instance;
        }

    }
    #endregion

    /// <summary>
    /// 物品信息列表
    /// </summary>
    private List<Item> itemList;

    #region ToolTip
    private ToolTip toolTip;

    private bool isToolTipShow = false;
    #endregion 

    private Canvas canvas;
    

    private Vector2 toolTipPositionOffset = new Vector2(10,-10);


    private bool isPickedItem = false;
    public bool IsPickedItem
    {
        get
        {
            return isPickedItem;
        }
    }
    private ItemUI pickedItem;
    public ItemUI PickedItem
    {
        get
        {
            return pickedItem;
        }
    }

    private void Awake()
    {
        ParseItemJson();
    }

    private void Start()
    {
        toolTip = GameObject.FindObjectOfType<ToolTip>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        pickedItem = GameObject.Find("PickedItem").GetComponent<ItemUI>();
        pickedItem.Hide();
        //ParseItemJson();
    }

    private void Update()
    {
        if(isPickedItem)
        {
            //控制拾起物品跟随鼠标
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            pickedItem.SetLocalPosition(position);
            //Debug.Log("鼠标位置 ：" + Input.mousePosition);
            //Debug.Log("item位置 ：" + pickedItem.transform.position);

        }
        else if(isToolTipShow)
        {
            //控制面板跟随鼠标
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            toolTip.SetLocalPosition(position + toolTipPositionOffset);
        }

        //物品丢弃
        if(isPickedItem && Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
        {
            isPickedItem = false;
            pickedItem.Hide();
        }
    }

    /// <summary>
    /// 解析物品信息
    /// </summary>
    void ParseItemJson()
    {
        itemList = new List<Item>();

        //文本在Unity中为 TextAsset
        TextAsset itemText = Resources.Load<TextAsset>("Items");
        string itemJson = itemText.text;
        Debug.Log(itemJson);
        //Dictionary<string, List<Item>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Item>>>(itemJson);
        JsonData itemData = JsonMapper.ToObject(itemJson);

        //foreach(JsonData temp in itemData )
        for(int i = 0;i < itemData.Count; i++)
        {
            int id = (int)itemData[i]["id"];
            string name = itemData[i]["name"].ToString();

            //将读取出的字符串转换成为枚举类型
            Item.ItemQuality quality = (Item.ItemQuality)System.Enum.Parse(typeof(Item.ItemQuality), itemData[i]["quality"].ToString());
            string des = itemData[i]["description"].ToString();
            int capacity = (int)itemData[i]["capacity"];
            int buyPrice = (int)itemData[i]["buyPrice"];
            int sellPrice = (int)itemData[i]["sellPrice"];
            string sprite = itemData[i]["sprite"].ToString();

            Item.ItemType type = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), itemData[i]["type"].ToString());

            Item item = null;
            switch (type)
            {
                case Item.ItemType.Consumable:
                    int hp = (int)itemData[i]["hp"];
                    int mp = (int)itemData[i]["mp"];
                    item = new Consumable(id, name, type, quality, des, capacity, buyPrice, sellPrice, hp, mp, sprite);
                    break;
                case Item.ItemType.Equipment:
                    //
                    int strength = (int)itemData[i]["strength"];
                    int intellect = (int)itemData[i]["intellect"];
                    int agility = (int)itemData[i]["agility"];
                    int stamina = (int)itemData[i]["stamina"];
                    Equipment.EquipmentType equipType = (Equipment.EquipmentType)System.Enum.Parse(typeof(Equipment.EquipmentType), itemData[i]["equipType"].ToString());
                    item = new Equipment(id, name, type, quality, des, capacity, buyPrice, sellPrice, strength, intellect, agility, stamina, equipType, sprite);
                    break;
                case Item.ItemType.Weapon:
                    //
                    int damage = (int)itemData[i]["damage"];
                    Weapon.WeqponType wpType = (Weapon.WeqponType)System.Enum.Parse(typeof(Weapon.WeqponType), itemData[i]["weaponType"].ToString());
                    item = new Weapon(id, name, type, quality, des, capacity, buyPrice, sellPrice, damage, wpType, sprite);
                    break;
                case Item.ItemType.Material:
                    //
                    item = new Material(id, name, type, quality, des, capacity, buyPrice, sellPrice, sprite);
                    break;
            }

            itemList.Add(item);

        }

    }



    public Item GetItemById(int id)
    {
        foreach(Item item in itemList)
        {
            if(item.ID == id)
            {
                return item;
            }
        }

        return null;
    }

    public void ShowToolTip(string content)
    {
        if (isPickedItem) return;
        isToolTipShow = true;
        toolTip.Show(content);
    }

    public void HideToolTip()
    {
        isToolTipShow = false;
        toolTip.Hide();
    }

    //取出物品槽中指定数量物品
    public void PickupItem(Item item,int amount)
    {
        PickedItem.SetItem(item,amount);
        isPickedItem = true;

        PickedItem.Show();
        toolTip.Hide();

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
        pickedItem.SetLocalPosition(position);
    }

    public void RemoveItem(int amount = 1)
    {
        PickedItem.ReduceAmount(amount);
        if(PickedItem.Amount <= 0)
        {
            isPickedItem = false;
            PickedItem.Hide();
        }
    }

    public void SaveInventory()
    {
        Knapsack.Instance.SaveInventory();
        Chest.Instance.SaveInventory();
        CharacterPanel.Instance.SaveInventory();
        Forge.Instance.SaveInventory();
        PlayerPrefs.SetInt("CoinAmount", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CoinAmount);
    }

    public void LoadInventory()
    {
        Knapsack.Instance.LoadInventory();
        Chest.Instance.LoadInventory();
        CharacterPanel.Instance.LoadInventory();
        Forge.Instance.LoadInventory();
        if(PlayerPrefs.HasKey("CoinAmount"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CoinAmount = PlayerPrefs.GetInt("PlayerAmount");
        }
    }
}
