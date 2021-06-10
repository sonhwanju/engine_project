using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("스위치 + 계단관련 변수들")]
    public ArrowSwitch[] arrow;
    public Transform[] stairTrm;
    public Transform playerTrm;
    public int stair;



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        stair = 2;
    }


    public void SwitchArrowSprite()
    {
        arrow[0].isUp = !arrow[0].isUp;
        for (int i = 0; i < arrow.Length; i++)
        {
            if (arrow[0].isUp)
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
        
        //올라갈수 있는 조건 : 1,2 층일때 내려갈수있는 조건 : 2,3층일때
        if(arrow[0].isUp && stair < 2)
        {
            stair++;
            playerTrm.position = stairTrm[stair].position;
        }

        if(!arrow[0].isUp && stair > 0)
        {
            stair--;
            playerTrm.position = stairTrm[stair].position;
        }
    }
}
