using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //-----------------------------------------------------------------[VARIABLES]-----------------------------------------------------------------
    private float moveSpeed; // The speed at which the player is currently moving
    public float walkSpeed; // Movement speed when walking
    public float runSpeed; // Movement speed when running
    public float jumpForce; // The force applied to the player when they jump
    public float playerHeightFromGround;
    public bool isGrounded; // Whether or not the player is currently on the ground
    public bool isSprinting; // Whether the player is currently sprinting
    public float movementSmoothing = 0.1f; // The smoothing applied to movement changes
    public float addedGravity;

    private Vector3 movement; // The direction of the player's movement
    private Rigidbody rb; // The player's Rigidbody component
    private UnitHealth playerHealth;

    //-----------------------------------------------------------------[START]-----------------------------------------------------------------
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHealth = GetComponent<UnitHealth>();
        playerHealth.init(100, 100);
    }

    //-----------------------------------------------------------------[UPDATES]-----------------------------------------------------------------
    private void FixedUpdate()
    {
        CheckGrounded();
        GetPlayerInput();
        ApplyMovement();
        AddDownForce();
    }
    private void Update()
    {
        CheckJump();
        CheckSprint();
    }

    //-----------------------------------------------------------------[METHODS]-----------------------------------------------------------------
    private void CheckGrounded()
    {
        // Check if the player is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeightFromGround);
    }

    private void GetPlayerInput()
    {
        // Check if movement keys are being pressed
        bool isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");

        // Update the movement vector based on the input
        if (isMoving)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            movement = this.transform.forward * vertical + this.transform.right * horizontal;
        }
        else
        {
            movement = Vector3.zero;
        }

        // Normalize the movement vector to ensure consistent speed in all directions
        movement = movement.normalized;
    }

    private void ApplyMovement()
    {
        // Calculate the target velocity
        Vector3 targetVelocity = movement * moveSpeed;
        targetVelocity.y = rb.velocity.y; // Preserve the current vertical velocity

        // Apply smooth damping to the velocity
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, movementSmoothing);
    }

    private void CheckJump()
    {
        // Check if the player is pressing the jump button and is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply a vertical impulse to the player's Rigidbody to make them jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void AddDownForce()
    {
        if(!isGrounded)
        {
            rb.AddForce(Vector3.down * addedGravity, ForceMode.Force);
        }
    }

    private void CheckSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded) // Checks if shift key is down
        {
            moveSpeed = runSpeed;
            isSprinting = true;
        }
        else
        {
            moveSpeed = walkSpeed;
            isSprinting = false;
        }
    }
}
