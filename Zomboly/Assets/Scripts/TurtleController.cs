using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurtleController : MonoBehaviour
{
    public int maxDistanceFromCenter;
    public int wanderDistance;
    public float newPositionInterval;
    public float walkSpeed;

    private NavMeshAgent agent;
    [SerializeField]
    private Vector3 targetPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkSpeed;
        StartCoroutine(UpdateTarget());
    }

    private Vector3 GetRandomPosition()
    {
        float newXPos = 0;
        float newZPos = 0;
        //Generate X pos
        if(this.transform.position.x > maxDistanceFromCenter)
        {
            newXPos = -10;
        }
        else if(this.transform.position.x < -maxDistanceFromCenter)
        {
            newXPos = 10;
        }
        else
        {
            newXPos = Random.Range(-wanderDistance, wanderDistance);
        }
        newXPos += this.transform.position.x;
        // Generate Z Pos
        if (this.transform.position.z > maxDistanceFromCenter)
        {
            newZPos = -10;
        }
        else if (this.transform.position.z < -maxDistanceFromCenter)
        {
            newZPos = 10;
        }
        else
        {
            newZPos = Random.Range(-wanderDistance, wanderDistance);
        }
        newZPos += this.transform.position.z;
        Vector3 randomPosition = new Vector3(newXPos, this.transform.position.y, newZPos);
        return randomPosition;
    }

    private void MoveToTarget()
    {
        agent.SetDestination(targetPosition);
    }

    private IEnumerator UpdateTarget()
    {
        targetPosition = GetRandomPosition();
        MoveToTarget();
        yield return new WaitForSeconds(newPositionInterval);
        StartCoroutine(UpdateTarget());
    }
}
