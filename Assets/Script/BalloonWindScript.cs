using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonWindScript : MonoBehaviour
{
    new RectTransform transform;

    [SerializeField] private float maxSize;
    [SerializeField] private float sizeUpSpeed;

    private void WindController()
    {
        SizeUp();
    }
    private void SizeUp()
    {
        if(transform.localScale.x < maxSize+transform.localScale.x)
        {
            transform.localScale = new Vector3(transform.localScale.x + sizeUpSpeed, transform.localScale.y + sizeUpSpeed, 1);
            if(transform.localScale.x > maxSize)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        WindController();
    }
}
