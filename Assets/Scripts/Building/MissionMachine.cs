using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMachine : MonoBehaviour
{
    public float TotalTime = 10f;
    public float WaitingTime = 0f;
    public bool MissionStart = false;
    public int MissionClear = 0;

    public GameObject MachineUI;

    public Outline _outLine;
    public GameObject _pointer;
    public ExitDoor ExitDoor;
    public BuildingSpawner _spawner;

    private bool _insideCollider;
    private PlayerStatus _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _player = other.GetComponent<PlayerStatus>();
            _insideCollider = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _insideCollider = false;
    }



    private void Awake()
    {
        _outLine = GetComponent<Outline>();
    }

    private void Update()
    {
        Operation();
        Mission();

        ActiveOutline();
    }

    void Mission()
    {
        if (MissionStart == true && MissionClear != 1)
        {
            MachineUI.SetActive(true);
            WaitingTime += Time.deltaTime;
            if (WaitingTime >= TotalTime)
            {
                MissionClear = 1;
                MissionStart = false;
                _spawner.PhaseStep += 1;
                MachineUI.SetActive(false);
            }
        }
        else if(WaitingTime < TotalTime && MissionStart == false)
        {
            WaitingTime = 0f;
            MachineUI.SetActive(false);
        }
    }

    void Operation()
    {
        if (_insideCollider == true && _player.OperationMachine == true)
        {
            MissionStart = true;
        }
        else
        {
            MissionStart = false;
        }
    
    
    }


    void ActiveOutline()
    {
        if (MissionClear == 1)
        {
            _outLine.enabled = false;
        }
        else
        {
            _outLine.enabled = true;
        }
    }

}
