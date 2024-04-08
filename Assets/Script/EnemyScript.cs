using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField] private int hp;
    [SerializeField] private float moveSpeed;
    //public Camera cam;
    private const string cam="MainCamera";

    private bool canMove;

    private void EnemyController()
    {
        Move();

    }
    private void Move()
    {
        if (canMove)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
        }
    }
   
    private void HitDamage()
    {
        hp--;
        if(hp <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //壁判定チェック
        {
            ContactPoint2D[] contacts = collision.contacts;
            Vector2 otherNormal = contacts[0].normal;
            Vector2 upVector = new Vector2(0, 1);
            float dotUN = Vector2.Dot(upVector, otherNormal);
            float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
            if (dotDeg >= 45)
            {
                if (dotDeg <= 100)
                {
                    if (dotDeg >= 45)
                    {
                        moveSpeed *= -1;
                    }

                }
               
            }
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
           // HitDamage();
        }
        if(collision.tag == "DeathBlock")
        {
            hp -= 999999999;
            HitDamage();
        }
    }

    
    private void OnWillRenderObject()
    {
        if (!canMove)
        {
            //カメラに映ったら動く
            if (Camera.current.tag == "MainCamera")
            {
                canMove = true;
            }
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        //cam=GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyController();
    }


}
