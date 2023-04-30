using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //-----------------------------------------------------------------[VARIABLES]-----------------------------------------------------------------
    private float moveSpeed; // Movement speed
    public float walkSpeed = 5f; // Movement speed
    public float runSpeed = 8f; // Movement speed
    public float jumpForce = 7f; // Jump force
    public float gravity = -9.81f;

    public Vector3 velocity;
    public CharacterController controller;

    public Transform groundCheck;
    public float distanceToGround = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;


    //-----------------------------------------------------------------[UPDATE]-----------------------------------------------------------------
    // Fixed Update is called at set intervals
    private void Update()
    {
        MovePlayer();
        CheckGrounded();
        CheckSprint();
        JumpCheck();
    }



    //-----------------------------------------------------------------[MOVEMENT]-----------------------------------------------------------------
    private void JumpCheck()
    {
        // Jump if the Jump button is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void MovePlayer()
    {
        // Get input values
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Vector stores players directional movement
        Vector3 moveVector = transform.right * moveHorizontal + transform.forward * moveVertical;

        // Moves player model in game
        controller.Move(moveVector * moveSpeed * Time.deltaTime);

        // Moves player down with gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, distanceToGround, groundMask); // Checks if player is touching the ground

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Resets vertical velocity
        }

    }

    private void CheckSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded) // Checks if shift key is down
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }
}