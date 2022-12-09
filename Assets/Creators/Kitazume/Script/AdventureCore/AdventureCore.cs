using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureCore : MonoBehaviour
{
    [SerializeField] CSVRoader CSVRoader;
    //[SerializeField] SelectCommpanion selectCommpanion;
    [SerializeField] FirstCsvData firstCsvData;
    public string NowCommpanionName;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);


    }
    private void Start()
    {
        firstCsvData.SelifData(NowCommpanionName);


        //Debug.Log(NowCommpanionName);
        //if (selectCommpanion.NowCommpanionSerif != null)
        //{
        //    Debug.Log("成功");

        //}
        

        CSVRoader.CSVRoad(firstCsvData.NowCommpanionSerif);
        StartCoroutine(CSVRoader.TextView());


    }
    private void Update()
    {
        CSVRoader.SetFace(firstCsvData.NowCommpanionFace);
    }
}
