using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //�@�X�e�[�W�̃R���Z�v�g
    //�P�X�e�[�W�@�`���[�g���A���@�ړ��Ɣ��]
    //�Q�X�e�[�W�@���]�����܂��g���Ƃ����X�R�A�ɂȂ�
    //�R�X�e�[�W�@�`���[�g���A���@���D
    //�S�X�e�[�W�@���D�����܂��g���ƃV���[�g�J�b�g�ł���
    //�T�X�e�[�W�@�P�`�S�܂ł̗v�f�ŃA�X���`�b�N

    [SerializeField] string stage1;
    [SerializeField] string stage2;
    [SerializeField] string stage3;
    [SerializeField] string stage4;
    [SerializeField] string stage5;
    [SerializeField] string stage6;
    [SerializeField] string stage7;
    [SerializeField] string stage8;
    [SerializeField] string stage9;
    [SerializeField] string stage10;

    [SerializeField] float time;
    [SerializeField] int increaseTime;

    private int playerHp;
    private int getItem;
    private bool isGoal;


    private void GameController()
    {
        ChangeStage();
        CountDown();
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
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene(stage6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene(stage7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SceneManager.LoadScene(stage8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SceneManager.LoadScene(stage9);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(stage10);
        }
    }
    private void CountDown()
    {
        if(!isGoal)
        {
            time--;
        }        
    }
    public void IncreaseTime()
    {
        time += increaseTime;
    }
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
    public int GetTime()
    {
        return (int)time;
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, false);
        isGoal = false;
        time = time * 60;
    }

    // Update is called once per frame
    void Update()
    {
        GameController();
    }
}
