using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject VRCam;
    

    public float Rotate_x;
    public float Rotate_y;
    public float x;
    public float z;


    // Action
    public bool F;
    public bool LShift;
    public bool Space;
    public bool Num1;
    public bool Num2;
    public bool Num3;
    public bool Num4;
    public bool Num5;
    public bool P;
    public bool Enter;

    void Update()
    {   
        KeyboardInput();
        Cursor.lockState = CursorLockMode.Locked;
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
        if (Input.GetMouseButtonDown(0)) { Enter = true; } else { Enter = false; }
    }

}