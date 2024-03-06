using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //�P�X�e�[�W�@�`���[�g���A��
    //�Q�X�e�[�W�@���]�����܂��g���Ƃ����X�R�A�ɂȂ�
    //�R�X�e�[�W�@�{�[�i�X�@���ӂ����@
    //�S�X�e�[�W�@�A�N�V���������܂��g���ăN���A����@��x����ԍ���
    private int playerHp;
    private int getItem;
    private bool isGoal;

    public void SendPlayerHp(int hp)
    {
        playerHp = hp;
    }
    //�擾�����A�C�e���������Z
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
    //�A�C�e���̐�����
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
