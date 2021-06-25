using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    public int hp = 10;
    public bool isHit = false;
    public bool isDead = false;
    private string s = "HitChange";
    private string hitAnim = "hit";
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnDamage(int damage) {
        if(isHit) return;
        
        isHit = true;
        hp -= damage;

        if(hp <= 0) {
            Die();
            return;
        }
        animator.Play(hitAnim);
        Invoke(s,2f);
    }

    public void Die() {
        //죽었을때 해야할 것을 추가해야한다.
        isDead = true;
    }

    public void HitChange() {
        isHit = false;
    }
}
