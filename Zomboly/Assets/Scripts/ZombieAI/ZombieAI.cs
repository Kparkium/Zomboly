using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    // References (Auto gets)
    [SerializeField]
    private GameObject player;
    private NavMeshAgent entityNavAgent;
    private UnitHealth target;
    private EntityAnimationControl entityAnimationControl;

    // Zombie configuration
    public ZombieScriptableObject entityScriptableObject;

    public int state = 0; // Default states {0 = Idle, 1 = Walk, 2 = Run
    public float distanceToPlayer;

    // Private variables
    [SerializeField]
    private Vector3 idleDestination;  // Randomly generated position for the enemy to move towards when not tracking the player
    private bool idleTimerOver = true;  // Whether the enemy is ready to generate a new idle position
    private bool trackingPlayer = false;  // Whether the enemy is currently tracking the player
    private bool isAttacking = false;

    private void Awake()
    {
        entityNavAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        // Set player reference
        player = GameObject.FindGameObjectWithTag("Player");
        idleDestination = this.transform.position;
    }

    private void Update()
    {
        CalculateDestination();
    }

    private void UpdateState()
    {
        entityAnimationControl.UpdateAnimationIndex(state);
    }


    // Calculates the next destination based on player proximity
    private void CalculateDestination()
    {
        TrackingPlayerLoop(); // Will track player if target is within range
    }

    // Starts tracking the player
    private void TrackingPlayerLoop()
    {

        Debug.Log("asdas");
        trackingPlayer = true;
        entityNavAgent.speed = entityScriptableObject.runSpeed;
        entityNavAgent.SetDestination(player.transform.position);


    }

    private IEnumerator Attack()
    {
        // Stop tracking
        trackingPlayer = false;
        isAttacking = true;
        idleDestination = player.transform.position; // Update destination to point towards players location
        // Play attack animation
        state = entityScriptableObject.entityAttackScriptableObject.attackAnimationState; // Attacking

        // Damage Target
        RaycastHit targetObject;
        if (Physics.Raycast(transform.position, transform.forward, out targetObject, entityScriptableObject.entityAttackScriptableObject.attackRange)) // Checks for valid hit
        {
            UnitHealth hitTarget = targetObject.transform.GetComponent<UnitHealth>();
            if (hitTarget != null)
            { // If target is valid and has a target script
                StartCoroutine(DoAttackDamage(targetObject.transform.gameObject));
                Debug.Log(this.gameObject.name + " Attacked " + targetObject.transform.gameObject.name);
            }
        }

        // Wait for attack duration
        yield return new WaitForSeconds(entityScriptableObject.entityAttackScriptableObject.attackDuration);

        // Start tracking
        isAttacking = false;
        trackingPlayer = true;
    }

    private IEnumerator DoAttackDamage(GameObject targetObject)
    {
        // Shoot raycast for player instead? (Or object of target type, like gun)
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.transform.position); // Distance to target
        yield return new WaitForSeconds(entityScriptableObject.entityAttackScriptableObject.attackDuartionDamagePoint);
        if (distanceToTarget <= entityScriptableObject.entityAttackScriptableObject.attackRange)
        {
            UnitHealth hitTarget = targetObject.transform.GetComponent<UnitHealth>();
            hitTarget.DamageUnit(20); // Do damage
        }
    }
}