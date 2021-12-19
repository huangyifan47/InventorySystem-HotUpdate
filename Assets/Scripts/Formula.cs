using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Formula 
{
    public int Item1ID { get; set; }
    public int Item1Amount { get; set; }
    public int Item2ID { get; set; }
    public int Item2Amount { get; set; }

    public int ResID { get; set; }//锻造结果

    private List<int> needList = new List<int>();
    public List<int> NeedLsit
    {
        get
        {
            return needList;
        }
    }

    public Formula(int id1,int amount1,int id2,int amount2,int resId)
    {
        Item1ID = id1;
        Item2ID = id2;
        Item1Amount = amount1;
        Item2Amount = amount2;
        ResID = resId;

        for (int i = 0; i < Item1Amount; i++)
        {
            needList.Add(Item1ID);
        }
        for (int i = 0; i < Item2Amount; i++)
        {
            needList.Add(Item2ID);
        }
    }
    
    public bool Match(List<int> idList)
    {
        
        List<int> tempIDList = new List<int>(idList);

        foreach(int id in needList)
        {
            bool success = tempIDList.Remove(id);
            if(!success)
            {
                return false;
            }
        }
        return true;
    }
}
