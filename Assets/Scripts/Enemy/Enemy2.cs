using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int speed = 10;
    private Vector2 direct = Vector2.right;

    void Start()
    {
        Invoke("Active",5f);
    }
    void FixedUpdate()
    {
        transform.Translate(direct * speed * Time.fixedDeltaTime,Space.Self);
    }
    public void SetDir(int check)
    {
        if((check + 1) % 3 == 0) { //3 6
            direct  =Vector2.right;
        }
        else if((check + 1) % 3 == 1) { // 1 4
            direct = Vector2.up;
        }
        else {
            direct = Vector2.left;
        }
    }

    public void Active() {
        gameObject.SetActive(false);
    }
}
