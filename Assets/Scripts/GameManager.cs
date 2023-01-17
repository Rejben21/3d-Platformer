using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    public int curCoins;

    public string levelToLoad;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = PlayerController.instance.transform.position;

        UICanvas.instance.coinsText.text = curCoins.ToString();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        PlayerHealthController.instance.canDamage = false;

        yield return new WaitForSeconds(1);
        UICanvas.instance.FadeToBlack();
        AudioManager.instance.PlaySFX(3);

        yield return new WaitForSeconds(1);
        PlayerController.instance.gameObject.SetActive(false);
        if(FindObjectOfType<CameraController>() != null)
        {
            CameraController.instance.cMBrain.enabled = false;
        }
        PlayerController.instance.moveDirection = Vector3.zero;

        yield return new WaitForSeconds(.1f);

        PlayerController.instance.transform.position = respawnPosition;
        if (FindObjectOfType<CameraController>() != null)
        {
            CameraController.instance.cMBrain.enabled = true;
        }
        PlayerController.instance.gameObject.SetActive(true);
        PlayerHealthController.instance.ResetHealth();

        UICanvas.instance.FadeFromBlack();

        PlayerHealthController.instance.canDamage = true;
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
    }

    public void AddCoins(int coinsAmount)
    {
        curCoins += coinsAmount;
        UICanvas.instance.coinsText.text = curCoins.ToString();
    }

    public void PauseUnpause()
    {
        if (UICanvas.instance.pauseScreen.activeInHierarchy)
        {
            UICanvas.instance.pauseScreen.SetActive(false);
            Time.timeScale = 1f;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            UICanvas.instance.pauseScreen.SetActive(true);
            UICanvas.instance.optionsScreen.SetActive(false);
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void LevelComplete()
    {
        StartCoroutine(LevelCompleteCo());
    }

    public IEnumerator LevelCompleteCo()
    {
        Debug.Log("Level Complete!");
        PlayerController.instance.stopMove = true;

        yield return new WaitForSeconds(2f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);

        SceneManager.LoadScene(levelToLoad);
        PlayerController.instance.stopMove = false;
        Time.timeScale = 1;
    }
}
