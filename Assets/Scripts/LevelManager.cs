using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public int applesCollected;

    public float waitEffect;
    public GameObject respawnEffect;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());

    }

    IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed)+ .2f);

        UIController.instance.FadeFromBlack();

        PlayerController.instance.transform.position = new Vector3(ChekpointController.instance.spawnPoint.x ,ChekpointController.instance.spawnPoint.y -1.5f, ChekpointController.instance.spawnPoint.z);

        //Instantiate(respawnEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);

        //AudioManager.instance.PlaySFX(6);

        yield return new WaitForSeconds(waitEffect);
        
        PlayerController.instance.gameObject.SetActive(true);

        PlayerHealthController.instance.currentHealth =  PlayerHealthController.instance.maxHealth;

        UIController.instance.UpdateHealthDisplay();

    }
}
