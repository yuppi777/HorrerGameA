using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(menuName = "ScriptableObject/CreateAsset")]

public class StoryMaster : ScriptableObject
{
    public List<StoryMasterRecord> sheet;

    //public enum JobPost
    //{
    //    Programer,
    //    Farmers,
    //    Idol,
    //}


    [Serializable]
    public class StoryMasterRecord
    {
        public string storyName;
        public Sprite sprite;
        public Sprite chara2;
        public TextAsset CsvFile;
        //public StoryMaster.JobPost Post;

    }
}
