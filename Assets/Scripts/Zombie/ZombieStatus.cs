using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStatus : MonoBehaviour
{
    public float WalkSpeed = 4f;
    public float RunSpeed = 8f;
    public float AttackCoolTime = 2f;
    public int AttackDamage = 1;
    
    private float _walkSpeed_default;
    private float _runSpeed_default;
    private float _attackCoolTime_default;
    private int _attackDamage_default;

    public float NeffTime;

    public bool NeffOn;

    public float TimeCount = 0f;

    public bool CanAttack;
    public bool IsRun;
    public bool IsWalk;

    public bool ActiveAttack;

    private void Awake()
    {
        _walkSpeed_default = WalkSpeed;
        _runSpeed_default = RunSpeed;
        _attackCoolTime_default = AttackCoolTime;
        _attackDamage_default = AttackDamage;
    }

    private void Update()
    {
        NeffReset();
    }

    void NeffReset()
    {
        if (NeffTime > 0)
        {
            NeffTime -= Time.deltaTime;
        }
        else if (NeffTime <= 0 && NeffOn == true)
        {
            StatusReset();
        }
    }
    void StatusReset()
    {
        WalkSpeed = _walkSpeed_default;
        RunSpeed = _runSpeed_default;
        AttackCoolTime = _attackCoolTime_default;
        AttackDamage = _attackDamage_default;
        NeffOn = false;
    }
}
