using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buttons
{ 
    START = 1,
    EXIT
}


public class TitleUI : MonoBehaviour
{
    public int MenuSelect;

    public TitleBanner Start;
    public TitleBanner Exit;

    private float AxisY = 8f;
    private bool SelectKey;
    private bool UseVR;


    private void Update()
    {
        InputKey();
        SelectEffect(MenuSelect);

        if(SelectKey)
        {
            if (MenuSelect == (int)Buttons.START)
            {
                SceneChanger.Instance.Scene_InGame();
            }
            else if (MenuSelect == (int)Buttons.EXIT)
            {
                Application.Quit();
            }
        }
    }

    void SelectEffect(int select)
    {
        switch (select)
        {
            case (int)Buttons.START:
                Start.IsSelect = true;
                Exit.IsSelect = false;
                break;
            case (int)Buttons.EXIT:
                Start.IsSelect = false;
                Exit.IsSelect = true;
                break;
        }
    }

    void InputKey()
    {
        ChangeController();
        MenuScroll();
        SelectButton();
    }

    void MenuScroll()
    {
        if(UseVR)
        {
            if(OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
            {
                Vector2 LeftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
                AxisY += LeftStick.y;

                Debug.Log($"-VR로 메뉴 스크롤-");
            }
        }
        else
        {
            AxisY += -Input.GetAxis("Mouse Y");
        }
        
        AxisY = Mathf.Clamp(AxisY, 8, 16);
        MenuSelect = (int)AxisY / 8;
    }

    void SelectButton()
    {
        if(UseVR)
        {

            Debug.Log($"-VR 조작상태-");

            if(OVRInput.GetDown(OVRInput.Button.Four))
            {
                SelectKey = true;
            }
            else
            {
                SelectKey = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SelectKey = true;
            }
            else
            {
                SelectKey = false;
            }
        }
    }

    void ChangeController()
    {
        if(UseVR)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UseVR = false;
            }
        }
        else
        {
            if(OVRInput.GetDown(OVRInput.Button.Four))
            {
                UseVR = true;
            }
        }
    }
}
