using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 A class that manages everything ESSENTIAL THAT CONTROLS THE FLOW OF THE GAME (HP of a mob is not essential for example).
 There can only be one instance of it in the entire game.
     */

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    private GameObject player;
    private HealthBar healthBar;

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
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //Once health reaches 0, load gameover scene
    private void Update()
    {
        UpdateHealthBar();
        if (player.GetComponent<UnitHealth>()._currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.SetHealth(player.GetComponent<UnitHealth>()._currentHealth);
    }
}
