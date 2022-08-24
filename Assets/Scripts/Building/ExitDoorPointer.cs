using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitDoorPointer : MonoBehaviour
{
    //위아래 이동
    //선형보간 사용

    [Range(0, 50)]
    public float StandardPosition = 30;

    [Range(0, 20)]
    public float MoveSpeed = 10;

    [Range(0, 10)]
    public float MoveRange = 2.5f;

    [Range(0f, 10f)]
    public float RotateSpeed = 2f;

    private int _direction = 1;
    private float _targetPosY;

    public ExitDoor _exitDoor;
    public MeshRenderer _active;


    private void Awake()
    {
        _exitDoor = GetComponentInParent<ExitDoor>();
        _active = GetComponent<MeshRenderer>();
    }

    private void Update() 
    {
        PointerMove();
        Active();
    }

    void Active()
    {
        if (_exitDoor.Visited == _exitDoor.MissionAllClear)
        {
            _active.enabled = true;
        }
        else if (_exitDoor.Visited != _exitDoor.MissionAllClear)
        {
            _active.enabled = false;
        }
    }

    void PointerMove()
    {
        _targetPosY = StandardPosition + (_direction * MoveRange);

        if (transform.position.y >= _targetPosY)
        {
            _direction = -1;
        }
        if (transform.position.y <= _targetPosY)
        {
            _direction = 1;
        }

        transform.Translate(0f, -1 * _direction * MoveSpeed * Time.deltaTime, 0f);
        transform.Rotate(0f, RotateSpeed, 0f);
    }
}
