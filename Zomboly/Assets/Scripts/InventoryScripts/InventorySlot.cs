using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;

    public Image image;
    

    public void Add(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        image.enabled = true;
        Debug.Log("items added to slot");

    }
    public void Clear()
    {
        item = null;

        //image.sprite = null;
        image.enabled = false;
        Debug.Log("slots cleared");
    }
}
