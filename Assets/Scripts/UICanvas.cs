using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICanvas : MonoBehaviour
{
    public static UICanvas instance;

    public Image fadeScreen;
    public float fadeSpeed = 1;
    private bool fadeToBlack, fadeFromBlack;

    public Text healthText;
    public Text coinsText;

    public GameObject pauseScreen;
    public GameObject optionsScreen;

    public Slider musicVolSlider, sfxVolSlider;

    private void Awake()
    {
        instance = this;

        if(AudioManager.instance.gameObject != null)
        {
            AudioManager.instance.SaveSoundSettings();
        }
        else
        {

        }
    }

    void Start()
    {
        AudioManager.instance.SaveSoundSettings();

        FadeFromBlack();

        SetSFXLevel();
        SetMusicLevel();
    }

    void Update()
    {
        if(fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1)
            {
                fadeToBlack = false;
            }
        }

        if(fadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        fadeFromBlack = false;
        fadeToBlack = true;
    }

    public void FadeFromBlack()
    {
        fadeToBlack = false;
        fadeFromBlack = true;
    }

    public void Resume()
    {
        GameManager.instance.PauseUnpause();
    }

    public void Options()
    {
        if(optionsScreen.activeInHierarchy)
        {
            optionsScreen.SetActive(false);
        }
        else
        {
            optionsScreen.SetActive(true);
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
        PlayerController.instance.stopMove = false;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        PlayerController.instance.stopMove = false;
        Time.timeScale = 1;
    }

    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel();
    }

    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }
}
