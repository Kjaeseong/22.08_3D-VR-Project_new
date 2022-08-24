using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Move
    public int x;
    public int z;

    // Controll
    public bool F;
    public bool LShift;
    public bool Space;

    //Item
    public bool Num1;
    public bool Num2;
    public bool Num3;
    public bool Num4;
    public bool Num5;

    // Interface
    public bool ESC;
    public bool P;

    //For Test
    public bool O;

    void Update()
    {
        Controll();
        Item();
        Interface();
        test();
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

    void test()
    {

        if (Input.GetKeyDown(KeyCode.O)) 
        { 
            O = true;
            GameManager.Instance.DestroyGameData();
        } 
        else 
        { 
            O = false; 
        }
    }

    void Interface()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))   { ESC = true; }     else { ESC = false; }
        if (Input.GetKeyDown(KeyCode.P))        { P = true; }       else { P = false; }
    }

    private void Pause()
    {
        if (ESC == true || P == true)
        { 
            
        }
    }


}
