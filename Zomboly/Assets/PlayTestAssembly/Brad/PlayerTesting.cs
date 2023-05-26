using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Assertions;
using Assert = NUnit.Framework.Assert;

public class PlayerControlsTests
{
    public GameObject playerObject;
    private PlayerControls playerControls;

    [SetUp]
    public void SetUp()
    {
        playerObject = GameObject.Find("Player");

        // Add null check to ensure the player object is found
        Assert.IsNotNull(playerObject, "Player object not found.");

        // Add null check to ensure PlayerControls component is attached
        playerControls = playerObject.GetComponent<PlayerControls>();
        Assert.IsNotNull(playerControls, "PlayerControls component not found on the player object.");
    }

    [TearDown]
    public void TearDown()
    {
        //Object.DestroyImmediate(playerControls.gameObject);
    }

    [UnityTest]
    public IEnumerator PlayerControls_CheckGrounded()
    {
        playerControls.CheckGrounded();
        yield return null;
        Assert.IsTrue(playerControls.isGrounded);
    }

    [UnityTest]
    public IEnumerator PlayerControls_GetPlayerInput_NoInput()
    {
        playerControls.GetPlayerInput();
        yield return null;
        Assert.AreEqual(Vector3.zero, playerControls.movement);
    }

    [UnityTest]
    public IEnumerator PlayerControls_GetPlayerInput_Moving()
    {
        // Simulate input
        SetHorizontalInput(1f);
        SetVerticalInput(1f);
        yield return null;

        playerControls.GetPlayerInput();

        // Expected movement vector
        Vector3 expectedMovement = playerControls.transform.forward + playerControls.transform.right;

        Assert.AreEqual(expectedMovement, playerControls.movement);
    }

    [UnityTest]
    public IEnumerator PlayerControls_ApplyMovement()
    {
        // Set up initial position and velocity
        playerControls.rb.position = Vector3.zero;
        playerControls.rb.velocity = Vector3.zero;

        // Set up movement vector
        playerControls.movement = Vector3.forward;

        playerControls.ApplyMovement();
        yield return new WaitForFixedUpdate();

        // Expected velocity after applying movement
        Vector3 expectedVelocity = Vector3.forward * playerControls.walkSpeed;

        Assert.AreEqual(expectedVelocity, playerControls.rb.velocity);
    }

    [UnityTest]
    public IEnumerator PlayerControls_CheckJump()
    {
        // Simulate input
        playerControls.isGrounded = false;
        yield return null;

        playerControls.CheckJump();
        yield return null;

        Assert.AreEqual(playerControls.jumpForce, playerControls.rb.velocity.y);
    }

    [UnityTest]
    public IEnumerator PlayerControls_AddDownForce()
    {
        playerControls.AddDownForce();
        yield return null;

        Assert.AreEqual(Vector3.down * playerControls.addedGravity, playerControls.rb.velocity);
    }

    [UnityTest]
    public IEnumerator PlayerControls_CheckSprint_NoSprint()
    {
        playerControls.CheckSprint();
        yield return null;

        Assert.AreEqual(playerControls.walkSpeed, playerControls.moveSpeed);
        Assert.IsFalse(playerControls.isSprinting);
    }

    [UnityTest]
    public IEnumerator PlayerControls_CheckSprint_Sprint()
    {
        // Simulate input
        playerControls.isSprinting = (true);
        yield return null;

        playerControls.CheckSprint();
        yield return null;

        Assert.AreEqual(playerControls.runSpeed, playerControls.moveSpeed);
        Assert.IsTrue(playerControls.isSprinting);
    }

    // Helper methods to simulate input
    private void SetHorizontalInput(float value)
    {
        playerControls.horizontalInput = value;
    }

    private void SetVerticalInput(float value)
    {
        playerControls.verticalInput = value;
    }
}
