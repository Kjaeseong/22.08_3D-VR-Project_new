using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Description : MonoBehaviour
{
    TextMeshProUGUI Print;
    public string ItemDescription;

    private void Start()
    {
        Print = GetComponent<TextMeshProUGUI>();
    }
    
    private void Update()
    {
        Print.text = ItemDescription;
    }
}
