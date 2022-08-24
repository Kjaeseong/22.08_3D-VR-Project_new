using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionTitle : MonoBehaviour
{
    TextMeshProUGUI Print;
    public string ItemName;

    private void Start()
    {
        Print = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Print.text = ItemName;
        Debug.Log($"아이템 이름 : {ItemName}");
    }
}
