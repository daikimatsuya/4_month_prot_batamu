using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    [SerializeField] GameObject wind;
    [SerializeField] private GameObject canvas;
    [SerializeField] new RectTransform transform;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isPank;
    [SerializeField] private float pankPower;
    private void BalloonController()
    {
        Pank();
    }
    private void Blake()
    {

    }
    private void Pank()
    {
        if(isPank)
        {
            GameObject _ = Instantiate(wind, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            _.transform.SetParent(canvas.transform);
            _.transform.localScale = new Vector2(1, 1);

            Destroy(this.gameObject);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            isPank = true;
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            isPank = true;
        }
        if(collision.gameObject.tag == "PlayerBullet")
        {
            isPank = true;
        }
        if (collision.gameObject.tag == "DeathBlock")
        {
            isPank = true;
        }
        if(collision.gameObject.tag == "BalloonWInd")
        {
            Vector2 vector = new Vector2(-(collision.transform.position.x - this.gameObject.transform.position.x), -(collision.transform.position.y - this.gameObject.transform.position.y));
            vector = vector.normalized;
            rb.velocity = new Vector2(vector.x * pankPower, vector.y * pankPower);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("Canvas");
        transform = GetComponent<RectTransform>();
        rb=GetComponent<Rigidbody2D>();
        isPank = false;

    }

    // Update is called once per frame
    void Update()
    {
        BalloonController();
    }
}
