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
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Out")) {
            gameObject.SetActive(false);
            Debug.Log("충돌");
        }
    }
}
