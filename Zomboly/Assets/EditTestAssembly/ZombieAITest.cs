using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class ZombieAITest
{
    private ZombieAI zombieAI;
    private GameObject player;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject for the player
        player = new GameObject("Player");
        player.tag = "Player";

        // Create a new GameObject for the zombie and add the ZombieAI script to it
        GameObject zombieObject = new GameObject("Zombie");
        zombieAI = zombieObject.AddComponent<ZombieAI>();

        // Set up references and variables
        zombieAI.entityNavAgent = zombieObject.AddComponent<NavMeshAgent>();
        zombieAI.anim = zombieObject.AddComponent<Animator>();
        zombieAI.player = player;

        // Set up EntityScriptableObject
        zombieAI.entityScriptableObject = ScriptableObject.CreateInstance<EntityScriptableObject>();
        zombieAI.entityScriptableObject.health = 100;
        zombieAI.entityScriptableObject.trackedLockDist = 10f;
        zombieAI.entityScriptableObject.untrackedLockDist = 20f;
        zombieAI.entityScriptableObject.hostile = true;
        zombieAI.entityScriptableObject.runSpeed = 5f;
        zombieAI.entityScriptableObject.walkSpeed = 2f;
        zombieAI.entityScriptableObject.wanderRange = 5f;
        zombieAI.entityScriptableObject.minimumRandomStateChange = 2f;
        zombieAI.entityScriptableObject.maximumRandomStateChange = 5f;

        // Set up EntityAttackScriptableObject
        zombieAI.entityScriptableObject.entityAttackScriptableObject = ScriptableObject.CreateInstance<EntityAttackScriptableObject>();
        zombieAI.entityScriptableObject.entityAttackScriptableObject.attackRange = 1f;
        zombieAI.entityScriptableObject.entityAttackScriptableObject.attackAnimationState = 3;
        zombieAI.entityScriptableObject.entityAttackScriptableObject.attackDuration = 2f;
        zombieAI.entityScriptableObject.entityAttackScriptableObject.attackDuartionDamagePoint = 1f;
        zombieAI.entityScriptableObject.entityAttackScriptableObject.attackDamage = 10;
    }

    [TearDown]
    public void TearDown()
    {

    }

    [UnityTest]
    public IEnumerator ZombieAI_IsCreated()
    {
        yield return null;
        Assert.IsNotNull(zombieAI);
    }

    [UnityTest]
    public IEnumerator ZombieAI_Starts_Idle()
    {
        // Arrange
        zombieAI.distanceToPlayer = 30f;

        // Act
        Assert.IsNotNull(zombieAI);

        yield return null;

        // Assert
        Assert.AreEqual(0, zombieAI.state);
    }

    [UnityTest]
    public IEnumerator ZombieAI_Attacks_Player_When_In_Attack_Range()
    {
        // Arrange
        zombieAI.distanceToPlayer = 0.5f;
        player.transform.position = zombieAI.gameObject.transform.position + new Vector3(0.5f, 0, 0);

        // Act
        zombieAI.Update();
        yield return null;

        // Assert
        Assert.IsTrue(zombieAI.isAttacking);
        Assert.AreEqual(zombieAI.player.transform.position, zombieAI.idleDestination);
        Assert.AreEqual(zombieAI.entityScriptableObject.entityAttackScriptableObject.attackAnimationState, zombieAI.state);
        // TODO: Assert damage to player
    }

    [UnityTest]
    public IEnumerator ZombieAI_Does_Not_Attack_Player_When_Not_In_Attack_Range()
    {
        // Arrange
        zombieAI.distanceToPlayer = 5f;

        player.transform.position = zombieAI.gameObject.transform.position + new Vector3(5,0,0);
        // Act
        yield return null;

        // Assert
        Assert.IsFalse(zombieAI.isAttacking);
        Assert.AreNotEqual(zombieAI.player.transform.position, zombieAI.idleDestination);
        Assert.AreNotEqual(zombieAI.entityScriptableObject.entityAttackScriptableObject.attackAnimationState, zombieAI.state);
    }
}
