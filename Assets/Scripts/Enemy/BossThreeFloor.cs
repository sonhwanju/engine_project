using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossThreeFloor : MonoBehaviour
{
    public Dictionary<string,string> answerDic = new Dictionary<string, string>();
    public List<string> examList = new List<string>();
    public List<string> answerList = new List<string>();
    public Text examText;
    public Text answerText;
    private int random;
    private int examCount;
    private int answerCount;
    public void Awake()
    {
        examCount = examList.Count;
        answerCount = 0;
        for(int i = 0; i < examList.Count;i++) {
            answerDic.Add(answerList[i],examList[i]);
        }
    }

    public void Exam() {
        random = Random.Range(0,examCount);
        examCount--;
        string s = examList[random];
        examList.Remove(s);

        examText.text = s;
    }
    public void Answer() {
        if(answerList.Count > 0) {
            if(++answerCount >answerList.Count - 1) {
                answerCount = 0;
            }
            answerText.text = answerList[answerCount];
        }
    }
}
