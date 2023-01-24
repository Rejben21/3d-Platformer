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

    private float musicVolValue, sfxVolValue;

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

        SaveSoundSettings();
    }

    void Start()
    {
        SaveSoundSettings();
    }

    void Update()
    {

    }

    public void SaveSoundSettings()
    {
        if (UICanvas.instance != null)
        {
            UICanvas.instance.musicVolSlider.value = PlayerPrefs.GetFloat("Music Value");
            UICanvas.instance.sfxVolSlider.value = PlayerPrefs.GetFloat("SFX Value");
        }
        else if (MainMenu.instance != null)
        {
            MainMenu.instance.musicVolSlider.value = PlayerPrefs.GetFloat("Music Value");
            MainMenu.instance.sfxVolSlider.value = PlayerPrefs.GetFloat("SFX Value");
        }
        else
        {

        }
        musicMixer.audioMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("Music Value"));
        SFXMixer.audioMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFX Value"));
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
        if(MainMenu.instance != null)
        {
            musicMixer.audioMixer.SetFloat("MusicVol", MainMenu.instance.musicVolSlider.value);
            PlayerPrefs.SetFloat("Music Value", MainMenu.instance.musicVolSlider.value);
        }
        else if(UICanvas.instance != null)
        {
            musicMixer.audioMixer.SetFloat("MusicVol", UICanvas.instance.musicVolSlider.value);
            PlayerPrefs.SetFloat("Music Value", UICanvas.instance.musicVolSlider.value);
        }
        else
        {

        }
    }

    public void SetSFXLevel()
    {
        if (MainMenu.instance != null)
        {
            SFXMixer.audioMixer.SetFloat("SFXVol", MainMenu.instance.sfxVolSlider.value);
            PlayerPrefs.SetFloat("SFX Value", MainMenu.instance.sfxVolSlider.value);
        }
        else if(UICanvas.instance != null)
        {
            SFXMixer.audioMixer.SetFloat("SFXVol", UICanvas.instance.sfxVolSlider.value);
            PlayerPrefs.SetFloat("SFX Value", UICanvas.instance.sfxVolSlider.value);
        }
        else
        {

        }
    }
}
