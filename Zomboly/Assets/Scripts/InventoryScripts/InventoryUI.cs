using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script controls the inventory ui and is responsible for updating it
public class InventoryUI : MonoBehaviour
{
    //refference to the panel containing all of the slots
    public GameObject InventoryUIParent;
    //array containing inventory slots
    private Inventory playerInventory;
    public InventorySlot[] slots;

    //when the object first awakes
    public void Awake()
    {
        //sets the slots
        slots = InventoryUIParent.GetComponentsInChildren<InventorySlot>();
    }
    
    //updates the inventory UI
    public void UpdateUI()
    {
        if(playerInventory == null)
        {
            playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }
        //loops through the slots
        for (int i = 0; i < slots.Length; i++)
        {
            //clears each slot
            slots[i].Clear();
            
        }
        //loops through the inventory
        for (int i = 0; i < playerInventory.count; i++)
        {
            //adds all items in the inventory to their slots
            slots[i].Add(playerInventory.inventoryList[i]);
        }
       
    }
}
