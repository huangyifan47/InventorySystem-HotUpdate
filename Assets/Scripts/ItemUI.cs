using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//负责物品槽内物品的显示
public class ItemUI : MonoBehaviour
{
    public Item Item { get;private set; }
    public int Amount { get;private set; }

    #region UI Component
    private Image itemImage;
    private Text amountText;

    private Image ItemImage
    {
        get
        {
            if(itemImage == null)
            {
                itemImage = GetComponent<Image>();
            }
            return itemImage;
        }
    }

    private Text AmountText
    {
        get
        {
            if(amountText == null)
            {
                amountText = GetComponentInChildren<Text>();
            }
            return amountText;
        }
    }
    #endregion

    private float targetScale = 1f;

    private Vector3 maxScale = new Vector3(1.2f, 1.2f, 1.2f);

    private float smoothing = 2f;

    private void Update()
    {
        if(transform.localScale.x != targetScale)
        {
            float scale = Mathf.Lerp(transform.localScale.x, targetScale, smoothing * Time.deltaTime);
            transform.localScale = new Vector3(scale, scale, scale);
            if(Mathf.Abs(transform.localScale.x - targetScale) < 0.1f)
            {
                transform.localScale = new Vector3(targetScale, targetScale, targetScale);
            }
        }
    }


    public void SetItem(Item item,int amount = 1)
    {
        transform.localScale = maxScale;
        this.Item = item;
        this.Amount = amount;

        //update UI
        ItemImage.sprite = Resources.Load<Sprite>(item.sprite);
        if (Item.capacity > 1)
            AmountText.text = Amount.ToString();
        else
            AmountText.text = "";
    }

    public void SetItemUI(ItemUI itemUI)
    {
        SetItem(itemUI.Item, itemUI.Amount);
    }


    public void AddAmount(int amount = 1)
    {
        transform.localScale = maxScale;

        this.Amount += amount;

        //update UI
        if (Item.capacity > 1)
            AmountText.text = Amount.ToString();
        else
            AmountText.text = "";
    }

    public void SetAmount(int amount)
    {
        transform.localScale = maxScale;

        this.Amount = amount;
        //update UI
        if (Item.capacity > 1)
            AmountText.text = Amount.ToString();
        else
            AmountText.text = "";
    }

    public void ReduceAmount(int amount = 1)
    {
        transform.localScale = maxScale;

        this.Amount -= amount;
        //update UI
        if (Item.capacity > 1)
            AmountText.text = Amount.ToString();
        else
            AmountText.text = "";
    }

    public void Exchange(ItemUI itemUI)
    {
        Item item = itemUI.Item;
        int amount = itemUI.Amount;
        itemUI.SetItem(this.Item, this.Amount);
        this.SetItem(item, amount);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetLocalPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }
}
