using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed = 10f;

    private void Start()
    {
        Destroy(gameObject, 2f);
        //�ϴ� ��Ʈ���̷�
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
       // Enemy1.santanWait -= Time.deltaTime;
    }
}
