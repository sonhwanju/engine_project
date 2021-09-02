using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Floor
{
    THREE,
    TWO,
    ONE
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("스위치 + 계단관련 변수들")]
    public ArrowSwitch[] arrow;
    public Transform[] stairTrm;
    public Transform playerTrm;

    public GameObject boss;
    public GameObject bossBar;

    public GameObject bloodEffect;
    public Transform poolTrm;

    public bool isFade = false;
    public bool isOpen = false;
    public GameObject playerChild;
    public int enemy2Check = 0;

    float sec = 0;
    public int min = 0;
    public Text timeText;
    public Text scoreText;
    public GameObject boss2;
    public int score = 0;
    public Transform[] spawnTrms;
    public PlayerSleep sleep;
    public PlayerInput input;

    public GameObject boss3;
    public PlayerAnswer answer;
    public Text floorText;
    public GameObject exitPanel;
    public AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        PoolManager.CreatePool<BloodEffect>(bloodEffect,poolTrm);
        isOpen = false;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Screen.SetResolution(1920,1080, true);
    }
    void Update()
    {
        if(input.isEsc) {
            EscDown();
        }
    }

    public void ReStart() {
        Time.timeScale = 1;
        SaveManager.instance.DataInit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void EscDown() {
        exitPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Exit() {
        Application.Quit();
    }
    public void NoExit() {
        Time.timeScale = 1;
        exitPanel.SetActive(false);
    }

    public void InitTwoFloor(bool on) {
        if(boss2 != null) {
            boss2.SetActive(on);
        }
        timeText.gameObject.SetActive(on);
        scoreText.gameObject.SetActive(on);
        sleep.enabled = on;
    }
    public void InitSpawn(Transform trm) {
        int a = (int)SaveManager.instance.save.floor;
        trm.position = spawnTrms[a].position;
    }
    public void InitThreeFloor(bool on) {
        boss3.SetActive(on);
        answer.enabled = on;
    }
    public void Timer() {
        sec+=Time.deltaTime;

        if(sec >= 60) {
            sec = 0;
            min++;
        }
        timeText.text = $"{min} : {(int)sec}";
    }
    public void ScoreUpdate() {
        scoreText.text = $"{score} 점";
    }

    public void ActiveCircle(bool on) {
        //Debug.Log(on);
        playerChild.SetActive(on);
        playerChild.transform.parent.GetComponent<BoxCollider2D>().enabled = !on;
        playerTrm.GetComponent<Rigidbody2D>().collisionDetectionMode = on ? CollisionDetectionMode2D.Continuous : CollisionDetectionMode2D.Discrete;  
    }
    public void BossSpawn(bool on)
    {
        boss.SetActive(on);
        bossBar.SetActive(on);
    }

    void OnApplicationQuit()
    {
        SaveManager.instance.DataSave();
    }
    public void StairChange()
    {
        if (SaveManager.instance.save.checkList[0]) {
            if(SaveManager.instance.save.stair > 1) {
                SaveManager.instance.save.stair--;
                SaveManager.instance.save.floor++;
                playerTrm.position = stairTrm[SaveManager.instance.save.stair].position;
            }
            else if(SaveManager.instance.save.stair > 0) {
                if(SaveManager.instance.save.checkList[1]) {
                    SaveManager.instance.save.stair--;
                    SaveManager.instance.save.floor++;
                    playerTrm.position = stairTrm[SaveManager.instance.save.stair].position;
                }
            }
            FloorT();
        }
        
    }
    public void FloorT() {
        floorText.text = $"{(int)SaveManager.instance.save.stair + 1}f";
    }   
}

