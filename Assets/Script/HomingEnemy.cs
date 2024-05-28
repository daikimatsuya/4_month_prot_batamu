using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    private RectTransform playerPos;
    private RectTransform pos;
    private Rigidbody2D rb;
    private GameManagerScript gm;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float homingLeng;
    [SerializeField] private float MaxLeng;

    private void HomingEnemyController()
    {
        Move();
    }
    private void Move()
    {
        Vector2 dis = new Vector2(((playerPos.position.x - pos.position.x)), ((playerPos.position.y - pos.position.y)));
        float disLeng = Mathf.Sqrt(dis.x * dis.x + dis.y * dis.y);

        if (disLeng > homingLeng)
        {
            if(disLeng > MaxLeng)
            {
                dis = math.normalize(dis);
                rb.velocity = new Vector2(dis.x * maxSpeed, dis.y * maxSpeed);
            }
            else
            {
                dis = math.normalize(dis);
                rb.velocity = new Vector2(dis.x * speed, dis.y * speed);
            }      
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GimmickEnemy")
        {
            gm.IncreaseTime();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gm=GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        playerPos=GameObject.FindWithTag("Player").GetComponent<RectTransform>();
        pos=GetComponent<RectTransform>();
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HomingEnemyController();
    }
}
