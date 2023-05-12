using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityAttackScriptableObject", menuName = "ScriptableObjects/EntityAttack")]
public class ZombieAttackScriptableObject : ScriptableObject
{
    public float attackDamage;
    public float attackRange;
    public int attackAnimationState;
    public AudioClip attackClip;
    public float attackDuration;
    public float attackDuartionDamagePoint; // Time during attack where if player is still within attack range, damage will be done
}
