using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;

    public Image image;
    public GameObject panel;
    public GameObject drop;

    public void Add(Item newItem)
    {
        this.gameObject.SetActive(true);
        item = newItem;
        image.sprite = newItem.image;
        image.enabled = true;
        Debug.Log("items added to slot");
        
        if(item.equip)
        {
            panel.GetComponent<Image>().color = Color.grey;
            drop.SetActive(false);
        }

    }
    public void Clear()
    {
        item = null;
        
        //image.sprite = null;
        image.enabled = false;
        Debug.Log("slots cleared");
        panel.GetComponent<Image>().color = Color.white;
        drop.SetActive(true);
        
        this.gameObject.SetActive(false);
    }
}
