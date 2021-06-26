using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    PlayerInput input;
    private WaitForSeconds ws = new WaitForSeconds(0.3f);

    public GameObject bulletPrefab;
    public Transform poolTrm;
    public AudioSource audioSource;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        PoolManager.CreatePool<Bullet>(bulletPrefab,poolTrm,20);
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (SaveManager.instance.save.floor == Floor.THREE)
        {
            if(input.isFireDown)
            {
                audioSource.Play();
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
