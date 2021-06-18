using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false; 
    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;

    void Start()
    {
        // Called on start so our games starts off in the "Resume" session
        ResumeButton();
    }

    // Update is called once per frame
    void Update()
    {
        //If we press the "Escape Key" then first check if we are in our ooptionUI, and if we are then just load our normal pauseUI.
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Checks if our option menu is active when we press escape, and if it is then just open the pause menu again rather than closing the entire menu.
            if(optionMenuUI.activeInHierarchy)
            { 
                optionMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
            }
            else if(isPaused) 
            {
                ResumeButton();
            }
            else
            {
                Pause();
            }
        }
    }

    //Turns off our Pause menu and resumes the game
    public void ResumeButton()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
        Score.timerRunning = true; // Our Score update method will continue to be called when the game resumes
        DestroyTarget.isRunning = true;
    }

    //Pause Menu Loads
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
        Score.timerRunning = false; // Stops calling our Score update method while our menu is paused
        DestroyTarget.isRunning = false;
    }

    //Loads our MainMenuScene on button press
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(2);
    }


}
