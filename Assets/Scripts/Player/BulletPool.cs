using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    private Queue<GameObject> bullet = new Queue<GameObject>();
    public GameObject bulletPrefab;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject obj = Instantiate(bulletPrefab, gameObject.transform);
            InsertQueue(obj);
        }
    }

    public void InsertQueue(GameObject obj)
    {
        bullet.Enqueue(obj);
        obj.transform.position = transform.position;
        obj.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject obj;
        if (bullet.Count != 0)
        {
            obj = bullet.Dequeue();
            obj.SetActive(true);

        }
        else
        {
            obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        return obj;
    }
}
