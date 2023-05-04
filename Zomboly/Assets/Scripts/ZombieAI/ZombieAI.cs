using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    //Player is the target.
    public GameObject Target;

    [SerializeField] private Transform target;
    public float speed = 1.0f;
    [SerializeField] private float stoppingDistance = 3;
    private NavMeshAgent agent = null;
    private Animator anim = null;

    private void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        transform.LookAt(Target.gameObject.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        MoveToTarget();
    }

    //Method that makes the zombie face the target.
    public void RotateToTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    //Method that is used for the zombie to move towards the target.
    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        //Stopping distance. Once the zombie has reached the target, it should stop but not working.

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
        }
    }
}