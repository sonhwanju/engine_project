using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("����ġ + ��ܰ��� ������")]
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
        
        //�ö󰥼� �ִ� ���� : 1,2 ���϶� ���������ִ� ���� : 2,3���϶�
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
