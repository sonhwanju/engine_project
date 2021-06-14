using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform targetTrm;
    public Transform targetTrm2;
    private BoxCollider2D[] doorBox;
    private bool isOpen = false;

    private void Awake()
    {
        doorBox = GetComponents<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //페이드인 아웃 넣어주기 해야함.
            if(!isOpen)
            {
                other.transform.position = targetTrm.position;
                for (int i = 0; i < doorBox.Length; i++)
                {
                    doorBox[i].enabled = false;
                }
            }
            else
            {
                other.transform.position = targetTrm2.position;
            }
            isOpen = !isOpen;
        }
    }

}
