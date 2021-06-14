using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField]
    private int hp = 100;

    private WaitForSeconds ws = new WaitForSeconds(1f);
    
    void Update()
    {
         
    }


    IEnumerator PhaseOne()
    {

        yield return ws;
    }
}
