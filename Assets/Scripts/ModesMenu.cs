using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModesMenu : MonoBehaviour
{
    //Loads singleTarget gamemode
    public void singleTarget()
    {
        SceneManager.LoadScene(2);
    }

    // TO-DO --- loads multiTarget gamemode
    // public void multiTarget()
    // {

    // }

    // TO-DO --- loads trackTarget gamemode
    // public void targetTrack()
    // {

    // }

    public void backButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
