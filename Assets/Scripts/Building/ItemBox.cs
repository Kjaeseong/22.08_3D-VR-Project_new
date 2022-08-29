using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private PlayerInventory _inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _inventory = other.GetComponent<PlayerInventory>();
            if (_inventory.list.Count < _inventory.Size + 1)
            {
                _inventory.list.Add(Random.Range(1, FileManager.Instance.Icon.Count + 1));
                gameObject.SetActive(false);
            }
        }
    }

}
