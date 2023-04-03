using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public int index;
    public void dropItem()
    {
        Debug.Log("button is working");
        Inventory.dropItem(index);
        GameObject.Find("Canvas").GetComponent<InventoryUI>().UpdateUI(); 
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
