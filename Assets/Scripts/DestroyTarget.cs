using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    public float timeSpawned; // Keeps track of the time the target is spawned for (for future score calculations)
    public float totalShotTime; // Adds up the total time it took the player to shoot each target
    public static float averageShotTime; // Averages the time the player took to destroy each target
    private bool isCalled = false; // Resets our timeSpawned variable to zero only if a object was hit
    public static bool isRunning = false;

    void Start()
    {
        enabled = true;
        isRunning = true;
    }

    void Update()
    {
        // if this current class is running
        if(isRunning)
        {
            //if our gameOver boolean is true then calculate our average shot time, and disable the update method so no further calls towards clicks or time increase will be made
            if(Score.isgameOverCalled)
            { 
                calculateAvgShotTime();
                enabled = false;
            }

            //Increase the time our target has spawned
            timeIncrease();

            //Only call our destroyTarget method if the mouse is clicked (so we are not constantly running our method every frame)
            if(Input.GetMouseButtonDown(0))
            {
                destroyTarget();
                //Resets the the time spawned to 0 ONLY if the target is destroyed (to keep track of average time per target destroyed)
                if(Input.GetMouseButtonDown(0) && isCalled) 
                {
                    totalShotTime += timeSpawned;
                    timeSpawned = 0;
                }
            }  
        }
    }

    //Method that destroys the spawned traget
    void destroyTarget()
    {
        //Create a raycast that gets the position of our mouse (which is locked at the center of our screen at all times)
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Checks if anything that contains a physics component overlapped our raycast
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            //Create a sphere/collider at the place we clicked
            SphereCollider sc = hit.collider as SphereCollider;

            //Checking if that sphere collider has the tag "Target"
            if(sc.gameObject.CompareTag("Target"))
            {
                //If it contains the tag than destroy the target and call updateScore method, as well as spawnObject method
                isCalled = true; // Checks if we actually hit the target
                Destroy(sc.gameObject);
                FindObjectOfType<Score>().updateScore();
                FindObjectOfType<TargetSpawner>().spawnObject();
            }
        }
    }

    // Method that times how long each target is on the screen before it is destroyed
    void timeIncrease()
    {
        timeSpawned += Time.deltaTime;
    }

    //Calculates our average reaction time and converts it to miliseconds
    public void calculateAvgShotTime()
    {
        averageShotTime = (totalShotTime / Score.targetHit) * 1000;
    }
}
