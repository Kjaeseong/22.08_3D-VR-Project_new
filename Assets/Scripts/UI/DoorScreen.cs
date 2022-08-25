using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorScreen : MonoBehaviour
{
    public Image BackGround;
    public TextMeshProUGUI Text;

    public bool Visited;
    public bool MissionAllClear;
    public bool InsideCollider;

    private bool PrintText;
    private bool TextAlphaDirection;


    private void Update()
    {
        ScreenSwitch();
        ScreenAlpha();
        
    }

    void ScreenSwitch()
    {
        if (InsideCollider == true)
        {
            if (Visited == true && MissionAllClear == false)
            {
                ScreenOn();
            }
            else 
            {
                
                ScreenOff();
            }
        }
        else
        {
            ScreenOff();
        }
    }

    void ScreenOn()
    {
        if (BackGround.fillAmount <= 1)
        {
            BackGround.fillAmount += 0.1f;
            Debug.Log($"배경 필어마운트 올림");
        }

        if (BackGround.fillAmount >= 1)
        {
            Debug.Log($"텍스트 켜라");
            PrintText = true;
        }
    }

    void ScreenOff()
    {
        PrintText = false;

        if (BackGround.fillAmount >= 0)
        {
            Debug.Log($"필어마운트 내려라");
            BackGround.fillAmount -= 0.1f;
        }

        if (BackGround.fillAmount <= 0)
        {
            Debug.Log($"꺼라");
            gameObject.SetActive(false);
        }


           

    }

    void ScreenAlpha()
    {
        Color color = Text.color;

        if (PrintText == true)
        {
            if (TextAlphaDirection == false)
            {
                color.a += 0.05f;
            }
            else
            {
                color.a -= 0.05f;
            }

            if (color.a >= 1)
            {
                TextAlphaDirection = true;
            }
            else if (color.a <= 0)
            {
                TextAlphaDirection = false;
            }
        }
        else
        {
            color.a = 0f;
        }

        Text.color = color;
    }











}
