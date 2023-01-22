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

    public bool canDamage;

    public int damageSFX;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResetHealth();

        canDamage = true;
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
        if (invincibleCounter <= 0 && canDamage == true)
        {
            if (curHealth > 0)
            {
                curHealth--;
                anim.SetTrigger("Damage");

                AudioManager.instance.PlaySFX(damageSFX);
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

        UpdateUI();
    }

    public void ResetHealth()
    {
        curHealth = maxHealth;

        UpdateUI();
    }

    public void AddHealth(int healAmount)
    {
        curHealth += healAmount;
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        UICanvas.instance.healthText.text = curHealth.ToString();
    }
}
