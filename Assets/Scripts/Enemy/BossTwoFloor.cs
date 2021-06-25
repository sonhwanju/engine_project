using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwoFloor : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public Transform targetTrm;
    private Vector2 myTrm;
    private WaitForSeconds ws = new WaitForSeconds(2f);
    private WaitForSeconds w = new WaitForSeconds(1f);


    void Start()
    {
        myTrm = transform.position;
    }

    IEnumerator Move() {
        while(true) {
            Vector2.Lerp(transform.position,targetTrm.position, 0.5f);
            yield return w;
            //여기에 플레이어 감지 추가하기
            Collider2D col = Physics2D.OverlapCircle(transform.position, 10f, whatIsPlayer);
            if(col.GetComponent<PlayerSleep>().isSleep) {
                col.GetComponent<PlayerHealth>().OnDamage(1);
            }
            
            yield return ws;
            Vector2.Lerp(transform.position, myTrm, 0.5f);
        }
    }
}
