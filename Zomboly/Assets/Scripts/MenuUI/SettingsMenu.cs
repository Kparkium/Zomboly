using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public static bool randomComponentPos;
    public static bool hardMode;
    public static bool settingsLoaded;
    public bool togglesLoaded;
    public Toggle randomCompToggle;
    public Toggle hardModeToggle;

    public static void initSettings()
    {
        if(!settingsLoaded)
        {
            LoadOptions();
        }
    }

    public void Start()
    {
        togglesLoaded = false;
        LoadOptions();
        InitToggles();
    }

    public void ToggleRandomPos()
    {
        if (togglesLoaded)
        {
            Debug.Log("Toggle random pos Pressed");
            if (Getint("RandomPos") == 1)
            {
                randomComponentPos = false;
                Debug.Log("Components will spawn at set location");
                SetInt("RandomPos", 0);
            }
            else
            {
                randomComponentPos = true;
                Debug.Log("Components will spawn at random location");
                SetInt("RandomPos", 1);
            }
        }
    }

    public void ToggleHardMode()
    {
        if(togglesLoaded)
        {
            Debug.Log("Toggle hardmode Pressed");
            if (Getint("HardMode") == 1)
            {
                hardMode = false;
                Debug.Log("Hardmode Disabled");
                SetInt("HardMode", 0);
            }
            else
            {
                hardMode = true;
                Debug.Log("Hardmode Enabled");
                SetInt("HardMode", 1);
            }
        }

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuUI");
    }

    private void InitToggles()
    {

        if(Getint("HardMode") == 1)
        {
            hardModeToggle.isOn = true;
        }
        else
        {
            hardModeToggle.isOn = false;
        }
        if (Getint("RandomPos") == 1)
        {
            randomCompToggle.isOn = true;
        }
        else
        {
            randomCompToggle.isOn = false;
        }
        togglesLoaded = true;
    }

    public static void LoadOptions()
    {
        settingsLoaded = false;
        Debug.Log("Loading Settings...");

        if (Getint("HardMode") == 0)
        {
            hardMode = false;
            Debug.Log("HardMode Disabled");
            SetInt("HardMode", 0);
        }
        else
        {
            hardMode = true;
            Debug.Log("HardMode Enabled");
            SetInt("HardMode", 1);
        }
        if (Getint("RandomPos") == 0)
        {
            randomComponentPos = false;
            Debug.Log("Random Component Position Disabled");
            SetInt("RandomPos", 0);
        }
        else
        {
            randomComponentPos = true;
            Debug.Log("Random Component Position Enabled");
            SetInt("RandomPos", 1);
        }
        Debug.Log("Load Complete");
        settingsLoaded = true;

    }

    public static void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
        Debug.Log("Set " + KeyName + " as " + Value);
    }

    public static int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName, 0);
    }
}
