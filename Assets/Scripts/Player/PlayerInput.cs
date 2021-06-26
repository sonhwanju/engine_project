using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float h, v;
    public bool isSpace;
    public bool isRun;
    public bool isFireDown;
    public bool isFireUp;
    public bool isFire;

    private void Update()
    {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            isSpace = Input.GetButtonDown("Jump");
            isFireDown = Input.GetButtonDown("Fire1");
            isFireUp = Input.GetButtonUp("Fire1");
            isFire = Input.GetButton("Fire1");
            isRun = Input.GetKey(KeyCode.LeftShift);
    }
}
