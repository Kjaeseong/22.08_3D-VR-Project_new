using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject MainCam;
    public GameObject VRCam;
    
    // Rotate
=======
    // Keyboard
>>>>>>> 95ca876 (Test: Oculus Input Test Code)
    public float Rotate_x;
    public float Rotate_y;
    public float x;
    public float z;
<<<<<<< HEAD

    // Flash On/Off
=======
>>>>>>> 95ca876 (Test: Oculus Input Test Code)
    public bool F;

    // Run
    public bool LShift;

    // Action
    public bool Space;
<<<<<<< HEAD

    // Item Slot
=======
>>>>>>> 95ca876 (Test: Oculus Input Test Code)
    public bool Num1;
    public bool Num2;
    public bool Num3;
    public bool Num4;
    public bool Num5;
<<<<<<< HEAD

    // UI
=======
>>>>>>> 95ca876 (Test: Oculus Input Test Code)
    public bool P;
    public bool Enter;


    // Item Slot Select For VR
    public bool VR_UseItem;

    public int VR_ScrollNum;
    private bool VR_ScrollButton;

    public float VR_Rotate_x;   //  우측 아날로그_시점 조정
    public float VR_Rotate_y;   //  우측 아날로그
    public float VR_x;  //  좌측 아날로그_이동
    public float VR_z;  //  좌측 아날로그
    public bool VR_A;       //아이템 사용
    public bool VR_B;       //아이템 선택 취소
    public bool VR_X;       //상호작용 / 선택
    public bool VR_Y;       //플래시
    public bool VR_PIndexTrigger;   //달리기
    public bool VR_Reserved; // Pause
    public bool VR_PHandTrigger;    //  아이템 선택 왼쪽
    public bool VR_SHandTrigger;    //  아이템 선택 오른쪽


    void Update()
    {   
        ChangeController();

        if(GameManager.Instance.UseVR == false)
        {
            keyboardInput();
            Debug.Log($"-키보드 사용-");
            Debug.Log($"-키보드 조작 전환-");
        }
        else
        {
            VRInput();
            Debug.Log($"-VR 사용-");
            Debug.Log($"-VR 조작 전환-");
        }
    }

    void ChangeController()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.UseVR = false;

        }
         
        if(OVRInput.GetDown(OVRInput.Button.Four))
        {
            GameManager.Instance.UseVR = true;

        }

    }

    void keyboardInput()
    {
<<<<<<< HEAD
        PlayerRotate();
        PlayerMove();
        Controll();
        Item();
        UI();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void VRInput()
    {
        VR_PlayerRotate();
        VR_PlayerMove();
        VR_Controll();
        VR_Item();
        VR_UI();
    }


    void PlayerMove()
=======
        KeyboardInput();
        Cursor.lockState = CursorLockMode.Locked;
        VRInput();



/*
        if(GameManager.Instance.keyboard_Controll == true)
        {
            
        }
        else
        {
            
        }


*/
        
    }

    void KeyboardInput()
    {
        keyboard_PlayerRotate();
        keyboard_PlayerMove();
        keyboard_Controll();
        keyboard_Item();
        keyboard_PauseUI();
    }

    void keyboard_PlayerMove()
>>>>>>> 95ca876 (Test: Oculus Input Test Code)
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

    }

    void keyboard_PlayerRotate()
    {
        Rotate_y = Input.GetAxis("Mouse X");
        Rotate_x = -Input.GetAxis("Mouse Y");

    }

    void keyboard_Item()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))   { Num1 = true; }    else { Num1 = false; }
        if (Input.GetKeyDown(KeyCode.Alpha2))   { Num2 = true; }    else { Num2 = false; }
        if (Input.GetKeyDown(KeyCode.Alpha3))   { Num3 = true; }    else { Num3 = false; }
        if (Input.GetKeyDown(KeyCode.Alpha4))   { Num4 = true; }    else { Num4 = false; }
        if (Input.GetKeyDown(KeyCode.Alpha5))   { Num5 = true; }    else { Num5 = false; }
    }

    void keyboard_Controll()
    {
        if (Input.GetKeyDown(KeyCode.F))        { F = true; }       else { F = false; }
        if (Input.GetKey(KeyCode.LeftShift))    { LShift = true; }  else { LShift = false; }
        if (Input.GetKey(KeyCode.Space))        { Space = true; }   else { Space = false; }
    }

<<<<<<< HEAD
    void UI()
=======
    void keyboard_PauseUI()
>>>>>>> 95ca876 (Test: Oculus Input Test Code)
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) { P = true; } else { P = false; }
        if (Input.GetMouseButtonDown(0)) { Enter = true; } else { Enter = false; }
    }

    void VRInput()
    {
        VR_PlayerRotate();
        VR_PlayerMove();
        VR_Controll();
        VR_Item();
        VR_PauseUI();
    }

    void VR_PlayerRotate()
    {
        if(OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

            VR_Rotate_x = thumbstick.x;
            VR_Rotate_y = thumbstick.y;

            Debug.Log($"-{VR_Rotate_x}-");
            Debug.Log($"-{VR_Rotate_y}-");

            //테스트 언제해보냐...
        }

    }
    void VR_PlayerMove()
    {


    }
    void VR_Controll()
    {
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log($"-입력 테스트코드(A)-");
        }

    }
    void VR_Item()
    {


    }
    void VR_PauseUI()
    {


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
            LShift = true;
            Debug.Log($"-뛰기 버튼 눌림-");
        }
        else
        {
            LShift = false;
        }

        if(OVRInput.GetDown(OVRInput.Button.Two))
        {
            F = true;
            Debug.Log($"-손전등 눌림-");
        }
        else
        {
            F = false;
        }

        if(OVRInput.Get(OVRInput.Button.Four))
        {
            Space = true;
            Debug.Log($"-상호작용키 눌림-");
        }
        else
        {
            Space = false;
        }

    }
    void VR_Item()
    {
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            VR_ScrollButton = true;
            Debug.Log($"-아이템 선택버튼 눌림-");
        }
        else
        {
            VR_ScrollButton = false;
        }

        if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.5)
        {
            VR_UseItem = true;
            Debug.Log($"-아이템 사용 버튼 눌림-");
        }
        else
        {
            VR_UseItem = false;
        }

    }
    void VR_UI()
    {
        if(OVRInput.GetDown(OVRInput.Button.Three))
        {
            P = true;
            Debug.Log($"-Pause 버튼 눌림-");
        }
        else
        {
            P = false;
        }

        if(OVRInput.GetDown(OVRInput.Button.Start))
        {
            Enter = true;
            Debug.Log($"-스타트(엔터)버튼 눌림-");
        }
        else
        {
            Enter = false;
        }

    }





}
