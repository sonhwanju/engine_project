using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float h, v;
    public bool isSpace;
    public bool isRun;

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        isSpace = Input.GetButtonDown("Jump");
        isRun = Input.GetKey(KeyCode.LeftShift);
    }
}
