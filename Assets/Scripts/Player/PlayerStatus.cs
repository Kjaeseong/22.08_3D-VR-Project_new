using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int Health = 5;
    public int HealthMax = 5;
    public float Battery = 100f;
    public float WalkSpeed = 10f;
    public float RunSpeed = 20f;

    private int _health_default;
    private int _healthMax_default;
    private float _battery_default;
    private float _walkSpeed_default;
    private float _runSpeed_default;

    public bool IsRunning;
    public bool IsMoving;
    public bool FlashOn = false;
    public bool IsDie = false;
    public bool OperationMachine = false;
    
    public bool BePursued = false;
    public bool BePursuedRX;
    public bool CurrentRX;
    
    public float BuffTime;

    public GameObject CloseDistObject;
    public ZombieStatus CloseDistanceZombie;
    public float MinDistance;

    public bool BuffOn;

    public int IsScary = 0;

    public GameObject FlashLight;



    private void Start()
    {
        GameManager.Instance.GameOver = false;
        GameManager.Instance.StageClear = false;


        _health_default = Health;
        _healthMax_default = HealthMax;
        _battery_default = Battery;
        _walkSpeed_default = WalkSpeed;
        _runSpeed_default = RunSpeed;
    }

    private void Update()
    {
        if (Health > HealthMax)
        {
            Health = HealthMax;
        }



        RX();
        FlashLight.SetActive(FlashOn);
        CostBattery();
        Scary();
        PlayerAlive();

        StatusReset();
        Operation();
    }

    void CostBattery()
    {
        if (FlashOn)
        {
            Battery -= Time.deltaTime;
        }
    }

    void Scary()
    {
        if (MinDistance <= 20)
            IsScary = 5;
        else if (MinDistance <= 30)
            IsScary = 4;
        else if (MinDistance <= 40)
            IsScary = 3;
        else if (MinDistance <= 60)
            IsScary = 2;
        else if (60 < MinDistance && MinDistance <= 80)
            IsScary = 1;
        else
            IsScary = 0;
    }

    void PlayerAlive()
    {
        if (Health <= 0)
        {
            IsDie = true;
            GameManager.Instance.GameOver = true;
        }
    }

    void RX()
    {
        if (BePursuedRX == true && CurrentRX == true)
        {
            BePursued = true;
        }
        else
        {
            BePursued = false;
        }
        CurrentRX = BePursuedRX;
        BePursuedRX = false;
    }

    void Operation()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OperationMachine = true;
        }
        else
        {
            OperationMachine = false;
        }
    }

    void StatusReset()
    {
        if (BuffTime > 0)
        {
            BuffTime -= Time.deltaTime;
            BuffOn = true;
        }
        
        if (BuffTime <= 0 && BuffOn == true)
        {
            Health = _health_default;
            HealthMax = _healthMax_default;
            Battery = _battery_default;
            WalkSpeed = _walkSpeed_default;
            RunSpeed = _runSpeed_default;
            BuffOn = false;
        }
        
    }
}
