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
    public float a = 8f;

    public TitleBanner Start;
    public TitleBanner Exit;

    private void Update()
    {
        MenuScroll();
        SelectEffect(MenuSelect);
        Select();
    }

    void MenuScroll()
    {
        a += -Input.GetAxis("Mouse Y");
        a = Mathf.Clamp(a, 8, 16);
        MenuSelect = (int)a / 8;
    }


    void Select()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MenuSelect == (int)Buttons.START)
            {
                SelectStart();
            }
            if (MenuSelect == (int)Buttons.EXIT)
            {
                SelectExit();
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

    private void SelectStart()
    {
        SceneChanger.Instance.Scene_InGame();
    }
    private void SelectExit()
    {
        Application.Quit();
    }



}
