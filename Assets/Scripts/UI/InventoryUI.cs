using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject DescriptionGroup;
    public DescriptionTitle DescriptionTitle;
    public Description Description;

    public GameObject[] Light = new GameObject[5];
    public GameObject[] Icon = new GameObject[5];
    private ItemIcon[] _icon = new ItemIcon[5];
    public int TotalItem;

    public int SelectSlot;
    public int InventorySize;
    public Item[] ItemInfo = new Item[5];

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            _icon[i] = Icon[i].GetComponentInChildren<ItemIcon>();
        }

    }
    private void Update()
    {
        ActiveIcon();
        ItemSelect();
    }

    
    void ActiveIcon()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < InventorySize)
            {
                if (ItemInfo[i] == null)
                {
                    ItemInfo[i] = GameObject.Find(((i + 1).ToString()) + " Slot").GetComponent<Item>();
                }
                _icon[i].IconFile = FileManager.Instance.Icon[ItemInfo[i].Index - 1];
                Icon[i].SetActive(true);
            }
            else 
            {
                Icon[i].SetActive(false);
            }
        }
    }
    
    void ItemSelect()
    {
        if (SelectSlot > -1)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == SelectSlot && Icon[i].activeSelf == true)
                {
                    Light[i].SetActive(true);
                    DescriptionGroup.SetActive(true);
                    ActiveDescription(i);
                }
                else
                {
                    Light[i].SetActive(false);

                }
            }
        }
        else 
        {
            for (int i = 0; i < 5; i++)
            {
                Light[i].SetActive(false);
                DescriptionGroup.SetActive(false);
            }
        }
    }

    void ActiveDescription(int index)
    {
        DescriptionGroup.SetActive(true);
        DescriptionTitle.ItemName = ItemInfo[index].Name;
        Description.ItemDescription = ItemInfo[index].Discription;
    }
    
}
