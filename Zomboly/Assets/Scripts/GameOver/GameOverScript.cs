using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
        
=======
    public UnitHealth script;

    //Restart button
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    //Redirects to Main Menu Screen
    public void ExitButton()
    {
        SceneManager.LoadScene("Main");
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
