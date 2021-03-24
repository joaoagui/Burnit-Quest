using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public bool horizontalMove;
    public bool verticalMove;
    public bool circularMove;

    public bool movingLeft;
    public bool movingDown;

    public float maxWidth;
    public float maxHeight;

    //for circular movement
    public float circleRad = 1f;
    private Vector2 fixedPoint;
    private float currentAngle;

    public float delayTimer;

    public float speed;

    private float initialX;
    private float initialY;

    public float OffsetStartX;
    public float OffsetStartY;

    public void Start()
    {
        fixedPoint = transform.position;

        initialX = gameObject.transform.position.x;
        initialY = gameObject.transform.position.y;

        transform.Translate(Vector2.right * OffsetStartX);
        transform.Translate(Vector2.up * OffsetStartY);

        if(verticalMove == true && movingDown == true && delayTimer < 0)
        {
            transform.Translate(Vector2.up * maxHeight);
        }
        if (horizontalMove == true && movingLeft == true && delayTimer < 0)
        {
            transform.Translate(Vector2.left * maxHeight);
        }
    }

    void Update()
    {
        delayTimer -= Time.deltaTime;

        if (horizontalMove == true)
        {
            if(movingLeft == false && delayTimer < 0)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else if (movingLeft == true && delayTimer < 0)
            {
                transform.Translate(Vector2.right * -speed * Time.deltaTime);
            }
            //switch direction
            if (movingLeft == false && gameObject.transform.position.x >= (initialX + maxWidth))
            {
                movingLeft = true;

            }
            if (movingLeft == true && gameObject.transform.position.x <= initialX)
            {
                movingLeft = false;
            }
        }

        if (verticalMove == true)

        {
            if (movingDown == false && delayTimer < 0)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }

            else if (movingDown == true && delayTimer < 0)
            {
                transform.Translate(Vector2.up * - speed * Time.deltaTime);
            }

            //switch direction

            if (movingDown == false && gameObject.transform.position.y >= (initialY + maxHeight) && delayTimer < 0)
            {
                movingDown = true;

            }
            if (movingDown == true && gameObject.transform.position.y <= initialY && delayTimer < 0)
            {
                movingDown = false;
            }
        }

        if (circularMove == true && delayTimer < 0)
        {
            currentAngle += speed * Time.deltaTime;
            Vector2 offset = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * circleRad;
            transform.position = fixedPoint + offset;
        }

    }
}
