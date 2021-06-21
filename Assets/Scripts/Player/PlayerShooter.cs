using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    PlayerInput input;
    private WaitForSeconds ws = new WaitForSeconds(0.3f);

    public GameObject bulletPrefab;
    public Transform poolTrm;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        PoolManager.CreatePool<Bullet>(bulletPrefab,poolTrm,20);
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
                for(int i = -1; i < 2; i++) {
                    Bullet obj = PoolManager.GetItem<Bullet>();
                    obj.transform.position = transform.position + new Vector3(i * 0.3f,0,0);
                }

                input.isFire = false;
            }
            yield return ws;
        }
        
    }
}
