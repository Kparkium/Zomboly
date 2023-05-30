using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public ParticleSystem rainParticles;
    public ParticleSystem fogParticles;
    public ParticleSystem fireFlies;

    public int minimumRandomWeatherInterval;
    public int maximumRandomWeatherInterval;

    private GameObject player;
    private DayNightCycle dayNightCycle;
    private AudioManager audioManager;
    private GameObject currentRain;
    private GameObject currentFog;
    private GameObject currentFireFlies;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dayNightCycle = GameObject.FindGameObjectWithTag("DayNightCycle").GetComponent<DayNightCycle>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        StartCoroutine(rainLoop());
        StartCoroutine(fireFlyLoop());
    }

    private void Update()
    {
        if(player != null)
        {
            CheckForFog();
        }
    }

    private IEnumerator rainLoop()
    {
        yield return new WaitForSeconds(Random.Range(minimumRandomWeatherInterval, maximumRandomWeatherInterval));
        if(player != null)
        {
            if (currentRain != null)
            {
                Destroy(currentRain);
                audioManager.StopAudio(1);
            }
            else
            {
                currentRain = Instantiate(rainParticles.gameObject, player.transform.position + new Vector3(0,10,0), Quaternion.identity, player.transform);
                audioManager.StartAudio(1);
            }
        }
        StartCoroutine(rainLoop());
    }

    private void CheckForFog()
    {
        if (currentFog == null)
        {
            if((dayNightCycle.isNight || currentRain != null))
            {
                currentFog = Instantiate(fogParticles.gameObject, player.transform.position, Quaternion.identity, player.transform);
                Debug.Log("Spawn Fog");
            }
        }
        else if(currentFog != null)
        {
            if(dayNightCycle.isDay && currentRain == null)
            {
                Destroy(currentFog);
                Debug.Log("Destroy Fog");
            }
        }
    }

    private IEnumerator fireFlyLoop()
    {
        yield return new WaitForSeconds(minimumRandomWeatherInterval);
        if (player != null)
        {
            if(currentFireFlies != null && dayNightCycle.isDay)
            {
                Destroy(currentFireFlies);
            }
            else if(dayNightCycle.isNight)
            {
                currentFireFlies = Instantiate(fireFlies.gameObject, player.transform.position, Quaternion.identity);
            }
        }
        StartCoroutine(fireFlyLoop());
    }
}
