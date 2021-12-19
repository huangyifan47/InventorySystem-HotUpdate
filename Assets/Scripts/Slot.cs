using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    public GameObject itemPrefab;
    /// <summary>
    /// item放入
    /// 1.实例化item
    /// 2.amount++
    /// </summary>
    /// <param name="item"></param>
    public void StoreItem(Item item)
    {
        if(transform.childCount == 0)
        {
            GameObject itemGameObject = Instantiate(itemPrefab) as GameObject;
            itemGameObject.transform.SetParent(this.transform);
            itemGameObject.transform.localScale = Vector3.one;
            itemGameObject.transform.localPosition = Vector3.zero;
            itemGameObject.GetComponent<ItemUI>().SetItem(item);

        }
        else
        {
            transform.GetChild(0).GetComponent<ItemUI>().AddAmount();
        }
    }

    /// <summary>
    /// 获取当前slot下存储的物品类型
    /// </summary>
    /// <returns></returns>
    public Item.ItemType GetItemType()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.itemType;
    }

    public int GetItemId()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.ID;
    }

    public bool IsFull()
    {
        ItemUI t = transform.GetChild(0).GetComponent<ItemUI>();
        return t.Amount >= t.Item.capacity;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(transform.childCount > 0)
        {
            string toolTipText = transform.GetChild(0).GetComponent<ItemUI>().Item.GetToolTipText();

            InventoryManager.Instance.ShowToolTip(toolTipText);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.HideToolTip();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(InventoryManager.Instance.IsPickedItem == false && transform.childCount > 0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                if(currentItemUI.Item is Equipment || currentItemUI.Item is Weapon)
                {
                    Item currentItem = currentItemUI.Item;
                    currentItemUI.ReduceAmount(1);
                    if(currentItemUI.Amount <= 0)
                    {
                        DestroyImmediate(currentItemUI.gameObject);
                        InventoryManager.Instance.HideToolTip();
                    }
                    CharacterPanel.Instance.PutOn(currentItem);
                }
            }
        }

        if (eventData.button != PointerEventData.InputButton.Left) return;

        //自身不空
        if(transform.childCount > 0)
        {
            Debug.Log("点击");
            //当前slot中的物品
            ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();

            //当前鼠标未取得物品
            if(InventoryManager.Instance.IsPickedItem == false)
            {
                if(Input.GetKey(KeyCode.LeftControl))
                {
                    int amountPicked = (currentItem.Amount + 1) / 2;
                    InventoryManager.Instance.PickupItem(currentItem.Item, amountPicked);
                    int amountRemained = currentItem.Amount - amountPicked;
                    if(amountRemained <= 0)
                    {
                        Destroy(currentItem.gameObject);
                    }
                    else
                    {
                        currentItem.SetAmount(amountRemained);
                    }
                }
                else
                {
                    //鼠标取得当前物品槽中物品
                    InventoryManager.Instance.PickupItem(currentItem.Item,currentItem.Amount);
                    Destroy(currentItem.gameObject);
                }
            }
            else
            {
                Debug.Log("当前鼠标已取得物品");
                //当前鼠标已取得物品
                
                if(currentItem.Item.ID == InventoryManager.Instance.PickedItem.Item.ID)
                {
                    //按下ctrl放下一部分
                    if(Input.GetKey(KeyCode.LeftControl))
                    {
                        //当前物品槽还有容量
                        if(currentItem.Item.capacity > currentItem.Amount)
                        {
                            currentItem.AddAmount();
                            InventoryManager.Instance.RemoveItem();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if(currentItem.Item.capacity > currentItem.Amount)
                        {
                            int amountRemain = currentItem.Item.capacity - currentItem.Amount;
                            if(amountRemain >= InventoryManager.Instance.PickedItem.Amount)
                            {
                                currentItem.SetAmount(currentItem.Amount + InventoryManager.Instance.PickedItem.Amount);
                                InventoryManager.Instance.RemoveItem(InventoryManager.Instance.PickedItem.Amount);
                            }
                            else
                            {
                                currentItem.SetAmount(currentItem.Amount + amountRemain);
                                InventoryManager.Instance.RemoveItem(amountRemain);
                            }

                        }
                        else
                        {
                            return;
                        }
                    }
                }
                //自身id != pickeditem.id    交换物品
                else
                {
                    Item item = currentItem.Item;
                    int amount = currentItem.Amount;
                    currentItem.SetItem(InventoryManager.Instance.PickedItem.Item, InventoryManager.Instance.PickedItem.Amount);
                    InventoryManager.Instance.PickedItem.SetItem(item, amount);
                }
            }
        }
        //自身空
        else
        {
            if(InventoryManager.Instance.IsPickedItem == true)
            {
                //按下Ctrl放置一个
                if(Input.GetKey(KeyCode.LeftControl))
                {
                    this.StoreItem(InventoryManager.Instance.PickedItem.Item);
                    InventoryManager.Instance.RemoveItem();
                }
                else
                {
                    for(int i = 0;i < InventoryManager.Instance.PickedItem.Amount;i++)
                    {
                        this.StoreItem(InventoryManager.Instance.PickedItem.Item);
                    }
                    InventoryManager.Instance.RemoveItem(InventoryManager.Instance.PickedItem.Amount);
                }
            }
            else
            {

            }
        }
    }
}
