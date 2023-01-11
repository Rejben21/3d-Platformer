using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int coinsAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.AddCoins(coinsAmount);

            AudioManager.instance.PlaySFX(Random.Range(1, 3));

            Destroy(gameObject);
        }
    }
}
