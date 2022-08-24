using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BuildingSpawner : MonoBehaviour
{
    public bool VisitedExit;

    public GameObject[] Mission = new GameObject[4];
    public MissionMachine[] Success = new MissionMachine[4];

    [Range(0, 120)]
    public float ItemRespawnCoolTime = 60f;
    public GameObject[] ItemBox = new GameObject[4];
    private float[] _itemRespawn = new float[4];

    public int PhaseStep = 0;


    public ExitDoor Door;

    public bool MissionCreated = false;
    public bool MissionAllClear = false;

    private Vector3 _randPos;


    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            RandomPositionSet(i + 1, 50f, 450f, 3f);
            Mission[i].transform.position = _randPos;
            _itemRespawn[i] = 0f;
        }
    }

    private void Update()
    {
        GameManager.Instance.Phase = PhaseStep;
        MissionCreat();
        MissionClear();
        ItemRespawn();
    }

    void MissionCreat()
    {
        if (VisitedExit == true && MissionCreated == false)
        {
            for (int i = 0; i < 4; i++)
            {
                Mission[i].SetActive(true);
            }
            MissionCreated = true;
        }
    }

    void MissionClear()
    {
        if (MissionAllClear == false)
        {
            if (Success[0].MissionClear + Success[1].MissionClear + Success[2].MissionClear + Success[3].MissionClear == 4)
            {
                MissionAllClear = true;
                Door.MissionAllClear = true;
            }
        }
    }


    void ItemRespawn()
    {
        for (int i = 0; i < 4; i++)
        {
            if (ItemBox[i].activeSelf == false && MissionCreated == true)
            {
                _itemRespawn[i] -= Time.deltaTime;
                if (_itemRespawn[i] <= 0)
                {
                    _itemRespawn[i] = ItemRespawnCoolTime;
                    ItemCreate(i + 1);
                }
            }
        }
    }

    void ItemCreate(int area)
    {
        RandomPositionSet(area, 50f, 450f, 2f);
        ItemBox[area - 1].transform.position = _randPos;
        ItemBox[area - 1].SetActive(true);
    }


    void RandomPositionSet(int area, float min, float max, float hight)
    {
        int x = 0;
        int z = 0;

        switch (area)
        {
            case 1:
                x = 1;
                z = 1;
                break;
            case 2:
                x = -1;
                z = 1;
                break;
            case 3:
                x = -1;
                z = -1;
                break;
            case 4:
                x = 1;
                z = -1;
                break;
        }

        _randPos = new Vector3(x * Random.Range(min, max), hight, z * Random.Range(min, max));
    }
}
