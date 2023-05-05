using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
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
