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
        if(input.isFire) {
            isSleep = true;
        }
        else if(input.isFireUp) {
            isSleep = false;
        }
    }
}
