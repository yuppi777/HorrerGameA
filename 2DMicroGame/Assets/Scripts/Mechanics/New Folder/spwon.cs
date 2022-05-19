using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwon : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            Debug.Log("きたよ");
        }
    }

}
