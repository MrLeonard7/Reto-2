using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header ("Movimiento")]
    public float moveSpeed;

    [Header ("Salto")]
    public float jumpForce;
    private bool doubleJump;
    
    [Header("Componentes")]
    public Rigidbody2D rb;

    [Header ("Animator")]
    public Animator anim;
    private SpriteRenderer sR;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask ground; 

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

            isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, ground); 

            if (isGrounded)
            {
                doubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
            
                if(isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
                else
                {
                    if(doubleJump)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        doubleJump = false;
                    }
                }
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

        
        anim.SetFloat("seMueve", Mathf.Abs(rb.velocity.x));
        anim.SetBool("enSuelo", isGrounded);
        
    }
    
    public void Knockback()
    {
        knockBackCounter =  knockBackLength;
        rb.velocity = new Vector2(0f, knockBackForce);

    }
}