using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    RectTransform tf;

    public float xMovePower;
    public float jumpPower;
    public float gravityPower;
    public float reverseTime;


    private bool isRight;
    private bool onStep;
    private bool isCanJump;
    private bool isReverse;
    private float xMoveVector;
    private float reverseSpeed;
    private int reverseCount;
    private void PlayerController()
    {
        Jump();
        Move();
        ImageChange();
    }
    private void Move()
    {
        xMoveVector = 0;
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {          
            xMoveVector += xMovePower;
            if (!isRight)
            {
                Reverse();
            }           
        }
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {            
            xMoveVector += -xMovePower;
            if (isRight)
            {
                Reverse();
            }
        }
        rb.velocity = new Vector2(xMoveVector+reverseSpeed, rb.velocity.y);
    }
    private void Jump()
    {
        if (isCanJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            isCanJump = false;
        }
        }
    private void Reverse()
    {
        if (reverseCount <= 0)
        {
            if (isRight)
            {
                ReverseCountReset();
                isRight = false;
            }
            else
            {
                ReverseCountReset();
                isRight = true;
            }
        }
        if(reverseCount > 0)
        {
            reverseCount--;
        }
    }
    private void ReverseCountReset()
    {
        reverseCount = (int)(reverseTime * 60);
    }
    private void ImageChange()
    {
        if(isRight)
        {
            tf.transform.eulerAngles = new Vector3(0, 0,0);
        }
        else
        {
            tf.transform.eulerAngles = new Vector3(0, 180, 0); 
        }

    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        {
            ContactPoint2D[] contacts = collision.contacts;
            Vector2 otherNormal = contacts[0].normal;
            Vector2 upVector = new Vector2(0, 1);
            float dotUN = Vector2.Dot(upVector, otherNormal);
            float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
            if (dotDeg <= 45)
            {
                isCanJump=true;
            }
        }//Ú’n”»’è
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<RectTransform>();
        isRight = true;
        reverseSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.gravity = new Vector2(0, -9.8f * gravityPower);
        PlayerController();
    }
}
