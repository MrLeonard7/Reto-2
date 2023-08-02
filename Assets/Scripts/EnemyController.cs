using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public  Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D rB;
    public SpriteRenderer sR;

    public  float moveTime, waitTime;
    private float moveCount, waitCount;

    private Animator anim;



   void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    void Update()
    {
        if(moveCount > 0)
        {
            moveCount -= Time.deltaTime;


            if(movingRight)
            {
                rB.velocity = new Vector2(moveSpeed, rB.velocity.y);

                sR.flipX = true;


                if(transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;

                }
            } else
            {
                rB.velocity = new Vector2(-moveSpeed, rB.velocity.y);

                sR.flipX = false;


                if(transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;

                }
            }

            if(moveCount<= 0)
            {
                waitCount = Random.Range(waitTime * .75F, waitTime * 1.25f );
            }

            anim.SetBool("isMoving",true);
        }else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            rB.velocity = new Vector2(0f, rB.velocity.y);

            if(waitCount<= 0)
            {
                moveCount = Random.Range(moveTime * .75F, waitTime * 1.25f );
            }
            anim.SetBool("isMoving",false);
        }
    }
}
