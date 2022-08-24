using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int Health = 5;
    public int HealthMax = 5;
    public float Battery = 100f;
    public float WalkSpeed = 3f;
    public float RunSpeed = 7f;

    private int _health_default;
    private int _healthMax_default;
    private float _battery_default;
    private float _walkSpeed_default;
    private float _runSpeed_default;

    public float BuffTime;

    public bool BePursued = false;
    public bool BePursuedRX;
    public bool CurrentRX;

    public GameObject CloseDistObject;
    public ZombieStatus CloseDistanceZombie;

    public bool BuffOn;



    public float MinDistance;
    public int IsScary = 0;

    public bool IsRunning;
    public bool IsMoving;
    public bool FlashOn = false;
    public bool IsDie = false;
    public bool OperationMachine = false;


    private Effects _fadeEffect;
    private ShaderEffect_CorruptedVram _glitchEffect;

    public GameObject FlashLight;



    private void Start()
    {
        _fadeEffect = GetComponentInChildren<Effects>();
        _glitchEffect = GetComponentInChildren<ShaderEffect_CorruptedVram>();
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
        MediaEffectFade();
        GlitchEffect();
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

    void MediaEffectFade()
    {
        if (Health < HealthMax)
        {
            _fadeEffect.enabled = true;
            switch (Health)
            {
                case 4:
                    _fadeEffect.effectType = Fx.sepia;
                    _fadeEffect.styleStrength = 0.02f;
                    break;
                case 3:
                    _fadeEffect.effectType = Fx.sepia;
                    _fadeEffect.styleStrength = 0.04f;
                    break;
                case 2:
                    _fadeEffect.effectType = Fx.sepia;
                    _fadeEffect.styleStrength = 0.08f;
                    break;
                case 1:
                    _fadeEffect.effectType = Fx.greyscale;
                    _fadeEffect.styleStrength = 1;
                    break;
                case 0:
                    _fadeEffect.effectType = Fx.greyscale;
                    _fadeEffect.styleStrength = 1;
                    break;
            }
        }
        else
        {
            _fadeEffect.enabled = false;
        }

        if (IsDie)
        {
            _fadeEffect.brightness -= 2 * Time.deltaTime;
        }
    }

    void GlitchEffect()
    {
        if (IsScary == 0)
        {
            _glitchEffect.enabled = false;
        }
        else
        {
            _glitchEffect.enabled = true;
            
            float Max = IsScary * 0.2f;
            _glitchEffect.shift = Random.Range(-Max, Max);
        }

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
