using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // Create our player a Controller
    public float speed = 12f; // Movement speed of our character
    public float gravity = -9.81f; // How fast our object falls from heights/jumps
    public float jumpHeight = 3f; // How high our player can jump
    public Transform groundCheck; // Empty game object to check when our player reaches the floor (attatched to the very bottom of our character)
    public float groundDistance = 0.4f; // Distance from ground (groundCheck)
    public LayerMask groundMask;

    Vector3 velocity; // How fast player falls (gravity)
    bool isGrounded; // Checks if our player is on the ground
 
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // If the spacebar is pressed and we are on the ground then change our velocity upwards to jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
