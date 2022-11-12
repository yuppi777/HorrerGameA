using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public static bool _MasterKey = false;
    [SerializeField] GameObject _playerObj;
    [SerializeField]float time = 0;
   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _playerObj)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (_MasterKey == false)
                {
                    print("鍵がないみたいだ");
                    return;
                }
                else if (_MasterKey == true)
                {
                    for (float i = 0; i < time; i++)
                    {
                        Transform trans = transform;
                        transform.position = trans.position;
                        trans.position += trans.TransformDirection(Vector3.right) * 0.01f * Time.deltaTime;
                    }
                }
            }
            if (Input.GetKey(KeyCode.U))//デバック用
            {
                _MasterKey = true;
            }
        }
    }

}
