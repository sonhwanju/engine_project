using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class SaveFile
{
    public List<bool> checkList = new List<bool>();
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveFile save;

    [SerializeField]
    private string savepath;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        save = new SaveFile();
        savepath = Application.dataPath + "/Resources/SaveFile.json";
        DataLoad();
    }

    public void DataSave()
    {
        string jsonData = JsonUtility.ToJson(save);
        File.WriteAllText(savepath, jsonData);
        Debug.Log("save : " + save);
    }

    public void DataLoad()
    {
        save = new SaveFile();
        if(File.Exists(savepath))
        {
            string fromJsonData = File.ReadAllText(savepath);
            save = JsonUtility.FromJson<SaveFile>(fromJsonData);
            Debug.Log("Load :" + save);
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                save.checkList.Add(false);
            }
            DataSave();
            Debug.Log("Add :" + save);
        }
    }
}
