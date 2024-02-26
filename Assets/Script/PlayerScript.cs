using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float xMovePower;
    public float jumpPower;
    public float gravityPower;
    public int reverseTime;


    private bool isRight;
    private bool onStep;
    private bool isCanJump;
    private float reverseCount;
    private void PlayerController()
    {
        Jump();
        Move();
    }
    private void Move()
    {
        float xMoveVector = 0;
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            Reverse();
            xMoveVector += xMovePower;
        }
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
            Reverse();
            xMoveVector += -xMovePower;
        }
        rb.velocity = new Vector2(xMoveVector, rb.velocity.y);
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
        if (reverseCount < 0)
        {
            if (isRight)
            {

                isRight = false;
            }
            else
            {

                isRight = true;
            }
        }
        if(reverseCount > 0)
        {
            reverseCount--;
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
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.gravity = new Vector2(0, -9.8f * gravityPower);
        PlayerController();
    }
}
