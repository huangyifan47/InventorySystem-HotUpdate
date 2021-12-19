using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : Item
{
    public Material(int id, string name, ItemType type, ItemQuality quality, string des,
        int capacity, int buy, int sell,string sprite)
        : base(id, name, type, quality, des, capacity, buy, sell, sprite)
    {

    }
}
