using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float surviveTime;
    [SerializeField] float moveSpeed;

    private Rigidbody2D rb;
    private RectTransform tf;
    private void PlayerBulletController()
    {
        Move();
        countDown();
    }
    private void Move()
    {
        Vector2 move=Vector2.zero;
        move.x=moveSpeed* (float)math.cos(ToRadian(tf.transform.localEulerAngles.y));
        rb.velocity = move;
    }
    private void countDown()
    {
        surviveTime--;
        if( surviveTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private double ToRadian(double angle)
    {
        return angle * Math.PI / 180f;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        tf=GetComponent<RectTransform>();

        surviveTime = surviveTime * 60;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBulletController();
    }
}
