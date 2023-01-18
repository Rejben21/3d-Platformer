using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel, levelSelect;

    public GameObject continueButton;

    public string[] levelNames;

    void Start()
    {
        if(PlayerPrefs.HasKey("Continue"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            ResetProgres();
        }
    }

    void Update()
    {
        
    }

    public void ResetProgres()
    {
        for(int i = 0; i < levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i] + "_unlocked", 0);

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
