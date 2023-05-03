
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public static List<Item> inventoryList = new List<Item>();
    public static Item equipped;
    public static int count = 0;

    public static void add(Item newitem)
    {
        inventoryList.Add(newitem);
        count++;
        Debug.Log("items addded to array");
    }
    public static Item dropItem(int i)
    {
        Item itm = inventoryList[i];
        inventoryList.RemoveAt(i);
        count--;
        return itm;

    }
    public static void equip(int i)
    {
        if(equipped!= null)
        {
            equipped.equip = false;
        }
        
        equipped = inventoryList[i];
        equipped.equip = true;
        Debug.Log("done success");
        Debug.Log(inventoryList[i]);
    }
    public static GameObject getEquipped(){
        return equipped.body;
    }
}
