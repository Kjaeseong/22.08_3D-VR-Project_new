using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRate : MonoBehaviour
{
    public RawImage image;                        //판네의 이미지 값을 참조할 이미지 UI
    public Canvas _canvas;
    public float AlphaDownSpeed = 0.01f;
    public float AlphaUpSpeed = 0.01f;
    public bool DirectionDown;

    private Color _color;
    public float CoolTime;
    public float ResetCoolTime = 1f;
    public bool _canDirChange;


    void Start()
    {
        image = GetComponent<RawImage>();
    }

    void Update()
    {


        if (_color.a <= 0)
        {
            CoolTime -= Time.deltaTime;
        }
        if (CoolTime <= 0)
        {
            if (_color.a <= 0)
            {
                CoolTime = ResetCoolTime;
                DirectionDown = false;
            }
            else if (_color.a >= 1)
            {
                DirectionDown = true;
            }

            if (DirectionDown == false)
            {
                _color.a += AlphaUpSpeed;
            }
            else
            {
                _color.a -= AlphaDownSpeed;
            }
            image.color = _color;
        }



    }



    void AddAlpha()
    {
        

    }



}
