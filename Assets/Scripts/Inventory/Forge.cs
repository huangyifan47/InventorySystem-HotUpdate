using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Forge : Inventory
{
    private List<Formula> formulaList;

    #region 单例模式
    private static Forge _instance;
    public static Forge Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("ForgePanel").GetComponent<Forge>();
            }

            return _instance;
        }
    }
    #endregion

    public override void Start()
    {
        base.Start();
        ParseFormulaJson();
    }


    void ParseFormulaJson()
    {
        formulaList = new List<Formula>();

        TextAsset itemText = Resources.Load<TextAsset>("Formulas");
        string itemJson = itemText.text;

        JsonData itemData = JsonMapper.ToObject(itemJson);

        foreach(JsonData temp in itemData)
        {
            int item1ID = (int)temp["item1ID"];
            int item1Amount = (int)temp["item1Amount"];
            int item2ID = (int)temp["item2ID"];
            int item2Amount = (int)temp["item2Amount"];
            int resID = (int)temp["resID"];

            Formula formula = new Formula(item1ID, item1Amount, item2ID, item2Amount, resID);
            formulaList.Add(formula);
            Debug.Log(formula.ResID);
        }
    }
        
    public void ForgeItem()
    {
        List<int> materialIDList = new List<int>();
        foreach(Slot slot in slotList)
        {
            if(slot.transform.childCount > 0)
            {
                ItemUI currentItemUI = slot.transform.GetComponentInChildren<ItemUI>();
                for(int i = 0;i < currentItemUI.Amount;i++)
                {
                    materialIDList.Add(currentItemUI.Item.ID);
                }
            }
        }

        Formula matchedFormula = null;
        foreach(Formula formula in formulaList)
        {
            bool isMatch = formula.Match(materialIDList);
            if(isMatch)
            {
                matchedFormula = formula;
                break;
            }
        }
        if(matchedFormula != null)
        {
            Knapsack.Instance.SaveItem(matchedFormula.ResID);

            foreach(int id in matchedFormula.NeedLsit)
                foreach(Slot slot in slotList)
                {
                    if(slot.transform.childCount > 0)
                    {
                        ItemUI itemUI = slot.transform.GetChild(0).GetComponent<ItemUI>();
                        if(itemUI.Item.ID == id)
                        {
                            itemUI.ReduceAmount();
                            if(itemUI.Amount <= 0)
                            {
                                Destroy(itemUI.gameObject);
                            }
                            break;
                        }
                    }
                }
        }
            
    }
}
