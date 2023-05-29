using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class is to make a game object be able be picked up by the player
public class Interactable : MonoBehaviour
{
    //Reference to the scriptable object Item this game object is representing
    public Item thisItem;
    public bool hasParticles;
    public ParticleSystem particles;
    private Inventory playerInventory;
    private ParticleSystem currentParticles;

  

    public void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        if(hasParticles)
        {
            PlayParticles();
        }
    }

    //when the object is interacted with
    public void InteractWithInteractable()
    {
        if (thisItem.itemName == "Lever"){
            if (playerInventory.repairedRadioTower)
            {
                SceneManager.LoadScene("GameComplete");
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        else if(thisItem.itemName == "Repair" )
        {
            if (!playerInventory.repairedRadioTower && playerInventory.radioInInv)
            {
                playerInventory.repairedRadioTower = true;
                StopParticles();
            }
        }
        else {
            //adds the items to the inventory 
            playerInventory.add(thisItem);
        //disables the game object
        this.gameObject.SetActive(false);
        }
        
        
    }

    public void PlayParticles()
    {
        currentParticles = Instantiate(particles, this.transform.position, Quaternion.identity, this.transform);
    }

    public void StopParticles()
    {
        if(currentParticles!=null)
        {
            Destroy(currentParticles);
        }
    }

}
