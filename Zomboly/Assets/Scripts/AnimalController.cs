using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public GameObject butterFly;
    public Vector3[] animalSpawnLocations;
    public int maxAnimals;
    public int spawnTimer;
    private List<GameObject> spawnList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateAnimals());
    }

    private IEnumerator UpdateAnimals()
    {
        if(spawnList.Count < maxAnimals)
        {
            int locationIndex = Random.Range(0, animalSpawnLocations.Length);
            spawnList.Add(Instantiate(butterFly, this.transform.position + animalSpawnLocations[locationIndex], Quaternion.identity));
        }
        yield return new WaitForSeconds(spawnTimer);
        StartCoroutine(UpdateAnimals());
    }
}
