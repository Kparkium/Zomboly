using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public UnitHealth unitHealth;

    //Once health reaches 0, load gameover scene
    private void Update()
    {
        if (unitHealth._currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //Restart the game
    public void RestartButton()
    {
        SceneManager.LoadScene("Master");
    }

    //Redirects to Main Menu Screen
    public void ExitButton()
    {
        SceneManager.LoadScene("MenuUI");
    }
}
