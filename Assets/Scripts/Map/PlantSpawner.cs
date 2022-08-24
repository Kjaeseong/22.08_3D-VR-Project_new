using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [Header ("Tree1")]
    public GameObject Tree1;
    public int Quantity_Tree1 = 80;
    private GameObject[] Pool_Tree1;

    [Header("Tree2")]
    public GameObject Tree2;
    public int Quantity_Tree2 = 80;
    private GameObject[] Pool_Tree2;

    [Header("Tree3")]
    public GameObject Tree3;
    public int Quantity_Tree3 = 80;
    private GameObject[] Pool_Tree3;

    [Header("Stump")]
    public GameObject Stump;
    public int Quantity_Stump = 20;
    private GameObject[] Pool_Stump;

    [Header ("Flower")]
    public GameObject Flower;
    public int Quantity_Flower = 20;
    private GameObject[] Pool_Flower;

    [Header("Mushroom")]
    public GameObject Mushroom;
    public int Quantity_Mushroom = 20;
    private GameObject[] Pool_Mushroom;

    [Header("Grass1")]
    public GameObject Grass1;
    public int Quantity_Grass1 = 50;
    private GameObject[] Pool_Grass1;

    [Header("Grass2")]
    public GameObject Grass2;
    public int Quantity_Grass2 = 50;
    private GameObject[] Pool_Grass2;

    private Vector3 _randPos;
    private int _area = 1;

    
    private void Start()
    {
       Pool_Tree1 = new GameObject[Quantity_Tree1];        
       Pool_Tree2 = new GameObject[Quantity_Tree2];
       Pool_Tree3 = new GameObject[Quantity_Tree3];
       Pool_Stump = new GameObject[Quantity_Stump];
       Pool_Flower = new GameObject[Quantity_Flower];
       Pool_Mushroom = new GameObject[Quantity_Mushroom];
       Pool_Grass1 = new GameObject[Quantity_Grass1];
       Pool_Grass2 = new GameObject[Quantity_Grass2];

        for (int i = 0; i < Quantity_Tree1; i++)
        {
            Pool_Tree1[i] = Instantiate(Tree1) as GameObject;
            Pool_Tree1[i].transform.parent = gameObject.transform;
            Pool_Tree1[i].name = "Tree1 - " + i;
            SetPos(Pool_Tree1[i]);
        }

        for (int i = 0; i < Quantity_Tree2; i++)
        {
            Pool_Tree2[i] = Instantiate(Tree2) as GameObject;
            Pool_Tree2[i].transform.parent = gameObject.transform;
            Pool_Tree2[i].name = "Tree2 - " + i;
            SetPos(Pool_Tree2[i]);
        }
        for (int i = 0; i < Quantity_Tree3; i++)
        {
            Pool_Tree3[i] = Instantiate(Tree3) as GameObject;
            Pool_Tree3[i].transform.parent = gameObject.transform;
            Pool_Tree3[i].name = "Tree3 - " + i;
            SetPos(Pool_Tree3[i]);
        }
        for (int i = 0; i < Quantity_Stump; i++)
        {
            Pool_Stump[i] = Instantiate(Stump) as GameObject;
            Pool_Stump[i].transform.parent = gameObject.transform;
            Pool_Stump[i].name = "Stump - " + i;
            SetPos(Pool_Stump[i]);
        }
        for (int i = 0; i < Quantity_Flower; i++)
        {
            Pool_Flower[i] = Instantiate(Flower) as GameObject;
            Pool_Flower[i].transform.parent = gameObject.transform;
            Pool_Flower[i].name = "Flower - " + i;
            SetPos(Pool_Flower[i]);
        }
        for (int i = 0; i < Quantity_Mushroom; i++)
        {
            Pool_Mushroom[i] = Instantiate(Mushroom) as GameObject;
            Pool_Mushroom[i].transform.parent = gameObject.transform;
            Pool_Mushroom[i].name = "Mushroom - " + i;
            SetPos(Pool_Mushroom[i]);
        }
        for (int i = 0; i < Quantity_Grass1; i++)
        {
            Pool_Grass1[i] = Instantiate(Grass1) as GameObject;
            Pool_Grass1[i].transform.parent = gameObject.transform;
            Pool_Grass1[i].name = "Grass1 - " + i;
            SetPos(Pool_Grass1[i]);
        }
        for (int i = 0; i < Quantity_Grass2; i++)
        {
            Pool_Grass2[i] = Instantiate(Grass2) as GameObject;
            Pool_Grass2[i].transform.parent = gameObject.transform;
            Pool_Grass2[i].name = "Grass2 - " + i;
            SetPos(Pool_Grass2[i]);
        }



    }




    void SetPos(GameObject Target)
    {
        RandomPositionSet((_area % 4) + 1, 10f, 490f, 0f);
        Target.transform.position = _randPos;
        _area++;
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
