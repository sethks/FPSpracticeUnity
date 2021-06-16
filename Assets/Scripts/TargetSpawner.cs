using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public int targetsSpawned = 0; //TO-DO --- Keeps track the number of targets that spawned (for future score calculations)
    public GameObject targetObject; // Creates the target that spawns in our grid (Can be anything)
    public List<Transform> gridLocations; // List of Transform locations to choose where the targets spawn
    public Transform dupeChecker; // Empty gameobject that makes sure our targets don't spawn in the same place twice

    void Start()
    {
        //Calling our spawnObject method on game start to spawn first target 
        spawnObject();
    }

    // Method that spawns our object in a random location from our List<Transform>
    public void spawnObject()
    {
        //Creates a Vector3 variable named position that selects a random position from our list of transforms
        Vector3 position = gridLocations[Random.Range(0, gridLocations.Count)].position;

        //This if statment will be checked ONLY after the 2nd time this method is called as "duperChecker.position" does not exist yet...
        //Checks if the random Transform location selected from our list is the same as dupeCheckers position, and if it is it will re-call
        //SpawnObject until the random position choosen from our list is different so we dont have our objects spawning in the same spot
        if(dupeChecker.position == position)
        {
             spawnObject();
        }

        //If duperChecker.position is not the same as the chosen one then we will update dupeChecker.position to the chosen positon from our list
        //and create our GameObject at that location and give it the tag "Target" so we are able to call our destroyObject method on it.
        else
        {
            targetsSpawned++;
            dupeChecker.position = position;
            targetObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            targetObject.GetComponent<Transform>().position = position;
            targetObject.gameObject.tag = "Target";
        }
    }
}
