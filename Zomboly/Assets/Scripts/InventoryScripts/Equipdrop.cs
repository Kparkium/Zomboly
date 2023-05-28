using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is controlls what presing the drop and equip button does
public class Equipdrop : MonoBehaviour
{
    //lets the user set the index of the item box
    public int index;
    public EquipManager manager;
    private Inventory playerInventory;
    

    public void Start()
    {
        manager = FindAnyObjectByType<EquipManager>();
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    //function for droping items when the drop button is clicked
    public void dropItem()
    {
        //removes item from inventory
        playerInventory.dropItem(index);
        //updates the inventory UI
        GameObject.Find("Inventory").GetComponent<InventoryUI>().UpdateUI(); 
    }
    //function for equipping a item
    public void equipItem()
    {
        //equips item at selected index
        playerInventory.equip(index);
        //adds the item to the hand
        Debug.Log(playerInventory.getEquipped().name);
        manager.EquipItem(playerInventory.getEquipped());
        //updates the inventory to have that item equiped
        GameObject.Find("Inventory").GetComponent<InventoryUI>().UpdateUI();
        
    }

}
