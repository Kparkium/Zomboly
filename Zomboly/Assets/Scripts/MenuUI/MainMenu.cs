using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Next scene once player clicks the Play button.
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    //Exit game once the player clicks the Quit button.
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has Quit the Game");
    }

}
