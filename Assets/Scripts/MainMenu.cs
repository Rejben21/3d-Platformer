using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    public string firstLevel, levelSelect;

    public GameObject continueButton;

    public string[] levelNames;

    public GameObject optionsPanel;
    public Slider musicVolSlider, sfxVolSlider;

    public int menuTruck;

    private void Awake()
    {
        instance = this;

        AudioManager.instance.SaveSoundSettings();
    }

    void Start()
    {
        AudioManager.instance.SaveSoundSettings();

        if (PlayerPrefs.HasKey("Continue"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            ResetProgres();
        }

        AudioManager.instance.PlayMusic(menuTruck);
    }

    void Update()
    {
        
    }

    public void Options()
    {
        if(optionsPanel.activeInHierarchy == true)
        {
            optionsPanel.SetActive(false);
        }
        else
        {
            optionsPanel.SetActive(true);
        }
    }

    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel();
    }

    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }

    public void ResetProgres()
    {
        for(int i = 0; i < levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i] + "_unlocked", 0);

            PlayerPrefs.SetInt(levelNames[i] + "_coins", 0);
        }
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(firstLevel);

        PlayerPrefs.SetInt("Continue", 0);

        ResetProgres();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
