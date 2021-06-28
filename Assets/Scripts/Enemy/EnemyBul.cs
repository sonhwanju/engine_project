using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBul : MonoBehaviour
{
    //과거의 나는 왜 굳이 이 스크립트를 만들었을까
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
