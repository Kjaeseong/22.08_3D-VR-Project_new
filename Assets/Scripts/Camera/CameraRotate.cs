using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float _rotateX;
    private float _rotateMoveX;

    private PlayerMovement _movement;
    private PlayerStatus _player;
    public Transform _hips;

    private void Awake()
    {
        _movement = GetComponentInParent<PlayerMovement>();
        _player = GetComponentInParent<PlayerStatus>();
        _hips = GetComponent<Transform>();
    }


    void Update()
    {
        if (_player.IsDie == false)
        {
            _rotateMoveX = -Input.GetAxis("Mouse Y") * Time.deltaTime * _movement.RotateSpeed;

            _rotateX += _rotateMoveX;

            _rotateX = Mathf.Clamp(_rotateX, -70, 40);
            transform.rotation = _movement.transform.rotation;
            transform.eulerAngles = new Vector3(_rotateX, _hips.transform.eulerAngles.y, 0);
        }

    }
}

/* 
 void Update()
 {
     if (_player.IsDie == false)
     {
         _rotateMoveX = -Input.GetAxis("Mouse Y") * Time.deltaTime * _movement.RotateSpeed;

         _rotateX += _rotateMoveX;

         _rotateX = Mathf.Clamp(_rotateX, -70, 40);
         transform.rotation = _movement.transform.rotation;
         transform.eulerAngles = new Vector3(_hips.transform.eulerAngles.x + _rotateX, _hips.transform.eulerAngles.y, 0);
     }
 }
*/
