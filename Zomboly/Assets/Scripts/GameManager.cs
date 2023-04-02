using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 A class that manages everything ESSENTIAL THAT CONTROLS THE FLOW OF THE GAME (HP of a mob is not essential for example).
 There can only be one instance of it in the entire game.
     */

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public UnitHealth _playerHealth = new UnitHealth(100, 100);

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
}
