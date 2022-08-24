using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bgm
{ 
    Normal,
    ZombieRun,
    Quantity
}

public class BgmSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _audioList = new AudioClip[(int)Bgm.Quantity];
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
        BgmPlay(_player.BePursued);
    }

    void BgmPlay(bool bePursued)
    {
        _current = _now;
        _now = bePursued;

        if (_current != _now)
            _audiolength = 0f;

        _audiolength -= Time.deltaTime;    
        if (_audiolength <= 0)
        {
            SelectBGM(bePursued);
            _source.Play();
        }
    }

    void SelectBGM(bool bePursued)
    {
        if (bePursued == true)
        {
            _source.clip = _audioList[(int)Bgm.ZombieRun];
            _audiolength = _audioList[(int)Bgm.ZombieRun].length;
        }
        else
        {
            _source.clip = _audioList[(int)Bgm.Normal];
            _audiolength = _audioList[(int)Bgm.Normal].length;
        }
    }

}
