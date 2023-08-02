using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;


    public int currentHealth, maxHealth;

    public float invincibleLength;
    public float invincibleCounter;

    private SpriteRenderer sR;

    public GameObject deathEffect;


    private void Awake()
    {
        instance = this;        
    }

    void Start()
    {
        currentHealth = maxHealth;

        sR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter <= 0)
            {
                sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 1f);
            }
        }
    }
    public void DealDamage()
    {
        currentHealth--;
        //PlayerController.instance.anim.SetTrigger("Hurt");  

        if (currentHealth <= 0)
        {
            //Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);

            //AudioManager.instance.PlaySFX(5);

            LevelManager.instance.RespawnPlayer();
        }
        else
        {
            invincibleCounter = invincibleLength;
            sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, .5f);

            PlayerController.instance.Knockback();
        }

        UIController.instance.UpdateHealthDisplay();   
    }

    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }
}
