using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;

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
    public void PlayNewBackgroundMusic(AudioClip clip)
    {
        audioSource.Pause();
        audioSource.clip = clip;
        audioSource.Play();
    }

    //Plays oneshot sound clip.
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
