using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; // Creates our score text object
    public Text accuracyText; // Creates our accuracy text object
    public Text timeText; // Creates our time text object
    public float timeRemaining; 
    public float currentAccuracy; // Calculated by mouse clicks and current score
    public float mouseClicks; // Updates everytime we click
    public float currentScore; // If destroy object was called then we gain n amount of points
    private bool timerRunning = false; 
    
    void Start()
    {
        timerRunning = true;
        scoreText.text = "Score: " + currentScore;
        accuracyText.text = "Accuracy: ";
    }

    void Update()
    {
        if(timerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                print("GAME WOULD END HERE");
                //UnityEditor.EditorApplication.isPlaying = false;
            }
        }
        // Call our updateAccuracty method everytime we click our mouse no matter if we missed or not
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

    //Metjpd that displays our time and formats it
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
