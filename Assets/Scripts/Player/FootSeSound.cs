using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSeSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _audioList = new AudioClip[2];
    private float _audiolength = 0f;

    private AudioSource _source;

    private PlayerStatus _player;

    private bool _current;
    private bool _now;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _player = GetComponentInParent<PlayerStatus>();
    }

    private void Update()
    {
        FootSoundPlay(_player.IsMoving, _player.IsRunning);
    }

    void FootSoundPlay(bool move, bool run)
    {
        if (move == true)
        {
            _current = _now;
            _now = run;

            if (_current != _now)
                _audiolength = 0f;

            _audiolength -= Time.deltaTime;
            if (_audiolength <= 0)
            {
                ChangeSE(run);
                _source.Play();
            }
        }
        else 
        {
            _current = false;
            _now = false;
            _audiolength = 0f;
            _source.Stop();
        }

    }

    void ChangeSE(bool run)
    {
        if (run == true)
        {
            _source.clip = _audioList[1];
            _audiolength = _audioList[1].length;
        }
        else
        {
            _source.clip = _audioList[0];
            _audiolength = _audioList[0].length;
        }
    }
}
