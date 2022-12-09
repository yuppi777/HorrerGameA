using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeCsvLoad : MonoBehaviour
{
    private void Awake()
    {
        KitazzumeOriginalSceneManager.Instance.SceneAdd("TestCSVRoader");
    }
}
