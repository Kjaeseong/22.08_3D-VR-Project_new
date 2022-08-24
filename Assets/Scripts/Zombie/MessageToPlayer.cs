using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageToPlayer : MonoBehaviour
{
    private DetectionTarget _detection;
    private ZombieMovement _movement;
    private ZombieStatus _zombie;

    //private MannequinStatus _mannequin;
    private PlayerStatus _player;

    private bool RoadData;



    private void Start()
    {
        _detection = GetComponent<DetectionTarget>();
        _movement = GetComponent<ZombieMovement>();
        _zombie = GetComponent<ZombieStatus>();

        _player = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    void DataRoad()
    { 
        
    }


    private void Update()
    {
        Targeting();
        Attack();
    }


    void Targeting()
    {
        PlayerIsTarget();
        MannequinIsTarget();
    }

    void PlayerIsTarget()
    {
        if (_detection.SelectTarget != null && _detection.SelectTarget.name == "Player")
        {
            _player.BePursuedRX = true;
        }
    }
    void MannequinIsTarget()
    {
        
    }


    void Attack()
    {
        if (_detection.SelectTarget != null && _zombie.ActiveAttack == true)
        {
            if (_detection.SelectTarget.name == "Player")
            {
                _player.Health -= _zombie.AttackDamage;
                Debug.Log($"플레이어 체력 : {_player.Health}");
            }
            if (_detection.SelectTarget.name == "Mannequin")
            {
                //_mannequin.Health -= _zombie.AttackDamage;
            }
            _zombie.ActiveAttack = false;
        }
    }

}
