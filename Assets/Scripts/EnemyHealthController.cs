using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int maxHealth;
    private int curHealth;

    public GameObject damageParticle;
    public GameObject coinPrefab;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage()
    {
        curHealth--;

        if(curHealth <= 0)
        {
            PlayerController.instance.Bounce();
            AudioManager.instance.PlaySFX(6);
            Instantiate(damageParticle, transform.position, Quaternion.identity);
            Instantiate(coinPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Destroy(gameObject, .075f);
        }
    }
}
