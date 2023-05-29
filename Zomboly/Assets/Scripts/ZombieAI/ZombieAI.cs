using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    // References (Auto gets)
    private GameObject player;
    private NavMeshAgent entityNavAgent;
    private UnitHealth zombieHealth;

    [Header("PUBLIC REFERENCES")]
    // Entity configuration
    public EntityScriptableObject entityScriptableObject;
    public Animator anim;

    [Header("OTHER VARIABLES")]
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
        zombieHealth = gameObject.AddComponent<UnitHealth>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        // Set player reference
        player = GameObject.FindGameObjectWithTag("Player");
        idleDestination = this.transform.position;
        zombieHealth.init(entityScriptableObject.health, entityScriptableObject.health);
    }

    private void Update()
    {
        CalculateDestination();
        UpdateState();
    }

    private void UpdateState()
    {
        anim.SetInteger("animIndex", state);
    }


    // Calculates the next destination based on player proximity
    private void CalculateDestination()
    {
        if(player != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position); // Distance to player
        }
        // If player is within target range, start tracking player
        if (distanceToPlayer <= (trackingPlayer ? entityScriptableObject.trackedLockDist : entityScriptableObject.untrackedLockDist) && entityScriptableObject.hostile && player != null)
        {
            TrackingPlayerLoop(); // Will track player if target is within range
        }
        // If player is too far away, stop tracking player and idle
        else
        {
            IdleLoop();
        }
    }

    // Starts tracking the player
    private void TrackingPlayerLoop()
    {
        if (distanceToPlayer <= entityScriptableObject.entityAttackScriptableObject.attackRange && !isAttacking) // distanceToPlayer <= attack distance  then do attack instead
        {
            StartCoroutine(Attack());
        }
        else
        {
            if (!isAttacking)
            {
                trackingPlayer = true;
                entityNavAgent.speed = entityScriptableObject.runSpeed;
                entityNavAgent.SetDestination(player.transform.position);
                state = 2; // Running
            }
        }
    }

    // Stops tracking the player
    private void IdleLoop()
    {
        trackingPlayer = false;
        entityNavAgent.speed = entityScriptableObject.walkSpeed;

        if (idleTimerOver)
        {
            StartCoroutine(RandomSwitchState());
        }
    }

    // Generates a new idle position
    private void SetRandomNewDestination()
    {
        // Generate new idle position
        idleDestination = new Vector3(transform.position.x + Random.Range(-entityScriptableObject.wanderRange, entityScriptableObject.wanderRange),
                                      transform.position.y,
                                      transform.position.z + Random.Range(-entityScriptableObject.wanderRange, entityScriptableObject.wanderRange));
        entityNavAgent.SetDestination(idleDestination);
    }

    private IEnumerator RandomSwitchState()
    {
        idleTimerOver = false;
        int newState = Random.Range(0, 2); // Random choice between idle (0) and walk (1)
        if (newState == 0) // Idle
        {
            state = 0; // Idle
            entityNavAgent.SetDestination(this.transform.position);
        }
        else if (newState == 1) // Walk
        {
            state = 1; // Walking
            SetRandomNewDestination();
        }
        yield return new WaitForSeconds(Random.Range(entityScriptableObject.minimumRandomStateChange, entityScriptableObject.maximumRandomStateChange));
        idleTimerOver = true;
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
            if(targetObject!= null)
            {
                UnitHealth hitTarget = targetObject.transform.GetComponent<UnitHealth>();
                hitTarget.DamageUnit(entityScriptableObject.entityAttackScriptableObject.attackDamage); // Do damage
            }
        }
    }
}

