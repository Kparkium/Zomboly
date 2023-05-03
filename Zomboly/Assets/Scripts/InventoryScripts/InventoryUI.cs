using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform InventoryUIParent;

    InventorySlot[] slots;
    void Awake()
    {
        slots = InventoryUIParent.GetComponentsInChildren<InventorySlot>();
        
        Debug.Log("slots assigned");
    }
    
    public void UpdateUI()
    {
        
       // Debug.Log("items made visible");
        for (int i = 0; i < slots.Length; i++)
        {
            
            slots[i].Clear();
            

        }
        //Debug.Log("items made visible");
        for (int i = 0; i < Inventory.count; i++)
        {
            
            
            slots[i].Add(Inventory.inventoryList[i]);
        }
        Debug.Log("items made visible");
    }
}
