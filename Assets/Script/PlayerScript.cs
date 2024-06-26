using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public GameObject attack;
    [SerializeField] private GameObject bullet;
    private GameManagerScript gameManager;
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
    [SerializeField] private float reverseTimeOnBalloon;
    [SerializeField] private float attackDistance;
    [SerializeField] private int hp;
    [SerializeField] private float maxFallSpeed;
    [SerializeField] private float maxMoveSpeedX;
    [SerializeField] private float maxMoveSpeedY;
    [SerializeField] private float invincibleTime;
    [SerializeField] private float bouncePowerX;
    [SerializeField] private float bouncePowerY;
    [SerializeField] private float maxBounce;
    [SerializeField] private float bounceBlake;
    [SerializeField] private float pankStrength;
    [SerializeField] private Sprite open;
    [SerializeField] private Sprite normal;
    [SerializeField] private float cutFallSpeed;
    [SerializeField] private float bulletCoolTime;
    
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
    private Vector2 bounce;
    private bool isOpen;
    public UnityEngine.UI.Image image;
    private float bulletCooltime;

    private void PlayerController()
    {
        bulletCooltime--;
        Open();
        Jump();
        Move();
        ImageChange();
        ReverseCountDown();
        InvincibleCountDown();
        SpeedSave();
    }
    private void Move()
    {
        xMoveVector = 0;
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {          
            xMoveVector += xMovePower;
            if (!isOpen)
            {
                if (!isRight)
                {
                    Reverse();
                }
            }
        }
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {            
            xMoveVector += -xMovePower;
            if (!isOpen)
            {
                if (isRight)
                {
                    Reverse();
                }
            }
        }
        if (isOpen)
        {
            xMoveVector /= 1.25f;
            if(-maxMoveSpeedY/cutFallSpeed > rb.velocity.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, -maxMoveSpeedY/cutFallSpeed);
            }
        }
        if(reverseCount>0)
        {
            xMoveVector = 0;
        }
        rb.velocity = new Vector2(xMoveVector+reverseSpeedX, rb.velocity.y);
       
        rb.velocity = new Vector2(rb.velocity.x + bounce.x, rb.velocity.y + bounce.y);
        if (bounce.y != 0||bounce.x!=0)
        {
            BounceBlake();
        }


        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
    }
    private void SpeedSave()
    {
        if (rb.velocity.x > maxMoveSpeedX)
        {
            rb.velocity = new Vector2(maxMoveSpeedX, rb.velocity.y);
        }
        if (rb.velocity.x < -maxMoveSpeedX)
        {
            rb.velocity = new Vector2(-maxMoveSpeedX, rb.velocity.y);
        }
        if (rb.velocity.y > maxMoveSpeedY)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxMoveSpeedY);
        }
        if (rb.velocity.y < -maxMoveSpeedY)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxMoveSpeedY);
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
    private void Open()
    {
        isOpen = false;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.LeftShift))
        {
            isOpen = true;
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
                    Bullet();
                    ReverseCountReset(reverseTimeOnStep);
                    isRight = false;
                }
                //右を向く
                else
                {
                    Attack();
                    Bullet();
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
    private void Bullet()
    {
        if(bulletCooltime<=0)
        {
            bulletCooltime = bulletCoolTime * 60;
            GameObject _ = Instantiate(bullet, new Vector3(tf.position.x, tf.position.y, tf.position.z), Quaternion.identity);
            _.transform.SetParent(canvas.transform);
            _.transform.localScale = new Vector2(0.5f, 0.5f);
            if (isRight)
            {
                _.transform.localEulerAngles = new Vector2(0, 0);
            }
            else
            {
                _.transform.localEulerAngles = new Vector2(0, 180);
            }
        }
 
    }
    private void HitDamage()
    {
        isDamage = true;
        hp--;
        invincibleCount = (int)(invincibleTime*60);
        gameManager.SendPlayerHp(hp);
        if (hp <= 0)
        {

        }
    }
    //無敵時間処理
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
        if(isOpen)
        {
            image.sprite = open;
            if (isRight)
            {
                tf.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                tf.transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            image.sprite = normal;
            if (isRight)
            {
                tf.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                tf.transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
      

    }
    private void BounceCollision(Transform collision,float strength)
    {
        Vector2 vector = new Vector2(-(collision.position.x- tf.position.x), -(collision.position.y - tf.position.y));
        vector = vector.normalized;
        bounce = new Vector2((vector.x * (bouncePowerX*strength)), (vector.y * (bouncePowerY*strength)));
    }
    private void BounceBlake()
    {
        if(bounce.x > 0)
        {
            if(isOpen)
            {
                bounce.x -= bounceBlake*4;
            }
            else
            {
                 bounce.x-=bounceBlake;
            }
           
            if(bounce.x < 0)
            {
                bounce.x = 0;
            }
        }
        else if (bounce.x < 0)
        {
            if (isOpen)
            {
                bounce.x += bounceBlake * 4;
            }
            else
            {
                bounce.x += bounceBlake;
            }
            if (bounce.x > 0)
            {
                bounce.x = 0;
            }
        }
        if(bounce.y > 0)
        {
            bounce.y-=bounceBlake;
            if(bounce.y < 0)
            {
                bounce.y = 0;
            }
        }
        else if(bounce.y < 0)
        {
            bounce.y += bounceBlake;
            if(bounce.y > 0)
            {
                bounce.y = 0;
            }
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
                reverseSpeedX = 0;
            }
        }//接地判定
       
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        isCanJump = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            {
                ContactPoint2D[] contacts = collision.contacts;
                Vector2 otherNormal = contacts[0].normal;
                Vector2 upVector = new Vector2(0, 1);
                float dotUN = Vector2.Dot(upVector, otherNormal);
                float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
               
                    if(dotDeg <= 100)
                    {
                    if(dotDeg >= 45)
                    {
                        if (!isDamage)
                        {
                            HitDamage();
                        }
                    }
                        
                    }
                    
                
            }//接地判定
          
            
        }
        if (collision.gameObject.tag == "Spike")
        {
            if (!isDamage)
            {
                HitDamage();
            }

        }
        if (collision.gameObject.tag == "Balloon")
        {
            rb.velocity= Vector2.zero;  
            BounceCollision(collision.transform,1);
            reverseSpeedX = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HpItem")
        {
            if (hp < 3)
            {
                hp++;
                gameManager.SendPlayerHp(hp);
            }
            
        }
        if (collision.tag == "DeathBlock")
        {
            hp -= 999999999;
            HitDamage();
        }
        if(collision.tag == "BalloonWInd")
        {
            rb.velocity = Vector2.zero;
            BounceCollision(collision.transform,pankStrength);
        }
        if( collision.tag == "GimmickEnemy")
        {
            if(!isDamage)
            {
                HitDamage();
            }
        }
        if (collision.tag == "HomingEnemy")
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
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        image= GetComponent<UnityEngine.UI.Image>();    
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<RectTransform>();
        isRight = true;
        reverseSpeedX = 0;
        reverseCount = 0;
        isDamage = false;
        gameManager.SendPlayerHp(hp);
        bounce = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {     
        Physics2D.gravity = new Vector2(0, -9.8f * gravityPower);
        PlayerController();
    }
}
