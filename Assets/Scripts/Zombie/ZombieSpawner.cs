using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] ZombieList = new GameObject[4];
    public int ZombieType = 4;
    public GameObject[,] ZombiePool;
    public int PoolSize = 30;



    public int Phase;
    private int _currentPhase;
        
    public int StartingQuantity = 12;
    private int AreaQuantity = 0;
    public int AddQuantityPhaseUp = 6;

    private Vector3 _randPos;

    private bool Pool = false;


    private void Start()
    {
        int temp = 0;
        ZombiePool = new GameObject[4, PoolSize];

        for (int area = 0; area < 4; area++)
        {
            for (int slot = 0; slot < PoolSize; slot++)
            {
                ZombiePool[area, slot] = Instantiate(ZombieList[temp % 4]) as GameObject;
                ZombiePool[area, slot].transform.parent = gameObject.transform;
                ZombiePool[area, slot].SetActive(false);
                temp++;
            }
        }

    }

    private void Update()
    {
        Phase = GameManager.Instance.Phase;
        PhaseUp();
    }

    void PhaseUp()
    {
        if (_currentPhase != Phase)
        {
            if (AreaQuantity == 0)
            {
                AreaQuantity = StartingQuantity;
                for (int area = 0; area < 4; area++)
                {
                    for (int slot = 0; slot < AreaQuantity; slot++)
                    {
                        Summon(area, slot);
                        
                        Debug.Log("초기소환");

                    }
                }
            }
            else if(AreaQuantity != 0 && AreaQuantity < PoolSize)
            {
                for (int area = 0; area < 4; area++)
                {
                    for (int slot = AreaQuantity; slot < AreaQuantity + AddQuantityPhaseUp; slot++)
                    {
                        Summon(area, slot);
                        Debug.Log("페이즈업 소환");

                    }
                }

                AreaQuantity += AddQuantityPhaseUp;
            }
        }
        _currentPhase = Phase;

    }






    

    void Summon(int area, int slot)
    {
        RandomPositionSet(area + 1, 20f, 480f, 3f);
        ZombiePool[area, slot].transform.position = _randPos;
        ZombiePool[area, slot].SetActive(true);
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
