using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayDurationInMinutes = 10f;
    public float currentTimeOfDay = 12f;
    public Color dayColor = new Color(1f, 1f, 1f);
    public Color nightColor = new Color(0.2f, 0.2f, 0.4f);
    public float dawnDuskDurationInHours = 1f;
    public Color dawnColor = new Color(1f, 0.8f, 0.4f);
    public Color duskColor = new Color(0.8f, 0.2f, 0.2f);
    public bool isDay;
    public bool isNight;

    private Light directionalLight;

    // Start is called before the first frame update
    void Start()
    {
        directionalLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        CheckTimeOfDay();
    }

    private void UpdateTime()
    {
        // Calculate current time of day
        currentTimeOfDay += Time.deltaTime / (dayDurationInMinutes * 60f) * 24f; // Calculate the time of day based on the desired output in minutes
        currentTimeOfDay %= 24f; // Take the modulo of 24 to reset back to 0 at the end of the day

        // Calculate normalized time and rotation
        float normalizedTime = currentTimeOfDay / 24f; // Time of day as a scale of 0 to 1
        float rotation = normalizedTime * 360f - 90f; // The rotation of the sun in relation to time of day

        // Update directional light rotation
        transform.localRotation = Quaternion.Euler(rotation, 170f, 0f); // Set rotation of light

        // Update directional light color
        if (directionalLight != null)
        {
            if (normalizedTime < dawnDuskDurationInHours / 24f)
            {
                float t = Mathf.Clamp01(normalizedTime / (dawnDuskDurationInHours / 24f));
                directionalLight.color = Color.Lerp(nightColor, dawnColor, t);
            }
            else if (normalizedTime > 1f - (dawnDuskDurationInHours / 24f))
            {
                float t = Mathf.Clamp01((1f - normalizedTime) / (dawnDuskDurationInHours / 24f));
                directionalLight.color = Color.Lerp(nightColor, duskColor, t);
            }
            else
            {
                directionalLight.color = dayColor;
            }
        }
    }

    private void CheckTimeOfDay()
    {
        if(currentTimeOfDay < 6 || currentTimeOfDay > 18)
        {
            isNight = true;
            isDay = false;
        }
        else
        {
            isNight = false;
            isDay = true;
        }
    }
}