using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    [SerializeField] GameObject wind;
    [SerializeField] private GameObject canvas;
    [SerializeField] new RectTransform transform;
    private void BalloonController()
    {

    }
    private void Blake()
    {

    }
    private void Pank()
    {
        GameObject _ = Instantiate(wind, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        _.transform.SetParent(canvas.transform);
        _.transform.localScale = new Vector2(1, 1);

        Destroy(this.gameObject);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            Pank();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("Canvas");
        transform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        BalloonController();
    }
}
