using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door3 : Door
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            if(!GameManager.instance.isOpen)
            {
                GameManager.instance.isFade = true;
                //for (int i = 0; i < doorBox.Length; i++)
                //{
                    doorBox[0].enabled = false;
                //}
                fadeImg.DOFade(1, 2).OnComplete(() =>
                {
                    other.transform.position = targetTrm.position;
                    fadeImg.DOFade(0, 2).OnComplete(() =>
                     {
                        GameManager.instance.InitThreeFloor(true);
                        GameManager.instance.isFade = false;
                     });
                });
                
            }
            else
            {
                GameManager.instance.isFade = true;
                fadeImg.DOFade(1,2).OnComplete(()=> {
                    //for (int i = 0; i < doorBox.Length; i++)
                    //{
                        doorBox[0].enabled = false;
                    //}
                    other.transform.position = targetTrm2.position;
                    fadeImg.DOFade(0,2).OnComplete(()=>{
                        GameManager.instance.InitThreeFloor(false);
                        GameManager.instance.isFade = false;
                    });
                }); 
            }
            GameManager.instance.isOpen = !GameManager.instance.isOpen;
        }
    }
}
