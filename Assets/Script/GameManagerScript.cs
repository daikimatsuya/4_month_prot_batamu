using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //　ステージのコンセプト
    //１ステージ　チュートリアル　移動と反転
    //２ステージ　反転をうまく使うといいスコアになる
    //３ステージ　チュートリアル　風船
    //４ステージ　風船をうまく使うとショートカットできる
    //５ステージ　

    [SerializeField] string stage1;
    [SerializeField] string stage2;
    [SerializeField] string stage3;
    [SerializeField] string stage4;
    [SerializeField] string stage5;

    private int playerHp;
    private int getItem;
    private bool isGoal;


    private void GameController()
    {
        ChangeStage();
    }
    private void ChangeStage()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(stage1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(stage2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(stage3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(stage4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene(stage5);
        }

    }
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
        GameController();
    }
}
