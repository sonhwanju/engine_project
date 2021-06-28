using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BossThreeFloor : MonoBehaviour
{
    public PlayerHealth health;

    public Dictionary<string,string> answerDic = new Dictionary<string, string>();
    public List<string> examList = new List<string>();
    public List<string> replaceExamList = new List<string>();
    public List<string> answerList = new List<string>();
    public Text examText;
    public Text answerText;
    private int random;
    private int examCount;
    private int answerCount;
    public Door3 door;
    public GameObject colObj;
    private Sequence seq;
    public void Awake()
    {
        seq = DOTween.Sequence();
        for(int i = 0; i < examList.Count; i++) {
            replaceExamList.Add(examList[i].Replace("\\n","\n"));
        }
        examCount = replaceExamList.Count;
        answerCount = 0;
        for(int i = 0; i < replaceExamList.Count;i++) {
            answerDic.Add(answerList[i],replaceExamList[i]);
        }
        AnswerSwapRight();
        Exam();
    }

    public void Exam() {
        if(replaceExamList.Count > 0) {
            random = Random.Range(0,examCount);
            examCount--;
            string s = replaceExamList[random];
            replaceExamList.Remove(s);
            seq.Kill();
            seq.Append(examText.DOText(s,1f));
        }
        else {
            answerText.text = "";
            examText.text = "";
            //for (int i = 0; i < door.doorBox.Length; i++)
            //{
                door.doorBox[1].enabled = true;
            //}
            colObj.SetActive(true);
            SaveManager.instance.save.checkList[2] = true;
        }
    }
    public void AnswerSwapRight() {
        if(++answerCount >answerList.Count - 1) {
            answerCount = 0;
        }
        if(answerList.Count > 0)
            answerText.text = answerList[answerCount];
    }
    public void AnswerSwapLeft() {
        if(--answerCount < 0) {
            answerCount = answerList.Count - 1;
        }
        answerText.text = answerList[answerCount];
    }

    public void ExamAnswer() {
        if(answerDic.Count > 0) {
            string s = answerText.text;
            if(answerDic[s] == examText.text) {
                answerDic.Remove(s);
                answerList.Remove(s);
                AnswerSwapRight();
                Exam();
            }
            else if(answerDic[s] != examText.text) {
                health.OnDamage(1);
            }
        }
        // else {
        //     answerText.text = "";
        //     examText.text = "";
        // }
    }
}
