using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int coinsAmount;
    public int[] sFX;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.AddCoins(coinsAmount);

            AudioManager.instance.PlaySFX(Random.Range(sFX[0], sFX.Length + 1));

            Destroy(gameObject);
        }
    }
}
