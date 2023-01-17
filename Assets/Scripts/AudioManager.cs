using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public int soundtruck;

    public AudioSource[] soundtrucks;
    public AudioSource[] soundEffects;

    public AudioMixerGroup musicMixer, SFXMixer;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayMusic(soundtruck);
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

    public void SetMusicLevel()
    {
        musicMixer.audioMixer.SetFloat("MusicVol", UICanvas.instance.musicVolSlider.value);
    }

    public void SetSFXLevel()
    {
        SFXMixer.audioMixer.SetFloat("SFXVol", UICanvas.instance.sfxVolSlider.value);
    }
}
