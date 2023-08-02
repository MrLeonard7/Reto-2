using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chekpoint : MonoBehaviour
{
    //public  Animator anim;
    //private bool cpOn;
    public bool noInicio;

    void Start()
    {
        
    }

    void Update()
    {
        //anim.SetBool("CpOn", cpOn);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(noInicio){
                //AudioManager.instance.PlaySFX(8);
            }

            ChekpointController.instance.DeactivateCheckpoints();

            //cpOn = true;
            //anim.SetTrigger("Cp");

            ChekpointController.instance.SetSpawnPoint(transform.position);
        }
        
    }
    public void ResetCheckpoint()
    {
        //cpOn = false;
    }
}
