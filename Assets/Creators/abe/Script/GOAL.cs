using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOAL : MonoBehaviour
{
    public static bool ItemKey = false;

    [SerializeField]Action act;
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            if(ItemKey == true)
            {
                    SceneManager.LoadScene("GameCliea");
            }
            else
            {
                Debug.Log("鍵をさがそう");
            }

            if(act.activeKey[4] == true)
            {
                SceneManager.LoadScene("GameCliea");
            }
            else
            {

            }

        }
    }

    
    
}
