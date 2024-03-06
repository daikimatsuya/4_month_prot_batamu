using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //１ステージ　チュートリアル
    //２ステージ　反転をうまく使うといいスコアになる
    //３ステージ　ボーナス　おふざけ　
    //４ステージ　アクションをうまく使ってクリアする　難度が一番高い
    private int playerHp;
    private int getItem;
    private bool isGoal;

    public void SendPlayerHp(int hp)
    {
        playerHp = hp;
    }
    //取得したアイテム数を加算
    public void ItemGet()
    {
        getItem++;
    }
    public void Goal()
    {
        isGoal = true;
    }
    public bool IsGoal()
    {
        return isGoal;
    }
    //アイテムの数を代入
    public int GetItem()
    {
        return getItem;
    }

    public int GetPlayerHp()
    {
        return playerHp;
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, false);
        isGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
