using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is to make a game object be able be picked up by the player
public class Interactable : MonoBehaviour
{
    //Reference to the scriptable object Item this game object is representing
    public Item thisItem;
    public Inventory inventory;

    public void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }

    //when the object is interacted with
    public void Interacted()
    {
        //adds the items to the inventory 
        inventory.add(thisItem);
        //disables the game object
        this.gameObject.SetActive(false);
    }

}
