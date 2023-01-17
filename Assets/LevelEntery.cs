using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntery : MonoBehaviour
{
    public string levelToLoad, levelToCheck;
    public bool isOpen;

    public GameObject woodLock;

    void Start()
    {
        if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1 || levelToCheck == "")
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }
    }

    void Update()
    {
        woodLock.SetActive(!isOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
