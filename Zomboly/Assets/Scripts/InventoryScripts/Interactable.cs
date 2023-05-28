using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is to make a game object be able be picked up by the player
public class Interactable : MonoBehaviour
{
    //Reference to the scriptable object Item this game object is representing
    public Item thisItem;
  

    public void Start()
    {

    }

    //when the object is interacted with
    public void Interacted()
    {
        if (thisItem.name == "GameWin"){
            if (Inventory.radioInInv){
                    Application.LoadLevel("GameComplete");
            }
        } else {
//adds the items to the inventory 
        Inventory.add(thisItem);
        //disables the game object
        this.gameObject.SetActive(false);
        }
        
        
    }

}
