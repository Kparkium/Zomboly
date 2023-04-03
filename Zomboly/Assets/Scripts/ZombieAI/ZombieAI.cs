using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public GameObject Target;

    [SerializeField] private Transform target;
    public float speed = 1.0f;
    [SerializeField] private float stoppingDistance = 3;
    private NavMeshAgent agent = null;
    private Animator anim = null;

    // Start is called before the first frame update
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

    public void RotateToTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
        }
    }
}