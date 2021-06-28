using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnswer : MonoBehaviour
{
    public BossThreeFloor boss;
    private PlayerInput input;
    private PlayerShooter shooter;
    public AudioClip clip;
    public AudioClip clip2;
    void Awake()
    {
        input = GetComponent<PlayerInput>();
        shooter = GetComponent<PlayerShooter>();
    }
    void OnEnable()
    {
        
    }

    void Update()
    {
        Answer();
    }
    public void Answer() {
        if(input.isRight) {
            boss.AnswerSwapRight();
            PlaySound();
        }
        else if(input.isLeft) {
            boss.AnswerSwapLeft();
            PlaySound();
        }

        if(input.isSpace) {
            boss.ExamAnswer();
        }
    }
    public void PlaySound() {
        shooter.audioSource.clip = clip;
        shooter.audioSource.Play();
    }
}
