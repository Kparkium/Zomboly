using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    public float flySpeed;
    public float hoverHeight;
    public float minChangeDirectionTime;
    public float maxChangeDirectionTime;
    public int maxDistanceFromCenter;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float changeDirectionTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        changeDirectionTimer = 0.1f;
        StartCoroutine(CheckHeight());
    }

    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        // Update the change direction timer
        changeDirectionTimer -= Time.deltaTime;

        if (changeDirectionTimer <= 0f) // Change direction
        {
            // Randomly change the butterfly's direction
            Vector3 randomDirection = Random.insideUnitSphere;
            randomDirection.y = 0f; // Keep the butterfly's height constant
            randomDirection.Normalize();

            // Move the butterfly in the new direction
            if(this.transform.position.x > maxDistanceFromCenter)
            {
                moveDirection.x = (-1 * flySpeed);
            }
            else if (this.transform.position.x < -maxDistanceFromCenter)
            {
                moveDirection.x = (1 * flySpeed);
            }
            else
            {
                moveDirection.x = (randomDirection.x * flySpeed); // Allow random movement
            }
            if(this.transform.position.z > maxDistanceFromCenter)
            {
                moveDirection.z = (-1 * flySpeed);
            }
            else if(this.transform.position.z < -maxDistanceFromCenter)
            {
                moveDirection.z = (1 * flySpeed);
            }
            else
            {
                moveDirection.z = (randomDirection.z * flySpeed); // Allow random movement
            }

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized, Vector3.up);

            // Apply the rotation to the object
            transform.rotation = targetRotation;

            rb.velocity = moveDirection;

            // Reset the change direction timer
            ResetChangeDirectionTimer();
        }
        else
        {
            // Continue moving in the current direction
            rb.velocity = moveDirection;
        }
    }

    private void UpdateHeight()
    {
        // Check if the butterfly is above the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            float distanceToGround = hit.distance;
            if (distanceToGround < hoverHeight || this.transform.position.y < 5)
            {
                moveDirection.y = flySpeed / 2; // Move up
            }
            else
            {
                moveDirection.y = -flySpeed / 2; // Move down
            }
        }
    }

    void ResetChangeDirectionTimer()
    {
        changeDirectionTimer = Random.Range(minChangeDirectionTime, maxChangeDirectionTime);
    }

    public IEnumerator CheckHeight()
    {
        yield return new WaitForSeconds(2);
        UpdateHeight();
        StartCoroutine(CheckHeight());
    }
}
