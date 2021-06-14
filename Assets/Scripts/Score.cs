using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; // Creates our score text object
    public Text accuracyText; // Creates our accuracy text object
    public Text timeText; // Creates our time text object
    public float timeRemaining; // Time remaining until game is over (Refers to out timeText)
    public float currentAccuracy; // Calculated by mouse clicks and current score (Refers to accuracyText)
    public float currentScore; // If destroy object was called then we gain n amount of points (Refers to scoreText)
    public float mouseClicks; // Updates everytime we click
    private bool timerRunning = false; // Same as game over

    
    void Start()
    {
        timerRunning = true; // Game Start
        scoreText.text = "Score: " + currentScore; // Init score UI
        accuracyText.text = "Accuracy: "; // Init accuracy UI
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
                if(mouseClicks == currentScore) currentAccuracy = 100.0f; //If the number of clicks were equal to the score then the player had perfect accuracy
                //UnityEditor.EditorApplication.isPlaying = false; FOR TESTING
            }
        }
        // Call our updateAccuracy method everytime we click 
        if(Input.GetMouseButtonDown(0)) updateAccuracy();
    }

    //Method that just increases our score in the UI
    public void updateScore()
    {
        currentScore += 1;
        scoreText.text = "Score: " + currentScore;
    }

    //Method that calculates our Accuracy and updates the UI
    public void updateAccuracy()
    {
        mouseClicks += 1.0f;
        currentAccuracy = (currentScore / mouseClicks) * 100.0f;
        accuracyText.text = "Accuracy: " + currentAccuracy.ToString("00");
    }

    //Method that displays our time and formats it
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
