using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public Transform targetTrm;
    public Transform targetTrm2;
    public BoxCollider2D[] doorBox;
    //public GameObject colObj;
    //private bool isCheck = false;

    public float fadeTime = 2f;
    public Image fadeImg;

    private void Awake()
    {
        doorBox = GetComponents<BoxCollider2D>();
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //
            if(!GameManager.instance.isOpen)
            {
                GameManager.instance.isFade = true;
                for (int i = 0; i < doorBox.Length; i++)
                {
                    doorBox[i].enabled = false;
                }
                fadeImg.DOFade(1, 2).OnComplete(() =>
                {
                    other.transform.position = targetTrm.position;
                    fadeImg.DOFade(0, 2).OnComplete(() =>
                     {
                         GameManager.instance.BossSpawn(true);
                        //  colObj.SetActive(true);
                        //  colObj.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
                         GameManager.instance.ActiveCircle(GameManager.instance.isOpen);
                         
                         GameManager.instance.isFade = false;
                     });
                });
                
            }
            else
            {
                GameManager.instance.isFade = true;
                fadeImg.DOFade(1,2).OnComplete(()=> {
                    for (int i = 0; i < doorBox.Length; i++)
                    {
                        doorBox[i].enabled = false;
                    }
                    other.transform.position = targetTrm2.position;
                    fadeImg.DOFade(0,2).OnComplete(()=>{
                        GameManager.instance.ActiveCircle(GameManager.instance.isOpen);
                        GameManager.instance.isFade = false;
                    });
                }); 
            }
            GameManager.instance.isOpen = !GameManager.instance.isOpen;
        }
    }

}
