using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 20f;

    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if(col.gameObject.CompareTag("Out"))
    //    {
    //        BulletPool.instance.InsertQueue(gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Out"))
        {
            BulletPool.instance.InsertQueue(gameObject);
        }
    }
}
