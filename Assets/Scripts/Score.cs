using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; // Creates our score text object
    public Text accuracyText; // Creates our accuracy text object
    public Text timeText; // Creates our time text object
    public Text finalScore; // Creates our final score text object
    public Text finalAccuracy; // Creates our final accuracy text object
    public Text finalReactionTime; // Creates our final reaction time text object
    public float timeRemaining; // Time remaining until game is over (Refers to out timeText)
    public float currentAccuracy; // Calculated by mouse clicks and current score (Refers to accuracyText)
    public float currentScore; // If destroy object was called then we gain n amount of points (Refers to scoreText)
    public static float targetHit;
    public float mouseClicks; // Updates everytime we click
    public static bool timerRunning; // If our timer is false then our game is over
    public static bool isgameOverCalled; // Checks if our GameOver function is called;
    public GameObject gameOverUI; // Creates our game over UI object

    void Start()
    {
        timerRunning = true; // Game Start
        isgameOverCalled = false; // Sets gameover to false on start 
        enabled = true; // Keeps our updated method true

        //Init all values to their starting values so that they are reset to default if the player restarts the game or goes to the main menu.
        timeRemaining = 30.0f;
        currentAccuracy = 100.0f;
        currentScore = 0f;
        targetHit = 0;
        mouseClicks = 0f;

        scoreText.text = "Score: " + currentScore; // Init score UI
        accuracyText.text = "Accuracy: " + currentAccuracy + '%'; // Init accuracy UI
    }

    void Update()
    {
        // as long as timer is running, our game will continue to run and display the time
        if(timerRunning)
        {
            // subtracts time from the UI as long as the time is over 0
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            //if our timeRemaining variable is less than 0 then our game has ended
            else
            {
                timeRemaining = 0;
                timerRunning = false;

                //If the number of clicks are equal to the score then the player had perfect accuracy
                if(mouseClicks == currentScore) 
                {
                    currentAccuracy = 100.0f;
                } 

                //Call our game over UI once the timer hits 0 
                GameOverScreen();
            }
            // Call our updateAccuracy method everytime we click 
            if(Input.GetMouseButtonDown(0)) 
            {
                updateAccuracy();
            }
        }
    }

    //Method that just increases our score in the UI
    public void updateScore()
    {
        targetHit += 1;
        currentScore += 100.0f;
        scoreText.text = "Score: " + currentScore;
    }

    //Method that calculates our Accuracy and updates the UI
    public void updateAccuracy()
    {
        mouseClicks += 1.0f;
        currentAccuracy = (targetHit / mouseClicks) * 100.0f;
        accuracyText.text = "Accuracy: " + currentAccuracy.ToString("00") + '%';
    }

    //Method that displays our time and formats it
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Calls our game over screen UI and displays all of the players final information of that play
    public void GameOverScreen()
    {
        gameOverUI.SetActive(true);
        FindObjectOfType<DestroyTarget>().calculateAvgShotTime(); // Call our calculation from the DestroyTarget class so we can display it to the user in the Game Over UI
        finalScore.text = "Final Score: " + currentScore + '!';
        finalAccuracy.text = "Final Accuracy: " + currentAccuracy.ToString("00") + '%';
        finalReactionTime.text = "Average Reaction Time: " + DestroyTarget.averageShotTime.ToString("00") + "ms!";
        Time.timeScale = 0f;
        isgameOverCalled = true;
        enabled = false;
    }
}
