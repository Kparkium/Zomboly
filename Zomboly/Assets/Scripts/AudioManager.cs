using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource windSource; // 0
    public AudioSource rainSource; // 1
    public float fadeTime;
    public float maxVolume;

    private Coroutine fadeCoroutine;

    public void StopAudio(int i)
    {
        if (i == 0)
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }
            fadeCoroutine = StartCoroutine(FadeOutVolume(windSource));
        }
        else if (i == 1)
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }
            fadeCoroutine = StartCoroutine(FadeOutVolume(rainSource));
        }
    }

    public void StartAudio(int i)
    {
        if (i == 0)
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }
            windSource.volume = 0;
            windSource.Play();
            fadeCoroutine = StartCoroutine(FadeInVolume(windSource));
        }
        else if (i == 1)
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }
            rainSource.volume = 0;
            rainSource.Play();
            fadeCoroutine = StartCoroutine(FadeInVolume(rainSource));
        }
    }

    private IEnumerator FadeInVolume(AudioSource audioSource)
    {
        while (audioSource.volume < maxVolume)
        {
            audioSource.volume += (Time.deltaTime / fadeTime);
            yield return null;
        }
    }

    private IEnumerator FadeOutVolume(AudioSource audioSource)
    {
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= (Time.deltaTime / fadeTime);
            yield return null;
        }
        audioSource.Stop();
    }
}
