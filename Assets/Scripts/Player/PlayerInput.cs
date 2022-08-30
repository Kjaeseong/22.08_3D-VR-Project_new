using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject GameCam;
    //public GameObject VR;

    // Rotate
    public float Rotate_x;
    public float Rotate_y;

    // Move
    public float x;
    public float z;

    // Flash On/Off
    public bool F;

    // Run
    public bool LShift;

    // Action
    public bool Space;

    // Item Slot
    public bool Num1;
    public bool Num2;
    public bool Num3;
    public bool Num4;
    public bool Num5;

    // Pause
    public bool P;


    // Item Slot Select For VR
    public bool VR_UseItem;

    public int VR_ScrollNum;
    private bool VR_ScrollButton;

    void Update()
    {   
        ChangeController();

        if(GameManager.Instance.UseVR == false)
        {
            keyboardInput();
            Debug.Log($"-키보드 사용-");
        }
        else
        {
            VRInput();
            Debug.Log($"-VR 사용-");
        }
    }

    void ChangeController()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.UseVR = false;
            GameCam.SetActive(true);
            //VR.SetActive(false);
            Debug.Log($"-키보드 조작 전환-");
        }
         
        if(OVRInput.GetDown(OVRInput.Button.Four))
        {
            GameManager.Instance.UseVR = true;
            //VR.SetActive(true);
            GameCam.SetActive(false);
            Debug.Log($"-VR 조작 전환-");
        }

    }

    void keyboardInput()
    {
        PlayerRotate();
        PlayerMove();
        Controll();
        Item();
        PauseUI();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void VRInput()
    {
        VR_PlayerRotate();
        VR_PlayerMove();
        VR_Controll();
        VR_Item();
        VR_PauseUI();
    }


    void PlayerMove()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

    }

    void PlayerRotate()
    {
        Rotate_y = Input.GetAxis("Mouse X");
        Rotate_x = -Input.GetAxis("Mouse Y");

    }

    void Item()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))   { Num1 = true; }    else { Num1 = false; }
        if (Input.GetKeyDown(KeyCode.Alpha2))   { Num2 = true; }    else { Num2 = false; }
        if (Input.GetKeyDown(KeyCode.Alpha3))   { Num3 = true; }    else { Num3 = false; }
        if (Input.GetKeyDown(KeyCode.Alpha4))   { Num4 = true; }    else { Num4 = false; }
        if (Input.GetKeyDown(KeyCode.Alpha5))   { Num5 = true; }    else { Num5 = false; }
    }

    void Controll()
    {
        if (Input.GetKeyDown(KeyCode.F))        { F = true; }       else { F = false; }
        if (Input.GetKey(KeyCode.LeftShift))    { LShift = true; }  else { LShift = false; }
        if (Input.GetKey(KeyCode.Space))        { Space = true; }   else { Space = false; }
    }

    void PauseUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) { P = true; } else { P = false; }
    }




    void VR_PlayerRotate()
    {
        if(OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            Vector2 RightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

            Rotate_x = RightStick.x;
            Rotate_y = RightStick.y;

            Debug.Log($"-X축 회전 : {Rotate_x}-");
            Debug.Log($"-Y축 회전 : {Rotate_y}-");

            //테스트 언제해보냐...ㅅㅂ
        }

    }
    void VR_PlayerMove()
    {
        if(OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 LeftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            x = LeftStick.x;
            z = LeftStick.y;

            Debug.Log($"-X축 이동 : {x}-");
            Debug.Log($"-Y축 이동 : {z}-");
        }
    }

    void VR_Controll()
    {
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.5)
        {
            Debug.Log($"-뛰기 버튼 눌림-");
        }

        if(OVRInput.GetDown(OVRInput.Button.Two))
        {
            Debug.Log($"-손전등 눌림-");
        }

        if(OVRInput.Get(OVRInput.Button.Four))
        {
            Debug.Log($"-상호작용/선택 키 눌림-");
        }

    }
    void VR_Item()
    {
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log($"-아이템 선택버튼 눌림-");
        }

        if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.5)
        {
            Debug.Log($"-아이템 사용 버튼 눌림-");
        }

    }
    void VR_PauseUI()
    {
        if(OVRInput.GetDown(OVRInput.Button.Three))
        {
            Debug.Log($"-Pause 버튼 눌림-");
        }

    }





}
