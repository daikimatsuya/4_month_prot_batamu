using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private int playerHp;
    private void GameManagerController()
    {

    }
    public void SendPlayerHp(int hp)
    {
        playerHp = hp;
    }
    public int GetPlayerHP()
    {
        return playerHp;
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
