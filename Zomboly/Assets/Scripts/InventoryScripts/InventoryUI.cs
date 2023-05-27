using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script controls the inventory ui and is responsible for updating it
public class InventoryUI : MonoBehaviour
{
    //refference to the panel containing all of the slots
    public Transform InventoryUIParent;
    //array containing inventory slots
    InventorySlot[] slots;
    private Inventory inventory;

    //when the object first awakes
    void Awake()
    {
        //sets the slots
        slots = InventoryUIParent.GetComponentsInChildren<InventorySlot>();
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
    }
    
    //updates the inventory UI
    public void UpdateUI()
    {
        //loops through the slots
        for (int i = 0; i < slots.Length; i++)
        {
            //clears each slot
            slots[i].Clear();
            
        }
        //loops through the inventory
        for (int i = 0; i < inventory.count; i++)
        {
            //adds all items in the inventory to their slots
            slots[i].Add(inventory.inventoryList[i]);
        }
       
    }
}
