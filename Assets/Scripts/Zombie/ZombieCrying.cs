using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieSE
{
    Run1,
    Run2,
    Run3,
    RunMaxCount,
    Normal1,
    Normal2,
    Normal3,
    Normal4,
    Normal5,
    Normal6,
    NormalMaxCount
}

public class ZombieCrying : MonoBehaviour
{
    public AudioClip[] _audioList = new AudioClip[9];
    private AudioSource _source;
    private int _selectAudio;

    private ZombieStatus _zombie;

    private int _runStartNum = 0;
    private int _runEndNum;

    private int _normalStartNum;
    private int _normalEndNum;

    private float _audioLength = 0f;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _zombie = GetComponentInParent<ZombieStatus>();

        _runEndNum = (int)ZombieSE.RunMaxCount;
        _normalStartNum = (int)ZombieSE.RunMaxCount;
        _normalEndNum = (int)ZombieSE.NormalMaxCount - 1;
    }

    private void Update()
    {
        _audioLength -= Time.deltaTime;
        if (_audioLength <= 0)
        {
            if (_zombie.IsWalk)
                RandomPlay(_normalStartNum, _normalEndNum);
            else
                RandomPlay(_runStartNum, _runEndNum);
        }

        if (_zombie.IsRun == true)
        {
            if (_normalStartNum <= _selectAudio && _selectAudio < _normalEndNum - 1)
            {
                _source.Stop();
                RandomPlay(_runStartNum, _runEndNum);
            }
        }
    }

    private void RandomPlay(int strat, int end)
    {
        _selectAudio = Random.Range(strat, end);
        _source.clip = _audioList[_selectAudio];
        _audioLength = _audioList[_selectAudio].length;
        _source.Play();
    }


}
