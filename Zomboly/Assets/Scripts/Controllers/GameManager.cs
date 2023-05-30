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
    public GameObject[] components;
    public Vector3[] randomComponentLocations;
    public Vector3[] setComponentLocations;

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

        SpawnComponents();
    }

    //Once health reaches 0, load gameover scene
    private void Update()
    {
        UpdateGUI();
        if (player == null || player.GetComponent<UnitHealth>()._currentHealth <= 0)
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
            else if(!playerInventory.repairedRadioTower && playerInventory.radioInInv)
            {
                taskText.text = "Locate the radio antenna to repair it";
            }
            else if(playerInventory.repairedRadioTower)
            {
                taskText.text = "Locate the radio tower & call for help";
            }
        }
    }

    public void SpawnComponents()
    {
        Vector3[] selectedPositions = new Vector3[components.Length];
        int[] randomSelections = new int[components.Length];
        List<int> currentSelections = new List<int>();
        if(SettingsMenu.randomComponentPos) // Player wants random positons
        {
            // Set selectedPositions to randomComponentLocations
            for(int i = 0; i < components.Length; i++)
            {
                int newPos = -1;
                while (!currentSelections.Contains(newPos) || newPos == -1)
                {
                    newPos = Random.Range(0, randomComponentLocations.Length); // Keep selecting until a non selected location is found
                    if (!currentSelections.Contains(newPos))
                    {
                        currentSelections.Add(newPos);
                    }
                }
                randomSelections[i] = newPos;
            }
        }
        else // Player wants set positions
        {
            selectedPositions = setComponentLocations;
        }
        // Select 3 positions out of the componentLocations

        int currentPosition = 0;
        foreach (GameObject component in components)
        {
            // Instantiate component at a selectedPositions position 
            Instantiate(component, selectedPositions[currentPosition], Quaternion.identity);
            currentPosition++;
        }
    }

}
