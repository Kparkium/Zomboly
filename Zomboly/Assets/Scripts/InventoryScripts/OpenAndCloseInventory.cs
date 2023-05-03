using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenAndCloseInventory : MonoBehaviour
{
    public Canvas Inv;
    public Canvas Pause;

    private bool isActiveInv = false;
    private bool isActivePause = false;

    public Item Startinggun;
    void Start()
    {
        //adds testing items to inventory
        Inventory.add(Startinggun);
        Inventory.equip(0);
        Debug.Log("testing items added successfully");
        Cursor.lockState = CursorLockMode.Locked;
        resume();
        Cursor.lockState = CursorLockMode.Locked;
        Inv.gameObject.SetActive(false);
        isActiveInv = false;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isActiveInv)
            {
               
                Cursor.lockState = CursorLockMode.Locked;
                Inv.gameObject.SetActive(false);
                isActiveInv = false;
                Time.timeScale = 1;
            }
            else
            {
                Inv.GetComponent<InventoryUI>().UpdateUI();
                Cursor.lockState = CursorLockMode.Confined;
                Inv.gameObject.SetActive(true);
                isActiveInv = true;
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActivePause)
            {
                
               resume();
                
            }
            else
            {
                isActivePause = true;
                Pause.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0;
            }
        }
        
    }
    public void resume(){
        Cursor.lockState = CursorLockMode.Locked;
        Pause.gameObject.SetActive(false);
        isActivePause = false;
        Time.timeScale = 1;
    }
    public void quit(){
        Application.Quit();
    }
}
