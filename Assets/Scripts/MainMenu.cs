using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel, levelSelect;

    public GameObject continueButton;

    void Start()
    {
        if(PlayerPrefs.HasKey("Continue"))
        {
            continueButton.SetActive(true);
        }
    }

    void Update()
    {
        
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(firstLevel);

        PlayerPrefs.SetInt("Continue", 0);
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
