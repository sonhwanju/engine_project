using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            if(SaveManager.instance.save.checkList[2]) {
                //클리어
            }
        }
    }
}
