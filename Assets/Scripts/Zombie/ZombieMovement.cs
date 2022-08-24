using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    private DetectionTarget _detection;
    private ZombieStatus _zombie;

    public bool LockOn;
    private float AttackDistance = 2f;

    public float TurnDelay = 4f;
    private float _turn = 0f;
    private float _moveSpeed;

    private void Awake()
    {
        _detection = GetComponent<DetectionTarget>();
        _zombie = GetComponent<ZombieStatus>();
    }

    private void Update()
    {
        if (_detection.SelectTarget != null)
        {
            LockOn = true;
            RunToTarget();
        }
        else
        {
            LockOn = false;
            IdleMove();
        }
    }

    void RunToTarget()
    {
        _moveSpeed = _zombie.RunSpeed;
        float DistanceToTarget = Vector3.Distance(_detection.SelectTarget.position, transform.position);
        transform.LookAt(_detection.SelectTarget);

        if (DistanceToTarget > AttackDistance)
        {
            _zombie.IsRun = true;
            _zombie.IsWalk = false;
            _zombie.CanAttack = false;
            transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward.normalized);
        }
        else
        {
            _zombie.IsRun = false;
            _zombie.IsWalk = false;
            _zombie.CanAttack = true;
        }
    }

    void IdleMove()
    {
        _moveSpeed = _zombie.WalkSpeed;
        _zombie.IsRun = false;
        _zombie.IsWalk = true;
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward.normalized);
        Turn();
    }

    void Turn()
    {
        _turn += Time.deltaTime;
        if (_turn >= TurnDelay)
        {
            transform.rotation = Quaternion.Euler(0f, Random.Range(0, 180), 0f); 

            _turn = 0f;
        }
        
    }

}
