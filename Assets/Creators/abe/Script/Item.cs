using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject _getKey;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aa");
        if(collision.gameObject.tag == "Player")
        {
            GOAL.ItemKey = true;
            _getKey.SetActive(true);
            Debug.Log("鍵を入手した");
            Invoke("falseKetText", 3); 
            this.gameObject.SetActive(false);

        }
    }
    public void falseKetText()
    {
        _getKey.SetActive(false);
    }
}
