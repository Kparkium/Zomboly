using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class controls the inventory slots
public class InventorySlot : MonoBehaviour
{
    //stores the item
    public Item item;

    //references to the different parts of the slot
    public Image image;
    public GameObject panel;
    public GameObject drop;

    //adds item to the slot
    public void Add(Item newItem)
    {
        //sets the slot as visible
        this.gameObject.SetActive(true);
        //swaps the item over
        item = newItem;
        //sets the image as the new image
        image.sprite = newItem.image;
        //sets the image as visible
        image.enabled = true;
        //checks if the item is equipped 
        if(item.equip)
        {
            //sets the color to indicate the item is equipped and disables the drop button
            panel.GetComponent<Image>().color = Color.grey;
            drop.SetActive(false);
        }

    }
    //function to clear a slot
    public void Clear()
    {
        //sets the item to null
        item = null;
        //disables the image
        image.enabled = false;
        //sets the panel to not equipped state
        panel.GetComponent<Image>().color = Color.white;
        //turns on the drop button
        drop.SetActive(true);
        //sets the game object as not active
        this.gameObject.SetActive(false);
    }
}
