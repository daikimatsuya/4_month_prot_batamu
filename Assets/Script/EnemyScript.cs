using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp;
    private void EnemyController()
    {

    }
    private void HitDamage()
    {
        hp--;
        if(hp <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            HitDamage();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyController();
    }
}
