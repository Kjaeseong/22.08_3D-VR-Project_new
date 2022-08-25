using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<int> list = new List<int>();
    public int Size = 4;

    public GameObject ItemPrefab;
    public GameObject[] Item = new GameObject[5];
    public Item[] ItemData = new Item[5];

    public GameObject FieldItemPrefab;
    public GameObject FieldItem;
    private GameObject BeforeActive;
    public FieldItemStatus FieldItemStatus;

    List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
    public int TotalItem;

    public int SelectItem = -1;
    private int _nowInput = -1;

    public PlayerStatus _player;
    public ZombieStatus Zombie;
    public PlayerInput _input;
    public CSVReader CSV;
    
    private void Awake()
    {
        BeforeActive = Instantiate(FieldItemPrefab) as GameObject;
        BeforeActive.transform.parent = gameObject.transform;
        BeforeActive.SetActive(false);

        data = CSVReader.Read("Item/ItemData");
        TotalItem = data.Count;

        for (int i = 0; i < 5; i++)
        {
            Item[i] = Instantiate(ItemPrefab) as GameObject;
            Item[i].transform.parent = gameObject.transform;
            Item[i].name = (i + 1) + " Slot";
            Item[i].SetActive(false);
            ItemData[i] = Item[i].GetComponent<Item>();
        }
    }

    private void Update()
    {
        UseItem();

        

        for (int i = 0; i < 5; i++)
        {
            if (i < list.Count)
            {
                ItemData[i].Index = list[i];
                ItemData[i].Name = data[list[i] - 1]["name"].ToString();
                ItemData[i].Target = data[list[i] - 1]["target"].ToString();
                ItemData[i].Subject = data[list[i] - 1]["subject"].ToString();
                ItemData[i].Effect = int.Parse(data[list[i] - 1]["value"].ToString());
                ItemData[i].ActTime = int.Parse(data[list[i] - 1]["time"].ToString());
                ItemData[i].Discription = data[list[i] - 1]["description"].ToString();

                Item[i].SetActive(true);
                
            }
            else 
            {
                Item[i].SetActive(false);
            }
        }


    }

    void UseItem()
    {
        if (list.Count > 0)
        {
            InputKey();
            Select();
        }
    }

    void Select()
    {

        if (_nowInput != -1 && SelectItem != -1)
        {
            if (SelectItem == _nowInput)
            {
                list.RemoveAt(SelectItem);
                _nowInput = -1;

                ItemActive(SelectItem);
                if (ItemData[SelectItem].Target == "Field")
                {
                    BeforeActive.SetActive(false);
                }
            }
            else
            {
                _nowInput = -1;
            }
            SelectItem = -1;
        }

        if (_nowInput != -1 && Item[_nowInput].activeSelf == true)
        {
            SelectItem = _nowInput;
            _nowInput = -1;
        }
        if (SelectItem != -1)
        {
            if (ItemData[SelectItem].Target == "Field")
            {
                BeforeActive.SetActive(true);
                BeforeActive.transform.position = new Vector3(_player.transform.position.x, 1f, _player.transform.position.z + 5f);

            }
        }
        
        
    }

    void InputKey()
    {

        if (_input.Num1 == true) { _nowInput = 0; }
        if (_input.Num2 == true) { _nowInput = 1; }
        if (_input.Num3 == true) { _nowInput = 2; }
        if (_input.Num4 == true) { _nowInput = 3; }
        if (_input.Num5 == true) { _nowInput = 4; }
    }


    void ItemActive(int selectItem)
    {
        Effect(ItemData[selectItem].Name, ItemData[selectItem].Target, ItemData[selectItem].Subject, ItemData[selectItem].Effect, ItemData[selectItem].ActTime);


    }

    void Effect(string name, string target, string subject, int value, int time)
    {
        switch (target)
        {
            case "Player":
                EffectToPlayer(subject, value, time);
                break;
            case "Enemy":
                EffectToZombie(subject, value, time);
                break;
            case "Field":
                EffectToField(name, subject, value, time);
                break;
        }
    }

    void EffectToPlayer(string Status, int Value, int Time)
    {
        switch (Status)
        {
            case "Health":
                _player.Health += Value;
                break;
            case "Speed":
                _player.WalkSpeed += Value;
                _player.RunSpeed += Value;
                _player.BuffTime = Time;
                break;
            case "Battery":
                _player.Battery += Value;
                break;
        }
    }

    void EffectToZombie(string Status, int Value, int Time)
    {
        switch (Status)
        {
            case "Speed":
                if (_player.CloseDistanceZombie != null)
                {
                    Zombie = _player.CloseDistanceZombie;
                    Zombie.WalkSpeed += Value;
                    Zombie.RunSpeed += Value;
                    Zombie.NeffTime = Time;
                    Zombie.NeffOn = true;
                }
                break;
                
        }
    }

    void EffectToField(string name, string Status, int value, int time)
    {
        switch (Status)
        {
            case "Health":
                FieldItem = Instantiate(FieldItemPrefab) as GameObject;
                FieldItem.name = name;
                FieldItem.tag = "FieldItem";
                FieldItem.transform.position = new Vector3(_player.transform.localPosition.x, 1f, _player.transform.localPosition.z + 5f);

                FieldItemStatus = FieldItem.GetComponent<FieldItemStatus>();
                FieldItemStatus.Health = value;
                if (time > 0)
                {
                    FieldItemStatus.ActiveTime = time;
                }
                break;
        }
    }

    void ReadyEffectToField()
    { 
        
    }


}
