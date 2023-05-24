using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class escapedScript : MonoBehaviour
{
    public Text escapeText;

    // Stops game with game completed screen once player reaches the box.
    private void onTriggerEscapeIsland(Collider2D collision)
    {
        if (collision.tag == "Win")
        {
            escapeText.gameObject.SetActive(true);

            // Makes the game stop once the player reaches the escape portal.
            Time.timeScale = 0;
        }
    }

    // Redirected to the Menu UI
    public void MenuButton()
    {
        SceneManager.LoadScene("MenuUI");
    }

    // Restarts the game
    public void PlayAgain()
    {
        SceneManager.LoadScene("Master");
    }


}

