using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class SaveFile
{
    public List<bool> checkList = new List<bool>();
    public Floor floor = Floor.THREE;
    public int stair = 2;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveFile save;

    [SerializeField]
    private string savepath;

    public Transform playerTrm;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        save = new SaveFile();
        savepath = Application.dataPath + "/Resources/SaveFile.json";
        DataLoad();
        GameManager.instance.InitSpawn(playerTrm);
        GameManager.instance.FloorT();

        if(save.checkList[0]) {
            playerTrm.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    public void DataSave()
    {
        string jsonData = JsonUtility.ToJson(save);
        File.WriteAllText(savepath, jsonData);
        //Debug.Log("save : " + save);
    }

    public void DataLoad()
    {
        save = new SaveFile();
        if(File.Exists(savepath))
        {
            string fromJsonData = File.ReadAllText(savepath);
            save = JsonUtility.FromJson<SaveFile>(fromJsonData);
            //Debug.Log("Load :" + save);
        }
        else
        {
            Data();
            DataSave();
            //Debug.Log("Add :" + save);
        }
    }
    public void DataInit() {
        if(File.Exists(savepath)) {
            save.checkList.RemoveAll(x => true);
            Data();
            DataSave();
        }
        // else {
        //     for (int i = 0; i < 3; i++)
        //     {
        //         save.checkList.Add(false);
        //     }
        //     save.floor = Floor.THREE;
        //     DataSave();
        // }
    }

    public void Data() {
        for (int i = 0; i < 3; i++)
        {
            save.checkList.Add(false);
        }
        save.floor = Floor.THREE;
        save.stair = 2;
    }
}
