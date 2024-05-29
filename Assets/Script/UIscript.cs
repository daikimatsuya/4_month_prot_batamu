using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIscript : MonoBehaviour
{
    private GameManagerScript gameManager;
    [SerializeField] private TMP_Text hpViewer;
    [SerializeField] private TMP_Text getItem;
    [SerializeField] private TMP_Text goal;
    [SerializeField] private TMP_Text time;
    private int itemCount;
    private int playerHp;
    private int leftTime;

    private void UICanvasController()
    {
        playerHp = gameManager.GetPlayerHp();
        itemCount = gameManager.GetItem();
        leftTime=gameManager.GetTime();


        ViewItemCount();
        ViewPlayerHp();
        ViewIsGoal();
        ViewTime();
    }
    private void ViewPlayerHp()
    {
        hpViewer.SetText("hp:{0}",playerHp);
    }
    private void ViewItemCount()
    {
        getItem.SetText("Item:{}", itemCount);
    }
    private void ViewIsGoal()
    {
        if (gameManager.IsGoal())
        {
            goal.SetText("GOAL");
        }

    }
    private void ViewTime()
    {
        time.SetText("time:{0}", leftTime/60);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
       // hpViewer=GetComponent<TMP_Text>();
        hpViewer.SetText("test_text");
        getItem.SetText("test_text");
        goal.SetText("not_goal");
    }

    // Update is called once per frame
    void Update()
    {
        UICanvasController();
    }
}
