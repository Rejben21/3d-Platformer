using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundtrucks;
    public AudioSource[] soundEffects;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayMusic(0);
    }

    void Update()
    {
        
    }

    public void PlayMusic(int truckToPlay)
    {
        soundtrucks[truckToPlay].Play();
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        soundEffects[soundToPlay].Play();
    }
}
