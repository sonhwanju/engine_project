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
    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (GameManager.instance.floor == Floor.THREE)
        {
            if(input.isFireDown)
            {
                for(int i = -1; i < 2; i++) {
                    Bullet obj = PoolManager.GetItem<Bullet>();
                    obj.transform.position = transform.position + new Vector3(i * 0.3f,0,0);
                }
                input.isFire = false;
            }
            yield return null;
        }
        yield break;
    }
}
