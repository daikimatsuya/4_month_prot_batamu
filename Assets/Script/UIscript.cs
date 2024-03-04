using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIscript : MonoBehaviour
{
    private GameManagerScript gameManager;
    [SerializeField] private TMP_Text hpViewer;
    private int playerHp;

    private void UICanvasController()
    {
        playerHp = gameManager.GetPlayerHp();
        ViewPlayerHp();
    }
    private void ViewPlayerHp()
    {
        hpViewer.SetText("hp:{0}",playerHp);
    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
       // hpViewer=GetComponent<TMP_Text>();
        hpViewer.SetText("test_text");
    }

    // Update is called once per frame
    void Update()
    {
        UICanvasController();
    }
}
