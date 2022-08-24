using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRateUI : MonoBehaviour
{
    public int Scary;

    [Range(0, 5)]
    public float CoolTime;
    public float CoolTime_def;

    [Range(0, 10)]
    public float FadeOutSpeed;

    [Range(0, 10)]
    public float SlideSpeed = 1.5f;

    private bool _canStart = true;

    public Image image;

    private void Awake()
    {
        CoolTime_def = CoolTime;

    }


    private void Update()
    {
        Slide();
        FadeOut();
        Reset();

        HeartSpeedStep(Scary);
        ColorChange(Scary);
 
    }

    void Slide()
    {
        if (_canStart == true)
        {
            image.fillAmount += SlideSpeed * Time.deltaTime;
        }
    }

    void FadeOut()
    {
        if (image.fillAmount >= 1)
        {
            _canStart = false;
            CoolTime -= Time.deltaTime;

            Color color = image.color;
            color.a -= FadeOutSpeed * Time.deltaTime;
            image.color = color;
        }
        
    }

    void Reset()
    {
        if (CoolTime <= 0)
        {
            _canStart = true;
            CoolTime = CoolTime_def;

            image.fillAmount = 0;
            Color color = image.color;
            color.a = 1;
            image.color = color;
        }
    }

    void HeartSpeedStep(int scary)
    {
        switch (scary)
        {
            case 0:
                CoolTime_def = 0.8f;
                SlideSpeed = 1.3f;
                FadeOutSpeed = 1.5f;
                break;
            case 1:
                CoolTime_def = 0.65f;
                SlideSpeed = 1.5f;
                FadeOutSpeed = 1.5f;
                break;
            case 2:
                CoolTime_def = 0.5f;
                SlideSpeed = 1.7f;
                FadeOutSpeed = 1.7f;
                break;
            case 3:
                CoolTime_def = 0.3f;
                SlideSpeed = 2f;
                FadeOutSpeed = 2f;
                break;
            case 4:
                CoolTime_def = 0.15f;
                SlideSpeed = 2.4f;
                FadeOutSpeed = 2.4f;
                break;
            case 5:
                CoolTime_def = 0.1f;
                SlideSpeed = 3f;
                FadeOutSpeed = 3f;
                break;
        }
    }

    void ColorChange(int scary)
    {
        Color color = image.color;

        switch (scary)
        {
            case 0:
                color = new Color(115f / 255f, 183f / 255f, 122f / 255f);
                break;
            case 1:
                color = new Color(181f / 255f, 183f / 255f, 115f / 255f);
                break;
            case 2:
                color = new Color(183f / 255f, 170f / 255f, 115f / 255f);
                break;
            case 3:
                color = new Color(183f / 255f, 130f / 255f, 115f / 255f);
                break;
            case 4:
                color = new Color(200f / 255f, 86f / 255f, 79f / 255f);
                break;
            case 5:
                color = new Color(238f / 255f, 40f / 255f, 29f / 255f);
                break;
        }

        image.color = color;
    }

}
