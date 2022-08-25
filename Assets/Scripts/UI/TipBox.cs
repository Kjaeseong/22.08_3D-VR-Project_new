using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipBox : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _image.fillAmount += 0.05f;
        Mathf.Clamp(_image.fillAmount, 0, 1f);
    }
}
