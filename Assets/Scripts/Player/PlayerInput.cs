using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Keyboard
    public float Rotate_x;
    public float Rotate_y;
    public float x;
    public float z;
    public bool F;
    public bool LShift;
    public bool Space;
    public bool Num1;
    public bool Num2;
    public bool Num3;
    public bool Num4;
    public bool Num5;
    public bool P;

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

    void keyboard_PauseUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) { P = true; } else { P = false; }
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





}
