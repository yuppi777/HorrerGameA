using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform _bodyAxis;
    public Transform _headAxis;
    public static float _xSence = 300.0f;
    public static float _ySence = 300.0f;
    public float _limitXAxizAngle = 30;
    private Vector3 _mXAxiz;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _mXAxiz = _headAxis.localEulerAngles;

    }
    private void CameraFPS()
    {
        float xCamera = Input.GetAxis("Mouse X") * -_xSence * Time.deltaTime;
        _bodyAxis.transform.Rotate(0, -xCamera, 0);

        float yCamera = Input.GetAxis("Mouse Y") * -_ySence * Time.deltaTime;
        var x = _mXAxiz.x + yCamera;
        if (x >= -_limitXAxizAngle && x <= _limitXAxizAngle)
        {
            _mXAxiz.x = x;
            _headAxis.localEulerAngles = _mXAxiz;
        }
    }

    private void Update()
    {
        CameraFPS();
    }
}