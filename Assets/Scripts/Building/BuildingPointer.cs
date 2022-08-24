using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingPointer : MonoBehaviour
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

    public MissionMachine _machine;
    public Transform MachinPos;


    private void Awake()
    {
        _machine = GetComponentInParent<MissionMachine>();
        transform.position = new Vector3(MachinPos.position.x, StandardPosition, MachinPos.position.z);
    }

    private void Update() 
    {
        PointerMove();
        Active();

    }

    void Active()
    {
        if (_machine.MissionClear == 1)
        {
            gameObject.SetActive(false);
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
