using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFile
{
    public bool[] isFloor;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        DataLoad();
    }

    public void DataSave()
    {

    }

    public void DataLoad()
    {

    }
}
