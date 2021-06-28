using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossTwoFloor : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public Transform targetTrm;
    public Vector2 myTrm;
    public float radius = 10f;
    private WaitForSeconds ws = new WaitForSeconds(1.2f);
    private WaitForSeconds w = new WaitForSeconds(.6f);
    private WaitForSeconds zerotwo = new WaitForSeconds(0.2f);

    private Animator animator;
    private int searchToHash = Animator.StringToHash("search");
    private int deadToHash = Animator.StringToHash("deadBossTwo");
    private bool isDead = false;
    Sequence seq;
    public Door2 door;
    public GameObject colPoint;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        myTrm = transform.position;
        StartCoroutine(Move());
        seq = DOTween.Sequence();
    }
    
    void Update()
    {
        if(SaveManager.instance.save.floor == Floor.TWO) {
            GameManager.instance.Timer();
        }

        if(GameManager.instance.score >= 20000 && !isDead) {
            isDead = true;
            SaveManager.instance.save.checkList[1] = true;
            //for (int i = 0; i < door.doorBox.Length; i++)
            //{
                door.doorBox[1].enabled = true;
            //}
            GameManager.instance.isOpen = true;
            colPoint.SetActive(true);
            animator.Play(deadToHash);
            Invoke("SetAct",1f);
        }
    }
    public void SetAct() {
        gameObject.SetActive(false);
    }

    

    IEnumerator Move() {
        while(!isDead && SaveManager.instance.save.floor == Floor.TWO) {

            seq.Append(transform.DOMove(targetTrm.position, 1f));
            yield return GameManager.instance.min >= 1 ? w : ws;
            Collider2D col = Physics2D.OverlapCircle(transform.position, radius, whatIsPlayer);
            animator.Play(searchToHash);
            if(col != null) {
                if(col.GetComponent<PlayerSleep>().isSleep) {
                    col.GetComponent<PlayerHealth>().OnDamage(1);
                }
            }
            yield return w;
            seq.Append(transform.DOMove(myTrm,1f));
            yield return GameManager.instance.min >= 1 ? w : ws;
        }
        yield break;
    }
}
