using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipdrop : MonoBehaviour
{
    public int index;
    public EquipManager manager;
    public void dropItem()
    {
        Debug.Log("button is working");
        
        Inventory.dropItem(index);
        GameObject.Find("Inventory").GetComponent<InventoryUI>().UpdateUI(); 
    }
    public void equipItem()
    {
        
        Debug.Log("equip is working");
        Inventory.equip(index);
        manager.EquipItem(Inventory.getEquipped());
        GameObject.Find("Inventory").GetComponent<InventoryUI>().UpdateUI();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
