using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTemp : MonoBehaviour
{
    public static PlatTemp instance;


    public float tiempoEspera = 0;
    private Rigidbody2D rb2D;
    public Vector3 posicionInicial;
    private bool destruido;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        if (destruido)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            StartCoroutine(Caida(collision));
        }

        if(collision.gameObject.CompareTag("Suelo")){
            gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.transform.position = new Vector3(posicionInicial.x, posicionInicial.y, posicionInicial.z);
            gameObject.SetActive(true);
        }
    }

    private IEnumerator Caida(Collision2D other){
        yield return new WaitForSeconds(tiempoEspera);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
