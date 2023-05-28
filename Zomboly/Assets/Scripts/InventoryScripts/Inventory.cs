
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to controll the inventory
public class Inventory
{
    //this inventory stored in list and the equiped and count
    public static List<Item> inventoryList = new List<Item>();
    public static Item equipped;
    public static int count = 0;
    public static int radioObjects = 0;
    public static int radioObjectsMax = 3;
    public static bool radioInInv = false;

    public void awake(){
        count = 0;
        radioObjects = 0;
        radioObjectsMax = 3;
        radioInInv = false;
    }
    //function to add items to the inventory
    public static void add(Item newitem)
    {
        
        //adds item
        inventoryList.Add(newitem);
        isRadio(newitem);
        //increments count
        count++;
    }

    //function to drop/remove items from inventory
    public static Item dropItem(int i)
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
    public static void equip(int i)
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
    public static GameObject getEquipped(){
        return equipped.body;
    }
    public static void isRadio(Item item){
        if(item.isRadio){
            radioObjects++;
            checkRadio();
            //calls a function that updates the menu or smth
            //update menu //menu.update(); 
        }
    }
    //checks if the user has all of the radio parts
    public static void checkRadio(){
        if (radioObjects >= radioObjectsMax){
            GameObject.Find("radio").GetComponent<Interactable>().Interacted();
            for(int i = 0; i < count; i++ ){
                if(inventoryList[i].isRadio){
                    Debug.Log("item droped");
                    dropItem(i);
                    i--;
                    
                }
            }
            
            radioInInv = true;
        }
        
    }
}
