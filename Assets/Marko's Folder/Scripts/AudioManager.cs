using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSourceBg;

    public AudioClip mainMenuMusic;
    public AudioClip factoryAmbience;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    //Changes background ambient sound or music loop.
    public void PlayMainMenuMusic()
    {
        audioSourceBg.Pause();
        audioSourceBg.clip = mainMenuMusic;
        audioSourceBg.Play();
    }

    public void PlayFactoryAmbience()
    {
        audioSourceBg.Pause();
        audioSourceBg.clip = factoryAmbience;
        audioSourceBg.Play();
    }

    //Plays oneshot sound clip.
    public void PlaySound(AudioClip clip)
    {
        audioSourceBg.PlayOneShot(clip);
    }

    public void PlayFootSteps(AudioSource audioSource)
    {
        audioSource.Play();
    }

    public void StopFootSteps(AudioSource audioSource)
    {
        audioSource.Pause();
    }
}
