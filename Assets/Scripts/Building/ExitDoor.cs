using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public bool Visited = false;
    public bool MissionAllClear = false;

    private Outline _outline;
    public Transform RightDoor;
    public Transform LeftDoor;

    public float DoorOpenSpeed = 5f;
    public BuildingSpawner _spawner;
    private GameObject _player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _player == null)
        {
            _player = GetComponent<GameObject>();

            _spawner.PhaseStep = 1;
        }

        if (Visited == false && MissionAllClear == false)
        {
            Visited = true;
            _spawner.VisitedExit = true;

        }

        if (Visited == true && MissionAllClear == true)
        {
            GameManager.Instance.StageClear = true;
        }
    }

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }



    private void Update()
    {
        VisitPlayer();
        ActiveOutline();
        DoorOpen();

    }

    void ActiveOutline()
    {
        if (Visited == MissionAllClear)
        {
            _outline.enabled = true;
        }
        else if (Visited != MissionAllClear)
        {
            _outline.enabled = false;
        }
    }

    void VisitPlayer()
    {




    }

    void DoorOpen()
    {
        if (MissionAllClear == true)
        {
            RightDoor.localPosition = new Vector3(-0.5f, 0f, 0f);
            LeftDoor.localPosition = new Vector3(0.74f, 0.2f, 0f);
        }
    }

}
