using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //-----------------------------------------------------------------[VARIABLES]-----------------------------------------------------------------
    public float moveSpeed; // The speed at which the player is currently moving
    public float walkSpeed; // Movement speed when walking
    public float runSpeed; // Movement speed when running
    public float jumpForce; // The force applied to the player when they jump
    public float playerHeightFromGround;
    public bool isGrounded; // Whether or not the player is currently on the ground
    public bool isSprinting; // Whether the player is currently sprinting
    public bool canSprint;
    public bool isMoving;
    public float movementSmoothing = 0.1f; // The smoothing applied to movement changes
    public float addedGravity;
    public float waterLevel;
    public bool isInWater;

    public Vector3 movement; // The direction of the player's movement
    public Rigidbody rb; // The player's Rigidbody component
    public UnitHealth playerHealth;
    public float maxStamina;
    public float staminaDrain;


    // Testing
    public float horizontalInput;
    public float verticalInput;
    public float stamina;


    //-----------------------------------------------------------------[START]-----------------------------------------------------------------
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHealth = GetComponent<UnitHealth>();
        playerHealth.init(100, 100);
        stamina = maxStamina;
        canSprint = true;
        StartCoroutine(WaterDamage());
    }

    //-----------------------------------------------------------------[UPDATES]-----------------------------------------------------------------
    public void FixedUpdate()
    {
        CheckGrounded();
        GetPlayerInput();
        ApplyMovement();
        AddDownForce();
        CheckBelowWater();
    }
    public void Update()
    {
        CheckJump();
        CheckSprint();
        UpdateStamina();
    }

    //-----------------------------------------------------------------[METHODS]-----------------------------------------------------------------
    public void CheckGrounded()
    {
        // Check if the player is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeightFromGround);
    }

    public void GetPlayerInput()
    {
        // Check if movement keys are being pressed
        isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");

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

    public void ApplyMovement()
    {
        // Calculate the target velocity
        Vector3 targetVelocity = movement * moveSpeed;
        targetVelocity.y = rb.velocity.y; // Preserve the current vertical velocity

        // Apply smooth damping to the velocity
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, movementSmoothing);
    }

    public void CheckJump()
    {
        // Check if the player is pressing the jump button and is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply a vertical impulse to the player's Rigidbody to make them jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void AddDownForce()
    {
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * addedGravity, ForceMode.Force);
        }
    }

    public void CheckSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded && canSprint && isMoving) // Checks if shift key is down
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

    public void UpdateStamina()
    {
        if (isSprinting && stamina > 0)
        {
            stamina -= staminaDrain * Time.deltaTime;
        }
        else if(stamina < maxStamina)
        {
            stamina += staminaDrain * Time.deltaTime;
        }

        if(stamina <= 1)
        {
            canSprint = false;
            StartCoroutine(waitForSprintTimer());
        }
    }

    private IEnumerator waitForSprintTimer()
    {
        yield return new WaitForSeconds(3);
        canSprint = true;
    }

    private void CheckBelowWater()
    {
        if(this.transform.position.y < waterLevel)
        {
            isInWater = true;

        }
        else
        {
            isInWater = false;
        }
    }

    private IEnumerator WaterDamage()
    {
        yield return new WaitForSeconds(1);
        if(isInWater)
        {
            playerHealth.DamageUnit(5);
        }
        StartCoroutine(WaterDamage());
    }
}
