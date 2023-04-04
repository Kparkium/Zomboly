
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public static List<Item> inventoryList = new List<Item>();
    public static Item equipped;

    public static void add(Item newitem)
    {
        inventoryList.Add(newitem);
        //Debug.Log("items addded to array");
    }
    public static Item dropItem(int i)
    {
        Item itm = inventoryList[i];
        inventoryList.RemoveAt(i);
        return itm;

    }
    public static void equip(int i)
    {
        equipped = inventoryList[i];
        Debug.Log("done success");
        Debug.Log(inventoryList[i]);
    }
}