using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntery : MonoBehaviour
{
    public string levelToLoad, levelToCheck, levelName;
    public bool isOpen;

    public GameObject woodLock;
    public float distanceToPlayer;
    private bool goToLevel;

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

        distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        if(distanceToPlayer <= 1.5)
        {
            goToLevel = true;
        }
        else
        {
            goToLevel = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LSUIManager.instance.levelPanel.SetActive(true);
        LSUIManager.instance.levelNameText.text = levelName;

        if(PlayerPrefs.HasKey(levelToLoad + "_coins"))
        {
            LSUIManager.instance.coinsText.text = PlayerPrefs.GetInt(levelToLoad + "_coins").ToString();
        }
        else
        {
            LSUIManager.instance.coinsText.text = " ???";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && goToLevel)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LSUIManager.instance.levelPanel.SetActive(false);
    }
}
