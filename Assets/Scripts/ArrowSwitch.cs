using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSwitch : MonoBehaviour
{
    //이제 쓰지않는다.
    public bool isUp;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private void Start()
    {
        isUp = false;
        //GameManager.instance.SwitchArrowSprite();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
