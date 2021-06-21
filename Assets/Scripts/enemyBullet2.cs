using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet2 : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    public GameObject prefab;
    private float waitTime;
    private float startWaitTime = 1f;

    private void Start()
    {
        
        waitTime = startWaitTime;
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if(waitTime <= 0)
        {
            for (int i = -1; i < 2; i++)
            {
                //Vector2 targetPos = Enemy1.target.transform.position - transform.position;
                //float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
                Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, (15 * i)));
            }
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
    }
}
