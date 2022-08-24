using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerStatus _player;
    private Animator _anim;
    private void Awake()
    {
        _player = GetComponentInParent<PlayerStatus>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        _anim.SetBool("Move", _player.IsMoving);
        _anim.SetBool("Run", _player.IsRunning);
        _anim.SetBool("Die", _player.IsDie);
    }
}
