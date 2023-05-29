using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to controll the inventory
public class Inventory : MonoBehaviour {

    //this inventory stored in list and the equiped and count
    public List<Item> inventoryList = new List<Item>();
    public Item equipped;
    public int count = 0;
    public int radioObjects = 0;
    public int radioObjectsMax = 3;
    public bool radioInInv = false;
    public bool repairedRadioTower = false;
    public Item completedRadio;

    //stores the starting gun
    public Item Startinggun;

    public void Start(){
        count = 0;
        radioObjects = 0;
        radioInInv = false;
        repairedRadioTower = false;
        Debug.Log("start");
        //adds starting gun to inventory
        if (count == 0)
        {
            add(Startinggun);
        }
        //equips the gun
        equip(0);
    }
    //function to add items to the inventory
    public void add(Item newitem)
    {
        //adds item
        inventoryList.Add(newitem);
        isRadio(newitem);
        //increments count
        count++;
    }

    //function to drop/remove items from inventory
    public Item dropItem(int i)
    {
        //gets the item
        Item itm = inventoryList[i];
        //removes the items from the inventory
        inventoryList.RemoveAt(i);
        //decreases count
        count--;
        //returns the removed item
        return itm;

    }

    //function to equip items
    public void equip(int i)
    {
        //sets the old item to not equiped
        if(equipped!= null)
        {
            equipped.equip = false;
        }
        
        //sets the equipped to the new equiped
        equipped = inventoryList[i];
        //sets equipped to true
        equipped.equip = true;
    }
    //return the equiped game object body
    public GameObject getEquipped(){
        return equipped.body;
    }
    public void isRadio(Item item){
        if(item.isRadioComponent){
            radioObjects++;
            CheckForCompleteRadio();
        }
    }

    public void CheckForCompleteRadio()
    {
        if (radioObjects == radioObjectsMax && !radioInInv)
        {
            List<Item> radioComponents = new List<Item>();

            // Find all radio components in the inventory
            for (int i = inventoryList.Count - 1; i >= 0; i--)
            {
                if (inventoryList[i].isRadioComponent)
                {
                    radioComponents.Add(inventoryList[i]);
                    inventoryList.RemoveAt(i);
                    count--;
                }
            }

            // Add the completed radio to the inventory
            add(completedRadio);
            radioInInv = true;
        }
    }



}
