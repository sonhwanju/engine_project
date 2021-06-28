using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject clearPanel;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            if(SaveManager.instance.save.checkList[2]) {
                //클리어
                Time.timeScale = 0;
                clearPanel.SetActive(true);
            }
        }
    }
}
