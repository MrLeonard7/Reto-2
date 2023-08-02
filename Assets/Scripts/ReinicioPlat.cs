using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinicioPlat : MonoBehaviour
{
    public static ReinicioPlat instance;

    private void Awake() 
    {
        instance = this;
    }

    public void Reinicio()
    {
        StartCoroutine(ReinicioP());
    }

    IEnumerator ReinicioP()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            PlatTemp.instance.gameObject.SetActive(true);
        }
        
    }
}
