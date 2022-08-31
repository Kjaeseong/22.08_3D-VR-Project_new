using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTitleUI : MonoBehaviour
{
    public int MenuSelect;

    public TitleBanner _Start;
    public TitleBanner Exit;

    public GameObject MainCamera;
    public GameObject VRCamera;
    public TitleUI MainUI;

    private float AxisY = 8f;
    private bool SelectKey;
    public bool UseVR;

    private void Update()
    {
        InputKey();
        SelectEffect(MenuSelect);
        Cursor.lockState = CursorLockMode.Locked;
        
        if(SelectKey)
        {
            if (MenuSelect == 1)
            {
                SceneChanger.Instance.Scene_InGame();
            }
            else if (MenuSelect == 2)
            {
                Application.Quit();
            }
        }
    }

    void SelectEffect(int select)
    {
        switch (select)
        {
            case 1:
                _Start.IsSelect = true;
                Exit.IsSelect = false;
                break;
            case 2:
                _Start.IsSelect = false;
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

        if(UseVR == false)
        {
            MainUI.UseVR = UseVR;
            MainCamera.SetActive(true);
            VRCamera.SetActive(false);
        }

    }
}
