using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float mainSPEED;
    //[SerializeField] int Run =2;
    private bool _run = true;
    public float x_sensi;
    public float y_sensi;
    public new GameObject camera;
    void Start()
     {
        Cursor.visible = false;
    }
    
    void FixedUpdate()
    {
        movecon();
        cameracon();
        RunPlayer();
    }

    void movecon()//プレイヤーを動かす
    {
        Transform trans = transform;
        transform.position = trans.position;
        trans.position += trans.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * mainSPEED;
        trans.position += trans.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") * mainSPEED;
    }

    void cameracon()//マウスでカメラを動かす処理
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = x_Rotation * x_sensi;
        y_Rotation = y_Rotation * y_sensi;
        this.transform.Rotate(0, x_Rotation, 0);
        camera.transform.Rotate(-y_Rotation, 0, 0);
    }
    void RunPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(_run == true)
            {
                Debug.Log("shift");
                mainSPEED += 0.05f;
                _run = false;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (_run == false)
            {
                Debug.Log("shiftがはなれた");
                mainSPEED -= 0.05f;
                
                _run = true;
            }
        }
    }
}

