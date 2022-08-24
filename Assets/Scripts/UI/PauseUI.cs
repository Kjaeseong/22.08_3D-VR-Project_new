using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Menu
{
    CONTINUE = 1,
    RETRY,    
    MAINMENU
}

public class PauseUI : MonoBehaviour
{
    public int MenuSelect;      // 1, 2, 3;
    public int Scroll;
    public float a = 8f;

    public int ScrollRange = 3;

    public Button Continue;
    public Button Retry;
    public Button MainMenu;



    private void Update()
    {
        TimePause();
        MenuScroll();
        SelectEffect(MenuSelect);
        Select();
    }

    void TimePause()
    {
        Time.timeScale = 0;
    }

    void MenuScroll()
    {
        a += -Input.GetAxis("Mouse Y");
        a = Mathf.Clamp(a, 8, 24);
        MenuSelect = (int)a / 8;
    }


    void Select()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MenuSelect == (int)Menu.CONTINUE)
            {
                Time.timeScale = 1;
                SelectContinue();
            }
            if (MenuSelect == (int)Menu.RETRY)
            {
                Time.timeScale = 1;
                SelectRetry();
            }
            if (MenuSelect == (int)Menu.MAINMENU)
            {
                Time.timeScale = 1;
                SelectMainMenu();
            }
        }
    }

    void SelectEffect(int select)
    {
        switch (select)
        {
            case (int)Menu.CONTINUE:
                Continue.IsSelect = true;
                Retry.IsSelect = false;
                MainMenu.IsSelect = false;
                break;
            case (int)Menu.RETRY:
                Continue.IsSelect = false;
                Retry.IsSelect = true;
                MainMenu.IsSelect = false;
                break;
            case (int)Menu.MAINMENU:
                Continue.IsSelect = false;
                Retry.IsSelect = false;
                MainMenu.IsSelect = true;
                break;
        }
    }

    private void SelectMainMenu()
    {
        SceneChanger.Instance.Scene_Title();
    }
    private void SelectRetry()
    {
        //리셋
        SceneChanger.Instance.Scene_InGame();
        //GameManager.Instance.RoadGameDate();
        gameObject.SetActive(false);
    }
    private void SelectContinue()
    {
        gameObject.SetActive(false);
    }
}
