using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
        public int damage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Out")) {
            gameObject.SetActive(false);
        }

        IDamageable id = other.GetComponent<IDamageable>();
        if(id!= null) {
            id.OnDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
