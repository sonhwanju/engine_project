using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HpBar : MonoBehaviour
{
    public Transform playerTrm;
    public float followSpeed = 10f;
    public Transform hpBar;
    private CanvasGroup cg;
    private bool on = true;

    void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }

    public void SetVisible(bool on) {
        this.on = on;
        cg.alpha = on ? 1 : 0;
    }

    public void UpdateHPBar(float ratio) {
        ratio = Mathf.Clamp(ratio,0,1);
        hpBar.DOScaleX(ratio,0.3f);
    }
    void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(playerTrm.position);
        Vector3 nextPos = Vector3.Lerp(transform.position, pos, Time.deltaTime * followSpeed);
        transform.position = nextPos;
    }
}
