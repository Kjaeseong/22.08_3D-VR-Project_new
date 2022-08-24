using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBanner : MonoBehaviour
{
    public bool IsSelect;
    public Image image;

    private void Update()
    {
        Color _color = image.color;

        if (IsSelect == true)
        {
            _color = new Color(183f / 255f, 183f / 255f, 183f / 255f);
        }
        else
        {
            _color = new Color(56f / 255f, 56f / 255f, 56f / 255f);
        }

        image.color = _color;
    }
}