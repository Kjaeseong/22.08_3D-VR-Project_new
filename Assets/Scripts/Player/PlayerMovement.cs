using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float RotateY;
    public float RotateSpeed = 200f;

    private float _moveSpeed;

    public PlayerStatus _player;
    public PlayerInput _input;

    private void Awake()
    {
        _player = GetComponent<PlayerStatus>();
    }
    
    private void Update()
    {
        if (_player.IsDie == false)
        {
            Run();
            Walk();
            TurnOnFlash();
        }
        PositionClamp(-499f, 499f);
    }

    void Walk()
    {
        if ( _input.x != 0 || _input.z != 0)
            _player.IsMoving = true;
        else
            _player.IsMoving = false;
        
        Vector3 Direction = Vector3.right * _input.x + Vector3.forward * _input.z;
        transform.Translate(Time.deltaTime * _moveSpeed * Direction.normalized);

        RotateY = transform.eulerAngles.y + _input.Rotate_y * Time.deltaTime * RotateSpeed;
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, RotateY, 0);
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _player.IsRunning = true;
            _moveSpeed = _player.RunSpeed;
        }
        else 
        {
            _player.IsRunning = false;
            _moveSpeed = _player.WalkSpeed;
        }
    }

    void TurnOnFlash()
    {
        if (_player.Battery >= 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _player.FlashOn = _player.FlashOn ? false : true;
            }
        }
        else 
        {
            _player.FlashOn = false;
        }
    }

    void PositionClamp(float min, float max)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min, max), transform.position.y, Mathf.Clamp(transform.position.z, min, max));
    }
}
