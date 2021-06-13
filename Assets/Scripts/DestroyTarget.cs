using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    void Start()
    {
       
    }

    void Update()
    {
        //Only call our destroyTarget method if the mouse is clicked (so we are not constantly running our method every frame)
        if(Input.GetMouseButtonDown(0)) 
        {
            destroyTarget();
        }
        
    }

    //Method that destroys the spawned traget
    void destroyTarget()
    {
        //Create a raycast that gets the position of our mouse (which is locked at the center of our screen at all times)
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Checks if anything that contains a physics component overlapped our raycast
        if(Physics.Raycast(ray, out hit))
        {
            //Create a sphere/collider at the place we clicked
            SphereCollider sc = hit.collider as SphereCollider;
            //Checking if that sphere collider has the tag "Target"
            if(sc.gameObject.CompareTag("Target"))
            {
                //If it cointains the tag than destroy the target and call our update score and spawn another object methods
                Destroy(sc.gameObject);
                FindObjectOfType<Score>().updateScore();
                FindObjectOfType<TargetSpawner>().spawnObject();
            }
        }
    }
}
