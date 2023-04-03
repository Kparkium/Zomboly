using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenAndCloseInventory : MonoBehaviour
{
    public Canvas menu;

    private bool isActive = false;

    public Item Gun;
    public Item coin;
    public Item biggergun;
    void Start()
    {
        //adds testing items to inventory
        Inventory.add(Gun);
        Inventory.add(coin);
        Inventory.add(biggergun);
        Debug.Log("testing items added successfully");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActive)
            {
                menu.gameObject.SetActive(false);
                isActive = false;
                menu.GetComponent<InventoryUI>().UpdateUI(); ;

            }
            else
            {
                menu.gameObject.SetActive(true);
                isActive = true;
            }
        }
        
    }
}
