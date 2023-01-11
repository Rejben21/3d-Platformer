using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healAmount;
    public bool isFullHeal;

    public GameObject pickUpEffect;

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

                AudioManager.instance.PlaySFX(4);
            }
            else
            {
                other.GetComponent<PlayerHealthController>().AddHealth(healAmount);

                AudioManager.instance.PlaySFX(5);
            }

            Instantiate(pickUpEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
