using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//this script controlls the opening and closing of the inventory and pause menu
public class OpenAndCloseInventory : MonoBehaviour
{
    //references to the inventory and pause menu
    public Canvas Inv;
    public Canvas Pause;

    //stores whether the inventory and pause menu are open
    private bool isActiveInv = false;
    private bool isActivePause = false;

    //stores the starting gun
    public Item Startinggun;

    private Inventory playerInventory;


    //starts when the code starts 
    void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Debug.Log("start");
        //adds starting gun to inventory
        if (playerInventory.count == 0)
        {
            playerInventory.add(Startinggun);
        }
        //equips the gun
        playerInventory.equip(0);
        //locks the cursor
        Cursor.lockState = CursorLockMode.Locked;
        //closes the resume menu
        resume();
        Cursor.lockState = CursorLockMode.Locked;
        //closes the inventory
        Inv.gameObject.SetActive(false);
        //sets the inventory is open variable to false
        isActiveInv = false;
        
    }

    // Update is called once per frame
    void Update()
    {
         
        //if the user clicks tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //if the inventory is open
            if (isActiveInv)
            {
                //closes the inventory and unpauses the game
                Cursor.lockState = CursorLockMode.Locked;
                Inv.gameObject.SetActive(false);
                isActiveInv = false;
                Time.timeScale = 1;
                Debug.Log("updates1");
            }
            else
            {
                //opens the inventory updates it and then pauses the game
                Inv.GetComponent<InventoryUI>().UpdateUI();
                Cursor.lockState = CursorLockMode.Confined;
                Inv.gameObject.SetActive(true);
                isActiveInv = true;
                Time.timeScale = 0;
                Debug.Log("updates2");
            }
        }
        //if escape is clicked 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if pause menu is open resumes the game
            if (isActivePause)
            { 
               resume();   
               Debug.Log("updates3");
            }
            else
            {
                //pauses the game
                isActivePause = true;
                Pause.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0;
                Debug.Log("updates4");
            }
        }
        
    }
    //this function resumes the game if the resume button is clicked or if called
    public void resume(){
        Cursor.lockState = CursorLockMode.Locked;
        Pause.gameObject.SetActive(false);
        isActivePause = false;
        Time.timeScale = 1;
    }
    //this function quits the game if the quit button is pressed will not work inside editor
    public void quit(){
        Application.Quit();
    }
}
