using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    public Rigidbody2D rigid;
    PlayerInput input;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Keys();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(input.h, input.v) * speed;
    }
    private void Keys()
    {
        if (input.isRun)
        {
            speed = 7f;
        }
        else
        {
            speed = 5f;
        }
    }
}
