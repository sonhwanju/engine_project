using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    public int hp = 5;

    public void OnDamage(int damage) {
        hp -= damage;

        if(hp <= 0) {
            Die();
        }
    }

    public void Die() {
        //죽었을때 해야할 것을 추가해야한다.
    }
}
