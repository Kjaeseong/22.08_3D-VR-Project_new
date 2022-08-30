using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    public BuffList Bufflist;
    private RectTransform _transform;

    public PlayerStatus _player;
    public ZombieStatus _zombie;

    private int _posStep;
    public string _target;
    public float _resetTime;
    public Image _image;
    public int _health;
    public float _battery;
    public float _walkSpeed;
    public float _runSpeed;

    private bool _active;

    private bool _loadData;
    private bool _haveTime;

    private void Start()
    {
        Bufflist = GetComponentInParent<BuffList>();
        _transform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    private void Update()
    {

        if (_loadData == false)
        { 
            LoadData();
            GetPlayer();
        }

        if (_active == false)
        {
            GetZombie();
            ActiveEffect();
        }

        IconPosition();
        ClearBuff();
    }

    void IconPosition()
    {
        for (int i = 0; i < Bufflist._bufflist.Count; i++)
        {
            if (Bufflist._bufflist[i].name == gameObject.name)
            {
                _posStep = i + 1;
            }
        }
        _transform.position = new Vector3(10f, _posStep * 80f, 0f);
    }

    void LoadData()
    {
        _image.sprite = FileManager.Instance.Icon[Bufflist.Index - 1];
        _target = Bufflist.Target;
        _resetTime = Bufflist.ResetTime;
        _health = Bufflist.Health;
        _battery = Bufflist.Battery;
        _walkSpeed = Bufflist.WalkSpeed;
        _runSpeed = Bufflist.RunSpeed;
        _image = Bufflist.image;

        _loadData = true;
        if (_resetTime > 1)
        {
            _haveTime = true;
        }
    }

    void GetPlayer()
    {
        _player = GetComponentInParent<PlayerStatus>();
    }

    void GetZombie()
    {
        if (_player.CloseDistanceZombie != null && _target == "Enemy")
        {
            _zombie = _player.CloseDistanceZombie;
        }
    }

    void ActiveEffect()
    {
        switch(_target)
        {
            case "Player":
                _player.Health += _health;
                _player.WalkSpeed += _walkSpeed;
                _player.RunSpeed += _runSpeed;
                _player.Battery += _battery;
                break;

            case "Enemy":
                _zombie.WalkSpeed += _walkSpeed;
                _zombie.RunSpeed += _runSpeed;
                break;
        }
        _active = true;
    }

    private void ClearBuff()
    {
        if (_haveTime == true)
        {
            _resetTime -= Time.deltaTime;

            if (_resetTime <= 0 && _active == true)
            {
                switch (_target)
                {
                    case "Player":
                        _player.Health -= (int)_health;
                        _player.WalkSpeed -= _walkSpeed;
                        _player.RunSpeed -= _runSpeed;
                        _player.Battery -= _battery;
                        break;

                    case "Enemy":
                        _zombie.WalkSpeed -= _walkSpeed;
                        _zombie.RunSpeed -= _runSpeed;
                        break;
                }
                Bufflist._bufflist.Remove(gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            Bufflist._bufflist.Remove(gameObject);
            Destroy(gameObject);
        }
    }

}
