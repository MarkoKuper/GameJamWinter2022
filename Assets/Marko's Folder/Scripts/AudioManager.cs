using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;

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
        audioSource.Pause();
        audioSource.clip = mainMenuMusic;
        audioSource.Play();
    }

    public void PlayFactoryAmbience()
    {
        audioSource.Pause();
        audioSource.clip = factoryAmbience;
        audioSource.Play();
    }

    //Plays oneshot sound clip.
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
