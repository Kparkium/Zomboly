using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        SettingsMenu.initSettings();
    }

    //Next scene once player clicks the Play button.
    public void Play()
    {
        SceneManager.LoadScene("Master");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void OpenHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }


    //Exit game once the player clicks the Quit button.
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has Quit the Game");
    }
}
