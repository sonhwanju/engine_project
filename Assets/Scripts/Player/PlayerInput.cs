using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float h, v;
    public bool isSpace;
    public bool isRun;
    public bool isFire;

    private void Update()
    {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            isSpace = Input.GetButtonDown("Jump");
            isFire = Input.GetButtonDown("Fire1");
            isRun = Input.GetKey(KeyCode.LeftShift);
    }
}
