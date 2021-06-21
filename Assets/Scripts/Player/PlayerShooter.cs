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
        PoolManager.CreatePool<Bullet>(bulletPrefab,transform,20);
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
                Bullet obj = PoolManager.GetItem<Bullet>();
                //  obj.transform.position = transform.position;
                input.isFire = false;
            }
            yield return ws;
        }
        
    }
}
