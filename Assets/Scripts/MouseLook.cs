using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{

    public static float mouseSensitivity = 200f;
    public Transform playerBody;
    PauseMenu _pauseMenu;
    float xRotation = 0f;

    void Start()
    {
        // Locks the cursor to the middle of our screen for crosshair accuracy.
        Cursor.lockState = CursorLockMode.Locked;
        _pauseMenu = FindObjectOfType<PauseMenu>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // If we are paused then unlock our mouse
        if(PauseMenu.isPaused || Score.timerRunning == false) 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Mouse sensitivity calculation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up *  mouseX);
    }

    public void changeSens(float sensitivity)
    {
        mouseSensitivity = sensitivity;
    }
}
