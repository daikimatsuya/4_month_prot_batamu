using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickEnemy : MonoBehaviour
{
    Transform ps;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveLenge;
    [SerializeField] private bool moveY;
    [SerializeField] private bool moveRe;

    private Vector2 pos;
    private void GimmickEnemyController()
    {
        Move();
    }
    private void Move()
    {
        if(moveY)
        {
            ps.position = new Vector3(ps.position.x, ps.position.y + moveSpeed, ps.position.z);
        }
        else
        {
            ps.position = new Vector3(ps.position.x + moveSpeed, ps.position.y, ps.position.z);
        }
        if((pos.x - ps.position.x)*(pos.x - ps.position.x) > moveLenge*moveLenge)
        {
            moveSpeed *= -1;
        }
        if((pos.y - ps.position.y)*(pos.y - ps.position.y) > moveLenge * moveLenge)
        {
            moveSpeed *= -1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<Transform>();
        pos = ps.position;
        if(moveRe)
        {
            moveSpeed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GimmickEnemyController();
    }
}
