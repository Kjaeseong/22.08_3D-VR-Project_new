using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMachineEffectSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _audioList = new AudioClip[2];
    private float _audioLength = 0f;
    public MissionMachine Machine;

    public AudioSource _source;

    private int _current;
    private int _now;

    private void Update()
    {
        OperationSound();

    }

    void OperationSound()
    {
        _current = _now;
        _now = Machine.MissionClear;

        if (Machine.MissionClear == 0)
        {
            _audioLength -= Time.deltaTime;
            if (Machine.MissionStart == true)
            {
                if (_audioLength <= 0)
                {
                    SoundPlay();
                }
            }
            else
            {
                _audioLength = 0f;
                _source.Stop();
            }
        }

        if (_current != _now)
        {
            _audioLength = 0f;
            _source.Stop();
            SoundPlay();
        }

    }

    void SoundPlay()
    {
        _source.clip = _audioList[Machine.MissionClear];
        _audioLength = _audioList[Machine.MissionClear].length;
        _source.Play();
    }
}
