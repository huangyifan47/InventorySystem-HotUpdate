using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    protected Slot[] slotList;

    private float targetalpha = 1;
    private float smoothing = 6;
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    public virtual void Start()
    {
        //slotList = new List<Slot>();
        slotList = GetComponentsInChildren<Slot>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if(canvasGroup.alpha != targetalpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetalpha, smoothing * Time.deltaTime);
            if(Mathf.Abs(canvasGroup.alpha - targetalpha) < .1f)
            {
                canvasGroup.alpha = targetalpha;
            }
        }
    }

    public bool SaveItem(int id)
    {
        Item item = InventoryManager.Instance.GetItemById(id);
        return SaveItem(item);
    }

    public bool SaveItem(Item item)
    {
        if(item == null)
        {
            Debug.LogWarning("id不存在");
            return false;
        }

        if(item.capacity == 1)
        {
            Slot slot = FindEmptySlot();
            if(slot == null)
            {
                Debug.LogWarning("已满");
                return false;
            }
            else
            {
                slot.StoreItem(item);
            }
        }
        else
        {
            Slot slot = FindSameIdSlot(item);
            if(slot != null)
            {
                slot.StoreItem(item);
            }

            else
            {
                slot = FindEmptySlot();
                if(slot != null)
                {
                    slot.StoreItem(item);
                }
                else
                {
                    Debug.LogWarning("已满");
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// 找到空物品槽
    /// </summary>
    private Slot FindEmptySlot()
    {
        foreach(Slot slot in slotList)
        {
            if(slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return null;
    }

    private Slot FindSameIdSlot(Item item)
    {
        foreach(Slot slot in slotList)
        {
            if(slot.transform.childCount >= 1 && slot.GetItemId() == item.ID && !slot.IsFull())
            {
                return slot;
            }
        }

        return null;
    }

    public void Show()
    {
        canvasGroup.blocksRaycasts = true;
        targetalpha = 1;
    }

    public void Hide()
    {
        canvasGroup.blocksRaycasts = false;
        targetalpha = 0;
    }

    public void DisplaySwitch()
    {
        if(targetalpha == 0)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void SaveInventory()
    {
        StringBuilder s = new StringBuilder();
        foreach(Slot slot in slotList)
        {
            if(slot.transform.childCount > 0)
            {
                ItemUI itemUI = slot.transform.GetChild(0).GetComponent<ItemUI>();
                s.Append(itemUI.Item.ID + "," + itemUI.Amount + "-");
            }
            else
            {
                s.Append("0-");
            }
        }
        print("save : " + s);
        PlayerPrefs.SetString(this.gameObject.name, s.ToString());
    }

    public void LoadInventory()
    {
        if (PlayerPrefs.HasKey(this.gameObject.name) == false) return;
        string s = PlayerPrefs.GetString(this.gameObject.name);
        print("load " + this.gameObject.name + s);
        string[] itemArray = s.Split('-');
        for(int i = 0;i < itemArray.Length-1; i++)
        {
            string itemStr = itemArray[i];
            if(itemStr != "0")
            {
                Debug.Log(itemStr);
                string[] temp = itemStr.Split(',');
                int id = int.Parse(temp[0]);
                Item item = InventoryManager.Instance.GetItemById(id);
                int amount = int.Parse(temp[1]);
                while(amount > 0)
                {
                    slotList[i].StoreItem(item);
                    amount--;
                }
                
            }
        }
    }
}
