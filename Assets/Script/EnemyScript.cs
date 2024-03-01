using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;

    public int hp;
    public float moveSpeed;
    
    private void EnemyController()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
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
        {
            ContactPoint2D[] contacts = collision.contacts;
            Vector2 otherNormal = contacts[0].normal;
            Vector2 upVector = new Vector2(0, 1);
            float dotUN = Vector2.Dot(upVector, otherNormal);
            float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
            if (dotDeg >= 45)
            {
                moveSpeed *= -1;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            HitDamage();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();    

    }

    // Update is called once per frame
    void Update()
    {
        EnemyController();
    }
}
