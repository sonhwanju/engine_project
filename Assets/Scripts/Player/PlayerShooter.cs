using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    PlayerInput input;
    private WaitForSeconds ws = new WaitForSeconds(0.3f);

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            if(input.isFire && GameManager.instance.floor == Floor.THREE)
            {
                GameObject obj = BulletPool.instance.GetQueue();
                //Debug.Log("น฿ป็");
                input.isFire = false;
            }
            yield return ws;
        }
        
    }
}
