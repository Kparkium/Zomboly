using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public GameObject butterfly;
    public GameObject turtle;
    public Vector3[] flyingAnimalSpawnLocations;
    public Vector3[] groundAnimalSpawnLocations;
    public int maxAnimals;
    public int spawnTimer;
    private List<GameObject> spawnList;

    // Start is called before the first frame update
    void Start()
    {
        spawnList = new List<GameObject>();
        StartCoroutine(UpdateAnimals());
    }

    private IEnumerator UpdateAnimals()
    {
        if(spawnList.Count < maxAnimals)
        {
            int flyingIndex = Random.Range(0, flyingAnimalSpawnLocations.Length);
            spawnList.Add(Instantiate(butterfly, flyingAnimalSpawnLocations[flyingIndex], Quaternion.identity));
            int groundIndex = Random.Range(0, groundAnimalSpawnLocations.Length);
            spawnList.Add(Instantiate(turtle, groundAnimalSpawnLocations[groundIndex], Quaternion.identity));
        }
        yield return new WaitForSeconds(spawnTimer);
        StartCoroutine(UpdateAnimals());
    }
}
