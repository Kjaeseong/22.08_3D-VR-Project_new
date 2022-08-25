using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MachineScreen : MonoBehaviour
{
    private bool _onText;
    public bool OnScreen;
    public Image Screen;
    public TextMeshProUGUI Text;

    private float _defaultFillAmount = 0f;

    private bool TextAlphaDirection;

    private void Update()
    {
        ScreenOn();
        ScreenOff();
        TextAlpha();
    }

    void ScreenOn()
    {
        if (Screen.fillAmount <= 1 && OnScreen == true)
        {
            _onText = true;
            Screen.fillAmount += 0.1f;
        }
        
    }

    void ScreenOff()
    {
        if (OnScreen == false)
        {
            _onText = false;
            Screen.fillAmount -= 0.1f;

            if (Screen.fillAmount <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void TextAlpha()
    {
        Color color = Text.color;

        if (_onText == true)
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
