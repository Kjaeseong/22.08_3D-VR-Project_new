using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameEnd
{ 
    RETRY = 1,
    MAINTITLE

}

public class GameEndUI : MonoBehaviour
{
    public int MenuSelect;      // 1, 2, 3;
    public float a = 8f;

    public int ScrollRange = 2;

    public Button Retry;
    public Button MainMenu;

    public InGameUI InGameUI;
    public TextMeshProUGUI GameEndText;


    private void Update()
    {
        MenuScroll();
        SelectEffect(MenuSelect);
        Select();
        BackGroundText();
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
            if (MenuSelect == (int)GameEnd.RETRY)
            {
                SelectRetry();
            }
            if (MenuSelect == (int)GameEnd.MAINTITLE)
            {
                SelectMainMenu();
            }

        }
    }

    void SelectEffect(int select)
    {
        switch (select)
        {
            case (int)GameEnd.RETRY:
                Retry.IsSelect = true;
                MainMenu.IsSelect = false;
                break;
            case (int)GameEnd.MAINTITLE:
                Retry.IsSelect = false;
                MainMenu.IsSelect = true;
                break;
        }
    }

    void BackGroundText()
    {
        if (InGameUI.StageClear == true)
        {
            GameEndText.text = "Stage Clear";
        }

        if (InGameUI.GameOver == true)
        {
            GameEndText.text = "Game Over";
        }
    }

    private void SelectMainMenu()
    {
        SceneChanger.Instance.Scene_Title();
    }
    private void SelectRetry()
    {
        SceneChanger.Instance.Scene_InGame();
        //GameManager.Instance.RoadGameDate();
        gameObject.SetActive(false);
    }
}
