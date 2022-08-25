using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject _playerObject;
    public PlayerStatus _player;
    public PlayerInput _input;

    public GameObject StartTip;
    public GameObject Parameta;
    public GameObject Pause;
    public GameObject GameEnd;

    public bool GameOver;
    public bool StageClear;

    public bool InputSpace;


    private void Start()
    {
        _playerObject = GameObject.Find("Player");
        _player = _playerObject.GetComponent<PlayerStatus>();
        _input = _playerObject.GetComponent<PlayerInput>();

        Pause.SetActive(false);
        GameEnd.SetActive(false);
    }

    private void Update()
    {
        if (StartTip.activeSelf == false)
        {
            Parameta.SetActive(true);

            if (_input.P)
            {
                Pause.SetActive(true);
            }

            if (GameManager.Instance.GameOver == true)
            {
                GameEnd.SetActive(true);
                GameOver = true;
            }

            if (GameManager.Instance.StageClear == true)
            {
                GameEnd.SetActive(true);
                StageClear = true;
            }
        }
        
    }
}
