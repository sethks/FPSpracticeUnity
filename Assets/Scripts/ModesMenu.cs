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

    public void backButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
