using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSleep : MonoBehaviour
{
    public bool isSleep = false;
    private PlayerInput input;
    void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(SaveManager.instance.save.floor == Floor.TWO) {
            if(input.isFire) {
                isSleep = true;
                GameManager.instance.score++;
                GameManager.instance.ScoreUpdate();
            }
            else if(input.isFireUp) {
                isSleep = false;
            }   
        }
    }
}
