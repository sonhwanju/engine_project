using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Vector2 radius;
    void Start()
    {
        radius = new Vector2(12f, 5f);
    }

    void Update()
    {
         //Physics2D.OverlapBox(transform.position, radius,0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, radius);
    }
}
