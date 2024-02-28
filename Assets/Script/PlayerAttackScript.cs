using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    PlayerScript playerScript;
    private float count;

    private void PlayerAttackController()
    {
        CountDown();
    }
    private void CountDown()
    {
        if(count < 0)
        {
            Death();
        }
        count--;
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        count = playerScript.GetAttackFreezeTime() * 60;
        count += 2;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAttackController();
    }
}
