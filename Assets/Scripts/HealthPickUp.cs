using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healAmount;
    public bool isFullHeal;

    public GameObject pickUpEffect;

    public int bigHeartSFX, smallHeartSFX;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (isFullHeal)
            {
                other.GetComponent<PlayerHealthController>().ResetHealth();

                AudioManager.instance.PlaySFX(bigHeartSFX);
            }
            else
            {
                other.GetComponent<PlayerHealthController>().AddHealth(healAmount);

                AudioManager.instance.PlaySFX(smallHeartSFX);
            }

            Instantiate(pickUpEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
