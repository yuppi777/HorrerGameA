using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveDoor : MonoBehaviour
{
    private bool _neerDoor;
    private bool _OpenDoor = true;
    public static bool _MasterKey = false;
    [SerializeField] GameObject _playerObj;
    [SerializeField]float time = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.U))//デバック用
        {
            _MasterKey = true;
        }
        if (_neerDoor == true && _OpenDoor ==true) {
            if (Input.GetKey(KeyCode.E))
            {
                if (_MasterKey == false)
                {
                    print("鍵がないみたいだ");
                    return;
                }
                else if (_MasterKey == true)
                {
                    /* for (float i = 0; i <= time; i++)
                     {
                         Transform trans = transform;
                         transform.position = trans.position;
                         trans.position += trans.TransformDirection(Vector3.right) * 0.01f * Time.deltaTime;
                     }*/
                    SceneManager.LoadScene("SecondMap");

                }

               
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _playerObj)
        {
            _neerDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _playerObj)
        {
            _neerDoor = false;
        }
    }


}
