using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header ("Movimiento")]
    public float moveSpeed;
    private Quaternion characterRotation;

    [Header ("Salto")]
    public float jumpForce;
    private int jumpsReaming;
    public int maxJumps = 2;
    public float bounceForce;
    
    [Header("Componentes")]
    public Rigidbody2D rb;

    [Header ("Animator")]
    //public Animator anim;
    private SpriteRenderer sR;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask ground;

    private Transform platform;
    private Vector3 platPosition;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private void Awake()     
    {
        instance = this;
    }

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(knockBackCounter <= 0)
        {
            rb.velocity = new Vector2 (moveSpeed * Input.GetAxis("Horizontal")
            , rb.velocity.y);

            bool isWalking = Mathf.Abs(rb.velocity.x)> 0.1f;
            
            isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, ground);

            if (isGrounded)
            {
                jumpsReaming = maxJumps;
            }

            if (jumpsReaming > 0 && Input.GetButtonDown("Jump"))
            {
                //AudioManager.instance.PlaySFX(0);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                jumpsReaming--;
            }    
               

            if (rb.velocity.x < 0)
            {
                sR.flipX = true;
            }
            else if (rb.velocity.x > 0)
            {
                sR.flipX = false;
            }

        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if(!sR.flipX)
            {
                rb.velocity = new Vector2(-knockBackForce, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(knockBackForce, rb.velocity.y);

            }
        }
        
        

        
        //anim.SetFloat("seMueve", Mathf.Abs(rb.velocity.x));
        //anim.SetBool("enSuelo", isGrounded);
        
        
    }
    
    public void Knockback()
    {
        knockBackCounter =  knockBackLength;
        rb.velocity = new Vector2(0f, knockBackForce);

    }
    public void Bounce()
        {
            rb.velocity = new Vector2(rb.velocity.x, bounceForce);
        }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            platform = other.transform;
            
            transform.SetParent(platform);
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.transform == platform)
        {
            platform = null;
            transform.SetParent(null);
            
        }
        
    }
}