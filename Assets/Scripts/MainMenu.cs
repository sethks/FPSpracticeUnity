using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Increases our scene index by one to our game start scene index (This is for the Play Button)
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quits the game if the quit button is pressed
    public void quitGame()
    {
        Application.Quit();
    }
}
