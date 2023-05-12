using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityScriptableObject", menuName = "ScriptableObjects/Entity")]
public class ZombieScriptableObject : ScriptableObject
{
    [Header("MODIFIERS")]
    public int health; // Health value of the entity
    public bool hostile; // Will track & attack the player if hostile
    public float walkSpeed; // Speed of the enemy when not tracking the player
    public float runSpeed; // Speed of the enemy when tracking the player
    public float wanderRange; // Maximum distance the enemy can wander from its starting position
    public float untrackedLockDist; // Distance at which the enemy will stop tracking the player
    public float trackedLockDist; // Distance at which the enemy will start tracking the player again after losing track
    public float minimumRandomStateChange; // Minimum time before the state randomly changes
    public float maximumRandomStateChange; // Maximum time before the state randomly changes
    public ZombieAttackScriptableObject entityAttackScriptableObject;
}
