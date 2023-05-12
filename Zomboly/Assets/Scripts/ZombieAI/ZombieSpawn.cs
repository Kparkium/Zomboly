using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject spawnObject; // Object which will be instantiated
    public float spawnRadius; // Radius around the spawner where the gameobject can spawn
    public float spawnTime; // Interval between spawns in seconds
    public int maxObjectsAtOnce; // Maximum number of the objects allowed on the map at once from this spawner
    public int playerToggleRange; // Distance at which when the player is within, the spawner won't spawn any objects


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    public void SpawnObjectNearSpawner()
    {
        Instantiate(spawnObject, GenerateSpwanVector(), Quaternion.identity, this.transform);
    }

    private IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(spawnTime);
        if (this.transform.childCount < maxObjectsAtOnce && !CheckForNearbyPlayer()) // Check for objects
        {
            SpawnObjectNearSpawner();
        }
        StartCoroutine(SpawnLoop());

    }

    private Vector3 GenerateSpwanVector()
    {
        Vector3 newVector = new Vector3(this.transform.position.x + Random.Range(-spawnRadius, spawnRadius), this.transform.position.y, this.transform.position.z + Random.Range(-spawnRadius, spawnRadius));
        return newVector;
    }

    private bool CheckForNearbyPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position); // Distance to player
        return distanceToPlayer < playerToggleRange; // Checks if player is within the range
    }
}
