using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    public Sprite IconFile;
    private Image _image;


    private void Start()
    {
        _image = GetComponentInParent<Image>();
    }

    private void Update()
    {
        _image.sprite = IconFile;
    }
}
