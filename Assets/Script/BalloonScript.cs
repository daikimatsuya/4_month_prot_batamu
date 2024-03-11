using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    [SerializeField] GameObject wind;
    [SerializeField] private GameObject canvas;
    [SerializeField] new RectTransform transform;
    [SerializeField] private bool isPank;
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
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("Canvas");
        transform = GetComponent<RectTransform>();
        isPank = false;
    }

    // Update is called once per frame
    void Update()
    {
        BalloonController();
    }
}
