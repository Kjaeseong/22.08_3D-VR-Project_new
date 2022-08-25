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
    public GameObject Screen;
    public MachineScreen ScreenScript;
    public GameObject Scope;

    public bool InsideCollider;
    public bool OnScreen;

    private PlayerStatus _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _player = other.GetComponent<PlayerStatus>();
            InsideCollider = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        InsideCollider = false;
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
        MachineScreen();
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
        if (InsideCollider == true && _player.OperationMachine == true)
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
            Scope.SetActive(false);
        }
        else
        {
            _outLine.enabled = true;
            Scope.SetActive(true);
        }
    }

    void MachineScreen()
    {
        if (InsideCollider == true)
        {
            if (MissionStart == false && MissionClear == 0)
            {
                Screen.SetActive(true);
                ScreenScript.OnScreen = true;
            }
            else if(MissionStart == true || MissionClear == 1)
            {
                ScreenScript.OnScreen = false;
            }
        }
        else 
        {
            ScreenScript.OnScreen = false;
        }
    }

}
