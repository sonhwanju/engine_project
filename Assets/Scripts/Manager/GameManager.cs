using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Floor
{
    THREE,
    TWO,
    ONE
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("스위치 + 계단관련 변수들")]
    public ArrowSwitch[] arrow;
    public Transform[] stairTrm;
    public Transform playerTrm;
    public int stair;
    public Floor floor = Floor.THREE;
    public bool isBossClear = false;

    public GameObject boss;
    public GameObject bossBar;

    public bool isFade = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        stair = 2;
    }
    public void BossSpawn()
    {
        Screen.SetResolution(1080, 1920, true);
        boss.SetActive(true);
        bossBar.SetActive(true);
    }


    public void SwitchArrowSprite()
    {
        arrow[0].isUp = !arrow[0].isUp;
        for (int i = 0; i < arrow.Length; i++)
        {
            if (!arrow[0].isUp)
            {
                arrow[i].spriteRenderer.sprite = arrow[i].sprites[0];
            }
            else
            {
                arrow[i].spriteRenderer.sprite = arrow[i].sprites[1];
            }
        }
    }
    public void StairChange()
    {

        // if(arrow[0].isUp)
        // {
        //     if(floor == Floor.ONE)
        //     {
        //         stair = 1;
        //         floor = Floor.TWO;
        //     }
        //     else if(floor == Floor.TWO)
        //     {
        //         stair = 2;
        //         floor = Floor.THREE;
        //     }
            
        // }
        // else
        // {
        //     if(floor == Floor.THREE)
        //     {
        //         stair = 1;
        //         floor = Floor.TWO;
        //     }
        //     else if(floor == Floor.TWO)
        //     {
        //         stair = 0;
        //         floor = Floor.ONE;
        //     }
        // }
        // playerTrm.position = stairTrm[stair].position;

        if(arrow[0].isUp && stair < 2)
        {
           stair++;
           floor++;
           playerTrm.position = stairTrm[stair].position;
        }

        if(!arrow[0].isUp && stair > 0)
        {
           stair--;
           floor--;
           playerTrm.position = stairTrm[stair].position;
        }
    }
}
