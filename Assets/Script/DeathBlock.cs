using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlock : MonoBehaviour
{
    [SerializeField] bool isMoveLeft;
    [SerializeField] bool isMoveRight;
    [SerializeField] bool isMoveUp;
    [SerializeField] bool isMoveDown;
    [SerializeField] float moveSpeed;

    private Rigidbody2D rb;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move=Vector2.zero;
        
        if (isMoveDown)
        {
            move.y = -moveSpeed;
        }
        if(isMoveLeft)
        {
            move.x = -moveSpeed;
        }
        if(isMoveRight)
        {
            move.x = moveSpeed;
        }
        if (isMoveUp)
        {
            move.y = moveSpeed;
        }

        rb.velocity = move;
    }
}
