using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Rotate
    public float Rotate_x;
    public float Rotate_y;

    // Move
    public float x;
    public float z;

    // Controll
    public bool F;
    public bool LShift;
    public bool Space;
    public bool MouseL;

    //Item
    public bool Num1;
    public bool Num2;
    public bool Num3;
    public bool Num4;
    public bool Num5;

    // Pause
    public bool P;


    void Update()
    {
        PlayerRotate();
        PlayerMove();
        Controll();
        Item();
        PauseUI();
        Cursor.lockState = CursorLockMode.Locked;


        
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
        if (Input.GetMouseButton(0))            { MouseL = true; }  else { MouseL = false; }
    }

    void PauseUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) { P = true; } else { P = false; }
    }






}
