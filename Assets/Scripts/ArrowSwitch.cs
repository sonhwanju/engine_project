using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSwitch : MonoBehaviour
{
    public bool isUp;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private void Start()
    {
        isUp = false;
        GameManager.instance.SwitchArrowSprite();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
