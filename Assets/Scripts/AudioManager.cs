using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundtrucks;
    public AudioSource[] soundEffects;

    public AudioMixerGroup musicMixer, SFXMixer;

    private int curTruck;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void PlayMusic(int newTruck)
    {
        if (newTruck == curTruck)
        {

        }
        else
        {
            soundtrucks[curTruck].Stop();
            soundtrucks[newTruck].Play();
            curTruck = newTruck;
        }
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        soundEffects[soundToPlay].Play();
    }

    public void SetMusicLevel()
    {
        musicMixer.audioMixer.SetFloat("MusicVol", UICanvas.instance.musicVolSlider.value);
    }

    public void SetSFXLevel()
    {
        SFXMixer.audioMixer.SetFloat("SFXVol", UICanvas.instance.sfxVolSlider.value);
    }
}
