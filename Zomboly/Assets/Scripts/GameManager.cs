using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/* 
 A class that manages everything ESSENTIAL THAT CONTROLS THE FLOW OF THE GAME (HP of a mob is not essential for example).
 There can only be one instance of it in the entire game.
     */

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    private GameObject player;
    private Inventory playerInventory;
    private HealthBar healthBar;
    private StaminaBar staminaBar;
    public TextMeshProUGUI taskText;

    //Makes sure that there is only one GameManager in the game.
    void Awake()
    {
        if(gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    private void Start()
    {
        GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        healthBar = healthBarObject.GetComponent<HealthBar>();
        GameObject staminaBarObject = GameObject.FindGameObjectWithTag("StaminaBar");
        staminaBar = staminaBarObject.GetComponent<StaminaBar>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<Inventory>();
    }

    //Once health reaches 0, load gameover scene
    private void Update()
    {
        UpdateGUI();
        if (player.GetComponent<UnitHealth>()._currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void UpdateGUI()
    {
        if(player != null)
        {
            healthBar.SetHealth(player.GetComponent<UnitHealth>()._currentHealth);
            staminaBar.SetStamina(player.GetComponent<PlayerControls>().stamina);
            if(!playerInventory.radioInInv) // If player hasnt collected all items
            {
                taskText.text = "Find radio components: " + playerInventory.radioObjects + "/" + playerInventory.radioObjectsMax;
            }
            else
            {
                taskText.text = "Locate the radio tower & call for help";
            }
        }
    }

}
