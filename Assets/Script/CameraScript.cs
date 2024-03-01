using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform tf;
    private RectTransform playerpos;
    public float cameraposDiff;

    private void CameraController()
    {
        Move();
    }

    private void Move()
    {
        tf.position = new Vector3(playerpos.position.x, tf.position.y, tf.position.z);

        //�c�ړ�
        {
            if (playerpos.position.y - tf.position.y > 7)
            {
                tf.position = new Vector3(tf.position.x, tf.position.y + 0.7f, tf.position.z);
            }
            else if (playerpos.position.y - tf.position.y > cameraposDiff + 2)
            {
                tf.position = new Vector3(tf.position.x, tf.position.y + 0.2f, tf.position.z);
            }
            else if (playerpos.position.y - tf.position.y > cameraposDiff)
            {
                tf.position = new Vector3(tf.position.x, tf.position.y + 0.04f, tf.position.z);
            }


            if (playerpos.position.y - tf.position.y < -7)
            {
                tf.position = new Vector3(tf.position.x, tf.position.y - 0.7f, tf.position.z);
            }
            else if (playerpos.position.y - tf.position.y < -cameraposDiff - 2)
            {
                tf.position = new Vector3(tf.position.x, tf.position.y - 0.2f, tf.position.z);
            }
            else if (playerpos.position.y - tf.position.y < -cameraposDiff)
            {
                tf.position = new Vector3(tf.position.x, tf.position.y - 0.04f, tf.position.z);
            }
        }
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