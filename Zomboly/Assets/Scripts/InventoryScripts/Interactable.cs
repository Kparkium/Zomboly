using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class is to make a game object be able be picked up by the player
public class Interactable : MonoBehaviour
{
    //Reference to the scriptable object Item this game object is representing
    public Item thisItem;
    private Inventory playerInventory;
  

    public void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    //when the object is interacted with
    public void InteractWithInteractable()
    {
        if (thisItem.itemName == "Lever"){
            if (playerInventory.radioInInv){
                SceneManager.LoadScene("GameComplete");
            }
        } else {
            //adds the items to the inventory 
            playerInventory.add(thisItem);
        //disables the game object
        this.gameObject.SetActive(false);
        }
        
        
    }

}
