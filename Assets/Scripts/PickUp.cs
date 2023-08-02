using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public static PickUp instance;
    public bool isApple, isHeal;



    private bool isCollected;

    //public GameObject pickupEffect;
    
    private void Awake() {
        instance = this;
    }    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")&& !isCollected)
        {
            if (isApple)
            {
                LevelManager.instance.applesCollected++;

                UIController.instance.UpdateAppleCount();

                //Instantiate(pickupEffect, transform.position, transform.rotation);

                //AudioManager.instance.PlaySFX(2);

                isCollected = true;
                Destroy(gameObject);
            }
            if (isHeal)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {

                    //AudioManager.instance.PlaySFX(3);

                    PlayerHealthController.instance.HealPlayer();
                    isCollected = true;

                    Destroy(gameObject);
                }
            }
        }    
    }
}
