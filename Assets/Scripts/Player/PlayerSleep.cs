using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSleep : MonoBehaviour
{
    public bool isSleep = false;
    private PlayerInput input;
    private PlayerShooter shooter;
    public AudioClip clip;
    void Awake()
    {
        input = GetComponent<PlayerInput>();
        shooter = GetComponent<PlayerShooter>();
    }

    void Start()
    {
        //shooter.audioSource.clip = clip;
    }
    void OnEnable()
    {
        shooter.audioSource.clip = clip;
    }

    void Update()
    {
        if(SaveManager.instance.save.floor == Floor.TWO) {
            if(input.isFire) {
                isSleep = true;
                GameManager.instance.score++;
                if(!shooter.audioSource.isPlaying) {
                    shooter.audioSource.clip = clip;
                    shooter.audioSource.Play();
                }
                GameManager.instance.ScoreUpdate();
            }
            else if(input.isFireUp) {
                isSleep = false;
                if(shooter.audioSource.isPlaying) {
                    shooter.audioSource.Stop();
                }
            }   
        }
    }
}
