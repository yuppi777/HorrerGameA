using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aa");
        if(collision.gameObject.tag == "Player")
        {
            GOAL.ItemKey = true;
            Debug.Log("鍵を入手した");
            this.gameObject.SetActive(false);
        }
    }
}
