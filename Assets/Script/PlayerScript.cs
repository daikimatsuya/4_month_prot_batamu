using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject attack;
    Rigidbody2D rb;
    RectTransform tf;
    private GameObject canvas;

    [SerializeField] private float xMovePower;
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravityPower;
    [SerializeField] private float reversePowerX;
    [SerializeField] private float reversePowerY;
    [SerializeField] private float reverseBlake;
    [SerializeField] private float reverseTimeOnStep;
    [SerializeField] private float reverseTimeInAir;
    [SerializeField] private float attackDistance;
    [SerializeField] private int hp;
    [SerializeField] private float maxFallSpeed;
    [SerializeField] private float invincibleTime;

    private bool isRight;
    private bool onStep;
    private bool isCanJump;
    private bool isReverse;
    private float xMoveVector;
    private float reverseSpeedX;
    private float reverseSpeedY;
    private int reverseCount;
    private bool isDamage;
    private int invincibleCount;
    
    private void PlayerController()
    {
        Jump();
        Move();
        ImageChange();
        ReverseCountDown();
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
        if(reverseCount>0)
        {
            xMoveVector = 0;
        }
        rb.velocity = new Vector2(xMoveVector+reverseSpeedX, rb.velocity.y);

        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
    }
    private void Jump()
    {
        if (isCanJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                isCanJump = false;
            }
            
        }
        }
    private void Reverse()
    {
        if (reverseCount <= 0)
        {
            if(isCanJump)
            {
                //左を向く
                if (isRight)
                {
                    Attack();
                    ReverseCountReset(reverseTimeOnStep);
                    isRight = false;
                }
                //右を向く
                else
                {
                    Attack();
                    ReverseCountReset(reverseTimeOnStep);
                    isRight = true;
                }
            }//接地
            if(!isCanJump)
            {
                //左に向く
                if (isRight)
                {
                    Attack();
                    ReverseReaction(-1);
                    ReverseCountReset(reverseTimeInAir);
                    isRight = false;
                }
                //右に向く
                else
                {
                    Attack();
                    ReverseReaction(1);
                    ReverseCountReset(reverseTimeInAir);
                    isRight = true;
                }
            }//空中
           
        }
      
    }
    private void Attack()
    {
        //左を向くときの攻撃
        if(isRight)
        {
            GameObject _ = Instantiate(attack, new Vector3(tf.position.x + attackDistance, tf.position.y, tf.position.z), Quaternion.identity);
            _.transform.SetParent(canvas.transform);
            _.transform.localEulerAngles = new Vector2(0, 180);
            _.transform.localScale = new Vector2(1, 1);
        }
        //右を向くときの攻撃
        else
        {
           GameObject _ = Instantiate(attack, new Vector3(tf.position.x - attackDistance, tf.position.y, tf.position.z), Quaternion.identity);
            _.transform.SetParent(canvas.transform);
            _.transform.localEulerAngles = new Vector2(0, 0);
            _.transform.localScale = new Vector2(1, 1);
        }

    }
    private void HitDamage()
    {
        isDamage = true;
        hp--;
        invincibleCount = (int)(invincibleTime*60);
        if (hp <= 0)
        {

        }
    }
    private void InvincibleCountDown()
    {
        if(invincibleCount<=0)
        {
            isDamage= false;
        }
        invincibleCount--;

    }
    private void ReverseCountDown()
    {
        if (reverseCount > 0)
        {
            reverseCount--;
        }
    }
    private void ReverseReaction(int direction)
    {
        reverseSpeedX = reversePowerX * direction;
        rb.velocity = new Vector2(rb.velocity.x, reversePowerY);

    }
    private void ReverseReactionBlake()
    {
        if(reverseSpeedX > 0)
        {
            reverseSpeedX -= reverseBlake;
            if(reverseSpeedX < 0)
            {
                reverseSpeedX = 0;
            }
        }
        if(reverseSpeedX < 0)
        {
            reverseSpeedX += reverseBlake;
            if(reverseSpeedX > 0)
            {
                reverseSpeedX = 0;
            }
        }
    }
    private void ReverseCountReset(float time)
    {
        reverseCount = (int)(time * 60);
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
    public float GetAttackFreezeTime()
    {
        return reverseTimeOnStep;
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
        }//接地判定
        reverseSpeedX = 0;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        isCanJump = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!isDamage)
            {
                HitDamage();
            }
            
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            if (!isDamage)
            {
               HitDamage();               
            }
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("Canvas");
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<RectTransform>();
        isRight = true;
        reverseSpeedX = 0;
        reverseCount = 0;
        isDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        Physics2D.gravity = new Vector2(0, -9.8f * gravityPower);
        PlayerController();
    }
}
