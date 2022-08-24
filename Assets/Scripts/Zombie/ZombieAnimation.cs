using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    private Animator _anim;
    private ZombieStatus _zombie;



    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _zombie = GetComponentInParent<ZombieStatus>();
    }
    private void Update()
    {
        _anim.SetBool("Walk", _zombie.IsWalk);
        _anim.SetBool("Run", _zombie.IsRun);

        _zombie.TimeCount -= Time.deltaTime;
        if (_zombie.CanAttack == true && _zombie.TimeCount <= 0)
        { 
            _anim.SetTrigger("Attack");
            _zombie.ActiveAttack = true;
            _zombie.TimeCount = _zombie.AttackCoolTime;
        }
    }
}
