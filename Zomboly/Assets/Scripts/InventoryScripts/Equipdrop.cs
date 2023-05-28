using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is controlls what presing the drop and equip button does
public class Equipdrop : MonoBehaviour
{
    //lets the user set the index of the item box
    public int index;
    public EquipManager manager;
    

    public void Start()
    {
        manager = FindAnyObjectByType<EquipManager>();
    }

    //function for droping items when the drop button is clicked
    public void dropItem()
    {
        //removes item from inventory
        Inventory.dropItem(index);
        //updates the inventory UI
        GameObject.Find("Inventory").GetComponent<InventoryUI>().UpdateUI(); 
    }
    //function for equipping a item
    public void equipItem()
    {
        //equips item at selected index
        Inventory.equip(index);
        //adds the item to the hand
        Debug.Log(Inventory.getEquipped().name);
        manager.EquipItem(Inventory.getEquipped());
        //updates the inventory to have that item equiped
        GameObject.Find("Inventory").GetComponent<InventoryUI>().UpdateUI();
        
    }

}
