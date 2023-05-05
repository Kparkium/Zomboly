using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //Restart button
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    //Redirects to Main Menu Screen
    public void ExitButton()
    {
        SceneManager.LoadScene("Main");
    }
}
