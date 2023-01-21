using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int maxHealth;
    private int curHealth;

    public GameObject damageParticle;

    public bool dropCoin;
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
        Instantiate(damageParticle, transform.position, Quaternion.identity);
        AudioManager.instance.PlaySFX(6);
        PlayerController.instance.Bounce();
        PlayerController.instance.Knockback();

        if (curHealth <= 0)
        {
            if (dropCoin)
            {
                Instantiate(coinPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            Destroy(gameObject, .075f);
        }
    }
}
