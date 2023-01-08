using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHealth;
    public int curHealth;

    public float invinvibleLenght = 1.5f;
    private float invincibleCounter;

    public Animator anim;

    public GameObject damageParticle;
    public Transform instantiateTransform;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer()
    {
        if (invincibleCounter <= 0)
        {
            if (curHealth > 0)
            {
                curHealth--;
                anim.SetTrigger("Damage");
            }
            else if (curHealth <= 0)
            {
                curHealth = 0;
            }

            if (curHealth == 0)
            {
                anim.SetTrigger("Death");
                GameManager.instance.Respawn();
            }

            if (curHealth >= 1)
            {
                PlayerController.instance.Knockback();
                invincibleCounter = invinvibleLenght;
            }

            Instantiate(damageParticle, instantiateTransform.position, Quaternion.identity, transform);
        }
    }

    public void ResetHealth()
    {
        curHealth = maxHealth;
    }
}
