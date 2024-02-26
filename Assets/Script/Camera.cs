using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform tf;
    private RectTransform playerpos;

    private void CameraController()
    {
        Move();
    }
    private void Move()
    {
        tf.position = new Vector3(playerpos.position.x, tf.position.y, tf.position.z);
    }
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        playerpos = GameObject.FindWithTag("Player").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraController();
    }
}
