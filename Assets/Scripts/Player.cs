using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //[Header("이동 관련")]
    [SerializeField]
    private float speed = 5f;
    Rigidbody2D rigid;
    private float h, v;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Jump"))
        {
            GameManager.instance.SwitchArrowSprite();
        }
        Keys();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stair"))
        {
            //Debug.Log("ontrigger");
            GameManager.instance.StairChange();
        }
    }

    private void Keys()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5f;
        }
        else
        {
            speed = 3f;
        }
    }
}
