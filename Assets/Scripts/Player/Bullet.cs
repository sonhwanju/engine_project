using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 20f;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.fixedDeltaTime);
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.CompareTag("Out")) {
    //         gameObject.SetActive(false);
    //     }

    //     IDamageable id = other.GetComponent<IDamageable>();
    //     if(id!= null) {
    //         id.OnDamage(damage);
    //         gameObject.SetActive(false);
    //     }
    // }
}
