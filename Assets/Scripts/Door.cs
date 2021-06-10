using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isTp = false;

    public Transform[] ptTrm = new Transform[2];

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //할일작성
            if(isTp)
            {
                transform.position = ptTrm[0].position;


                isTp = false;
            }
            else
            {
                transform.position = ptTrm[1].position;
                isTp = true;
            }
        }
    }
}
