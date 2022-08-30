using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    private GameObject[] _pool = new GameObject[5];

<<<<<<< HEAD
    public bool UseVR;

    private GameObject _camera;
    private GameObject _VR;
=======
    public bool keyboard_Controll;
    private PlayerInput _input;
    private GameObject _camera;
    private GameObject _ovrCamera;
>>>>>>> 95ca876 (Test: Oculus Input Test Code)

    public GameObject Player;
    public GameObject Zombie;
    public GameObject Building;
/*

    public GameObject IngameUI;
*/

    public GameObject Map;


    public bool MissionClear;
    public bool StageClear;
    public bool GameOver;


    public int Phase;


    void Awake()
    {
        base.Awake();
        RoadGameDate();


        /*
        ChangeController();


*/
    }


/*
    public void ChangeController()
    {
        _camera = Player.GetComponentInChildren<GameObject>();
        _ovrCamera = Player.GetComponentInChildren<GameObject>();
        _input = Player.GetComponent<PlayerInput>();

        if(keyboard_Controll == true)
        {
            _camera.SetActive(true);
            _ovrCamera.SetActive(false);
            
        }
        else
        {
            _camera.SetActive(false);
            _ovrCamera.SetActive(true);
            if(_input.Space == true)
            {
                keyboard_Controll = true;
            }
        }
    }


*/


    public void RoadGameDate()
    {
        DestroyGameData();
        _pool[0] = Instantiate(Player) as GameObject;
        _pool[0].name = "Player";

        _pool[1] = Instantiate(Building) as GameObject;
        _pool[1].name = "BuildingSpawner";

        _pool[2] = Instantiate(Map) as GameObject;
        _pool[2].name = "Map";

        _pool[3] = Instantiate(Zombie) as GameObject;
        _pool[3].name = "ZombieSpawner";

/*

        _pool[4] = Instantiate(IngameUI) as GameObject;
        _pool[4].name = "IngameUI";
*/

    }



    public void DestroyGameData()
    {
        for (int i = 4; i >= 0; i--)
        {
            Destroy(_pool[i]);

        }
        MissionClear = false;
        StageClear = false;
        GameOver = false;
        Phase = 0;
    }

    public void Clear()
    { 
    
    }


}
