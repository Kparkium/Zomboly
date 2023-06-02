using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Assertions;
using Assert = UnityEngine.Assertions.Assert;

// Brad

public class PlayerTesting
{
    private GameObject testObject;
    private PlayerControls playerControls;

    [SetUp]
    public void SetUp()
    {
        testObject = new GameObject();
        playerControls = testObject.AddComponent<PlayerControls>();
        // Use the static reference to the player object
        Assert.IsNotNull(playerControls, "PlayerControls component not found on the player object.");
    }

    [TearDown]
    public void TearDown()
    {

    }

    [UnityTest]
    public IEnumerator PlayerControls_CheckGrounded()
    {
        playerControls.CheckGrounded();
        yield return null;
        Assert.IsFalse(playerControls.isGrounded); // Expect false as should be no ground to interact with
    }

    [UnityTest]
    public IEnumerator PlayerControls_GetPlayerInput_NoInput()
    {
        playerControls.isGrounded = true;
        playerControls.GetPlayerInput();
        yield return null;
        Assert.AreEqual(Vector3.zero, playerControls.movement);
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
    public IEnumerator PlayerControls_CheckHealth()
    {
        if(playerControls.playerHealth == null)
        {
            playerControls.playerHealth = playerControls.gameObject.AddComponent<UnitHealth>();
            playerControls.playerHealth.init(100, 100);
        }
        bool newCheck = playerControls.playerHealth._currentHealth == playerControls.playerHealth.MaxHealth;
        yield return null;
        Assert.IsTrue(newCheck);

        playerControls.playerHealth.DamageUnit(5);
        bool damageCheck = playerControls.playerHealth._currentHealth == playerControls.playerHealth.MaxHealth - 5;
        yield return null;
        Assert.IsTrue(damageCheck);
    }

}
