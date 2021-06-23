using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Boss
{
    PHASEONE,
    PHASETWO,
    DEAD
}

public class Enemy1 : MonoBehaviour,IDamageable
{
    [SerializeField]
    private int hp;
    private int maxHp = 500;

    private WaitForSeconds ws = new WaitForSeconds(0.5f);
    private WaitForSeconds wfs = new WaitForSeconds(.7f);
    private WaitForSeconds threeSec = new WaitForSeconds(3f);
    private WaitForSeconds twoSec = new WaitForSeconds(2f);
    private WaitForSeconds fiveSecond = new WaitForSeconds(5f);
    
    public float rot_speed;
    public Transform pos;
    public Transform spinPos;
    //public Transform center;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject enemy2;
    //public GameObject spawnEnemy;
    public Transform target;

    public Transform poolTrm;

    public Transform[] patrolTrm;
    private int randomTrm;
    private float waitTime;
    private float startWaitTime = 2f;
    public float speed = 10f;
    private float shotWaitTime;
    private float shotStartWaitTime = 5f;
    private Boss boss = Boss.PHASEONE;
    public Image hpBar;
    private bool isDie = false;

    public float santanWait;
    private float startSantanWait = 3f;

    void Awake()
    {
        PoolManager.CreatePool<enemyBullet>(bulletPrefab,poolTrm, 50);
        PoolManager.CreatePool<enemyBullet2>(bulletPrefab2,poolTrm, 20);
        PoolManager.CreatePool<Enemy2>(enemy2,poolTrm,10);
    }
    private void Start()
    {
        waitTime = startWaitTime;
        randomTrm = Random.Range(0, patrolTrm.Length);
        shotWaitTime = shotStartWaitTime;
        santanWait = startSantanWait;
        StartCoroutine(CideShotCo());
    }

    void OnEnable()
    {
        hp = maxHp;
    }


    void Update()
    {
        Patrolling();
        if(santanWait <= 0) {
            StartCoroutine(ShotgunCo());
            santanWait = startSantanWait;
        }
        else {
            santanWait-=Time.deltaTime;
        }

        if(boss == Boss.PHASEONE) {
            ShotTime();
            
        }
        else if(boss == Boss.PHASETWO) {
            //StopCoroutine(CideShotCo());
            startSantanWait = 1f;
            shotStartWaitTime = 4f;
        }
        
    }

    public void OnDamage(int damage) {
        hp -= damage;
        UIUpdate();

        if(hp <= 0) {
            isDie = true;
            boss = Boss.DEAD;
            Destroy(gameObject,1f);
        }

        if(hp <= (maxHp / 2 )) {
            boss = Boss.PHASETWO;
            
        }
    }
    IEnumerator SpawnEnemy() {
        while(true) {
            if(boss == Boss.PHASETWO) {
                Enemy2 enemy = PoolManager.GetItem<Enemy2>();
                //이제 어디서 생성될지 정해줘야한다.
            }
            yield return fiveSecond;
        }
    }

    public void UIUpdate() {
        hpBar.fillAmount = ((float)hp / (float)maxHp); 
    }

    private void ShotTime()
    {
        if (shotWaitTime <= 0)
        {
            GoToShot();
            shotWaitTime = shotStartWaitTime;
        }
        else
        {
            shotWaitTime -= Time.deltaTime;
        }

        if (boss == Boss.PHASETWO)
        {
            shotStartWaitTime = 2f;
        }
    }

    IEnumerator ShotgunCo()
    {
        Vector3 rot = target.position - pos.position;
        float angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;

        pos.rotation = Quaternion.Euler(0, 0, angle);

        enemyBullet obj = PoolManager.GetItem<enemyBullet>();
        obj.transform.position = transform.position;
        obj.transform.rotation = pos.rotation;

        yield return wfs;
        for (int i = -1; i < 2; i++)
        {
            enemyBullet obj2 = PoolManager.GetItem<enemyBullet>();
            obj2.transform.position = obj.transform.position;
            obj2.transform.rotation = Quaternion.Euler(0, 0, angle + (i * 10));
        }

        yield break;
    }

    void Patrolling()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolTrm[randomTrm].position, speed * Time.deltaTime);
        int first = patrolTrm.Length / 2;
        if (Vector2.Distance(transform.position, patrolTrm[randomTrm].position) <= 0.2f)
        {
            if (waitTime <= 0)
            {

                //StartCoroutine(CideShotCo());
                if(boss == Boss.PHASEONE) {
                    randomTrm = Random.Range(0, first);
                }
                else if(boss == Boss.PHASETWO) {
                    randomTrm = Random.Range(first,patrolTrm.Length);
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
                //SpinShot();
            }
        }
    }
    void SpinShot()
    {
        spinPos.transform.Rotate(Vector3.forward * rot_speed * 50 * Time.deltaTime);

        enemyBullet obj = PoolManager.GetItem<enemyBullet>();

        obj.transform.position = spinPos.transform.position;

        obj.transform.rotation = spinPos.transform.rotation;
    }

    void CideShot()
    {
        for (int i = 0; i < 360; i += 13)
        {
            enemyBullet temp = PoolManager.GetItem<enemyBullet>();
            Vector2 targetDir = target.transform.position - temp.transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

            temp.transform.position = transform.position;

            temp.transform.rotation = Quaternion.Euler(0, 0, i + angle);
        }
    }

    IEnumerator CideShotCo()
    {
        while(!isDie) {
            for (int i = 0; i < 3; i++)
            {
                CideShot();
                yield return ws;
            }
            yield return boss == Boss.PHASEONE ? threeSec : twoSec;
        }
        yield break;
    }

    void GoToShot()
    {
        List<Transform> list = new List<Transform>();

        for (int i = 0; i < 360; i += 13)
        {
            enemyBullet2 obj = PoolManager.GetItem<enemyBullet2>();

            obj.transform.position = transform.position;

            list.Add(obj.transform);
            obj.transform.rotation = Quaternion.Euler(0, 0, i);
        }

        StartCoroutine(BulletToTarget(list));
    }

    IEnumerator BulletToTarget(List<Transform> list)
    {
        yield return ws;

        for (int i = 0; i < list.Count; i++)
        {
            Vector2 targetDir = target.transform.position - list[i].position;

            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

            list[i].rotation = Quaternion.Euler(0, 0, angle);
        }
        list.Clear();
    }
}
