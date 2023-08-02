using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform farBG, middleBG;

    public float minH, maxH;

    private Vector2 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y + 2, minH, maxH)
        ,transform.position.z);
            
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x
        , transform.position.y - lastPos.y);

        farBG.position = farBG.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBG.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

        lastPos = transform.position;
    }
}
