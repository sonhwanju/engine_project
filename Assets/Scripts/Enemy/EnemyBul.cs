using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBul : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direct = Vector2.right;
    
    void FixedUpdate()
    {

       
        transform.Translate(direct * speed * Time.fixedDeltaTime,Space.Self);
        
        
    }
    public void SetDir(Vector2 dir) {
        direct = dir;
    }
    
}
