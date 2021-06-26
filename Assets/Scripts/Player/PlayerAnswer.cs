using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnswer : MonoBehaviour
{
    public BossThreeFloor boss;
    private PlayerInput input;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Answer();
    }
    public void Answer() {
        if(input.isRight) {
            boss.AnswerSwapRight();
        }
        else if(input.isLeft) {
            boss.AnswerSwapLeft();
        }

        if(input.isSpace) {
            boss.ExamAnswer();
        }
    }
}
