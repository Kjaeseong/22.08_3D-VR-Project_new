using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    private GameObject _player;
    private PlayerStatus _status;
    private PlayerInventory _inventory;
    public InventoryUI _invenUI;
    public HealthUI _healthUI;
    public BatteryUI _batteryUI;
    public HeartRateUI _heartRateUI;
    public GameObject _compass;

    

    public float Health;
    public float Battery;

    public int inven_SelectItem;
    public int inven_Size;

    public int Rate_Scary;
    internal Camera worldCamera;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _status = _player.GetComponent<PlayerStatus>();
        _inventory = _player.GetComponent<PlayerInventory>();

        _batteryUI = GetComponentInChildren<BatteryUI>();
        _healthUI = GetComponentInChildren<HealthUI>();

    }

    private void Update()
    {
        PlayerDataUpdate();

    }

    void PlayerDataUpdate()
    {
        StatusUpdate();
        InventoryUpdate();
    }

    void StatusUpdate()
    {
        switch (_status.Health)
        {
            case 5:
                Health = 1f;
                break;
            case 4:
                Health = 0.755f;
                break;
            case 3:
                Health = 0.565f;
                break;
            case 2:
                Health = 0.377f;
                break;
            case 1:
                Health = 0.188f;
                break;
            default:
                Health = 0f;
                break;

        }
        _healthUI.Health = _status.Health;
        _batteryUI.Battery = _status.Battery;
        _heartRateUI.Scary = _status.IsScary;
        
    }

    void InventoryUpdate()
    {
        _invenUI.SelectSlot = _inventory.SelectItem;
        _invenUI.InventorySize = _inventory.list.Count;
        _compass.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, _player.transform.eulerAngles.y);
        _invenUI.TotalItem = _inventory.TotalItem;


    }

}