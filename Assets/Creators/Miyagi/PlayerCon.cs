using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    [SerializeField] float _mainSpeed;
    [SerializeField] float _defaultSpeed;
    [SerializeField] float _backSpeed;

    Rigidbody _rb;
    Vector3 _moveDirection;
    Quaternion _rotation;
    [SerializeField] float _rotationSpeed;
    [SerializeField]bool isStairs; 
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveInput();
    }
    void MoveInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * z + Camera.main.transform.right * x;

        _moveDirection = moveForward.normalized + new Vector3(0, _moveDirection.y, 0);

        _rb.AddForce(_moveDirection * _mainSpeed);

        if (moveForward != Vector3.zero)
        {
            _rotation = Quaternion.LookRotation(moveForward);
            transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, _rotationSpeed * Time.deltaTime);
        }

        if (isStairs) 
        {
            Transform trans = transform;
            transform.position = trans.position;
            trans.position += trans.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * 0.1f;
            trans.position += trans.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") * 0.1f;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Stairs")
        {
            isStairs = true;
        }
        if(collision.gameObject.tag == "Ground")
        {
            isStairs = false;
        }
    }
}
