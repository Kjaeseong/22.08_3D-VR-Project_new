using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    public float Battery;

    public Image image;


    void Update()
    {
        image.fillAmount = Battery / 100;
    }
}
