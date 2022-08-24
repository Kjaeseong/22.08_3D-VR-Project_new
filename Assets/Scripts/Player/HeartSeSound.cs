using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSeSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _audioList = new AudioClip[5];
    private float _audiolength = 0f;

    private AudioSource _source;

    private PlayerStatus _player;

    private int _current;
    private int _now;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _player = GetComponentInParent<PlayerStatus>();
    }

    private void Update()
    {
        HeartSoundPlay(_player.IsScary);
    }

    void HeartSoundPlay(int scary)
    {
        if (scary > 0)
        {
            _current = _now;
            _now = scary;

            if (_current != _now)
                _audiolength = 0f;

            _audiolength -= Time.deltaTime;
            if (_audiolength <= 0)
            {
                ChangeSE(scary);
                _source.Play();
            }
        }
        else
        {
            _current = 0;
            _now = 0;
            _audiolength = 0f;
            _source.Stop();
        }
    
    }

    void ChangeSE(int scary)
    {
        _source.clip = _audioList[scary - 1];
        _audiolength = _audioList[scary - 1].length;
    }
}
