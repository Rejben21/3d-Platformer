using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    public int curCoins;

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
        
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(1);
        UICanvas.instance.FadeToBlack();
        AudioManager.instance.PlaySFX(3);

        yield return new WaitForSeconds(1);
        PlayerController.instance.gameObject.SetActive(false);
        CameraController.instance.cMBrain.enabled = false;
        PlayerController.instance.moveDirection = Vector3.zero;

        yield return new WaitForSeconds(.1f);

        PlayerController.instance.transform.position = respawnPosition;
        CameraController.instance.cMBrain.enabled = true;
        PlayerController.instance.gameObject.SetActive(true);
        PlayerHealthController.instance.ResetHealth();

        UICanvas.instance.FadeFromBlack();
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
}
