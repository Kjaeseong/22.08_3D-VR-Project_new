using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    
    public List<int> list = new List<int>();
    
    public Item[] ItemData = new Item[5];

    


    public int Size = 4;

    public GameObject ItemPrefab;
    public GameObject[] Item = new GameObject[5];
    

    public GameObject FieldItemPrefab;
    public GameObject FieldItem;
    private GameObject BeforeActive;
    public FieldItemStatus FieldItemStatus;
    public BuffList Bufflist;

    public int SelectItem = -1;
    private int _nowInput = -1;

    public PlayerStatus _player;
    public ZombieStatus Zombie;
    public PlayerInput _input;
    public CSVReader CSV;
   
    public int TotalItem;

    private void Start()
    {
        BeforeActive = Instantiate(FieldItemPrefab) as GameObject;
        BeforeActive.transform.parent = gameObject.transform;
        BeforeActive.SetActive(false);

        TotalItem = FileManager.Instance.CSV.Count;
        Bufflist.TotalItem = TotalItem;

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

        ActiveItemSlot();
    }

    void ActiveItemSlot()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < list.Count)
            {
                ItemData[i].Index = list[i];
                ItemData[i].Name = FileManager.Instance.CSV[list[i] - 1]["name"].ToString();
                ItemData[i].Target = FileManager.Instance.CSV[list[i] - 1]["target"].ToString();
                ItemData[i].Subject = FileManager.Instance.CSV[list[i] - 1]["subject"].ToString();
                ItemData[i].Effect = int.Parse(FileManager.Instance.CSV[list[i] - 1]["value"].ToString());
                ItemData[i].ActTime = int.Parse(FileManager.Instance.CSV[list[i] - 1]["time"].ToString());
                ItemData[i].Discription = FileManager.Instance.CSV[list[i] - 1]["description"].ToString();

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
            ItemSlotSelect();
        }
    }

    void ItemSlotSelect()
    {
        if (_nowInput != -1 && SelectItem != -1)
        {
            if (SelectItem == _nowInput)
            {
                list.RemoveAt(SelectItem);
                _nowInput = -1;

                ItemActive(SelectItem);
                SelectItem = -1;
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
        ReadyEffectToField();



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
        if (ItemData[selectItem].Target == "Field")
        {
            EffectToField(ItemData[selectItem].Name, ItemData[selectItem].Subject, ItemData[selectItem].Effect, ItemData[selectItem].ActTime, BeforeActive.transform.position);
        }

        else
        {
            Bufflist.Target = ItemData[selectItem].Target;
            Bufflist.ResetTime = ItemData[selectItem].ActTime;
            Bufflist.Index = ItemData[selectItem].Index;

            switch (ItemData[selectItem].Subject)
            {
                case "Health":
                    Bufflist.Health = ItemData[selectItem].Effect;
                    Bufflist.WalkSpeed = 0f;
                    Bufflist.RunSpeed = 0f;
                    Bufflist.Battery = 0f;
                    break;
                case "Speed":
                    Bufflist.Health = 0;
                    Bufflist.WalkSpeed = ItemData[selectItem].Effect;
                    Bufflist.RunSpeed = ItemData[selectItem].Effect;
                    Bufflist.Battery = 0f;
                    break;

                case "Battery":
                    Bufflist.Health = 0;
                    Bufflist.WalkSpeed = 0f;
                    Bufflist.RunSpeed = 0f;
                    Bufflist.Battery = ItemData[selectItem].Effect;
                    break;
            }
            Bufflist.buffActive = true;
        }




    }


    void EffectToField(string name, string Status, int value, int time, Vector3 position)
    {

        
        switch (Status)
        {
            case "Health":
                FieldItem = Instantiate(FieldItemPrefab) as GameObject;
                FieldItem.name = name;
                FieldItem.tag = "FieldItem";
                FieldItem.transform.position = position;
                FieldItem.SetActive(true);

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
        if (SelectItem != -1)
        {
            Debug.Log($"--{SelectItem}");
            if (ItemData[SelectItem].Target == "Field")
            {
                BeforeActive.SetActive(true);
            }
            else
            {
                BeforeActive.SetActive(false);
            }
        }
        else
        {
            BeforeActive.SetActive(false);
        }
    }
}
