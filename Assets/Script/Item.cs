using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void ItemController()
    {

    }
    private void GetItem()
    {
        if (this.tag == "Item")
        {

        }
        if (this.tag == "GoalItem")
        {

        }
        if (this.tag == "HpItem")
        {
            //ÉvÉåÉCÉÑÅ[Ç≈èàóù
        }
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetItem();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
