using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public int Health;


    public Image image;

    private void Update()
    {
        image.fillAmount = (float)Health / 5f;
    }
}
