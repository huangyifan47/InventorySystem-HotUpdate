using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : Slot
{
    public Equipment.EquipmentType equipType;
    public Weapon.WeqponType wpType;

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (InventoryManager.Instance.IsPickedItem == false && transform.childCount > 0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                Item temp = currentItemUI.Item;
                //脱掉装备放入背包
                DestroyImmediate(currentItemUI.gameObject);
                transform.parent.SendMessage("PutOff",temp);
            
                InventoryManager.Instance.HideToolTip();
            }
        }

        if (eventData.button != PointerEventData.InputButton.Left) return;

        //当前取得的物品
        ItemUI pickedItem = InventoryManager.Instance.PickedItem;
        //手上有东西
        bool isUpdateProperty = false;
        if(InventoryManager.Instance.IsPickedItem == true)
        {
            //物品槽中有东西
            if(transform.childCount > 0)
            {
                //物品槽中物品
                ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();

                if(JudgeItem(pickedItem.Item))
                {
                    InventoryManager.Instance.PickedItem.Exchange(currentItem);
                    isUpdateProperty = true;
                }
            }
            else
            {

                if(JudgeItem(pickedItem.Item))
                {
                    this.StoreItem(InventoryManager.Instance.PickedItem.Item);
                    InventoryManager.Instance.RemoveItem(1);
                    isUpdateProperty = true;
                }
            }
        }
        //手上没东西
        else
        {
            if(transform.childCount > 0)
            {
                ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();
                InventoryManager.Instance.PickupItem(currentItem.Item, currentItem.Amount);
                Destroy(currentItem.gameObject);
                isUpdateProperty = true;
            }
        }
        if(isUpdateProperty)
        {
            transform.parent.SendMessage("UpdatePropertyText");
        }
    }

    public bool JudgeItem(Item item)
    {
        if( (item is Equipment && ((Equipment)(item)).equipType == this.equipType) ||
            (item is Weapon && ((Weapon)(item)).wpType == this.wpType) )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
