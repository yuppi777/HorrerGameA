using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FirstCsvData : MonoBehaviour
{
    [SerializeField] StoryMaster data;
    public TextAsset NowCommpanionSerif => nowcommpanionserif;
    private TextAsset nowcommpanionserif;
    public Sprite NowCommpanionFace => nowcommpanionface;
    private Sprite nowcommpanionface;


    public void SelifData(string nowCommpanionName)
    {
        var query = data.sheet;

        var nowCommpanionData = query.First();
        nowcommpanionserif = nowCommpanionData.CsvFile;
        nowcommpanionface = nowCommpanionData.sprite;


    }
}
