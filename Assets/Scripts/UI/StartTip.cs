using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTip : MonoBehaviour
{
    public GameObject StatusTipBox;
    public GameObject ItemBox;
    public GameObject TargetTipBox;
    public GameObject InventoryUI;
    public GameObject ControllKey;

    private bool _step0 = true;
    private bool _step1 = false;
    private bool _step2 = false;
    private bool _step3 = false;

    private void Update()
    {
        Time.timeScale = 0;
        Step3();
        Step2();
        Step1();
        Step0();

    }

    void Step0()
    {
        if (_step0 == true)
        {
            ControllKey.SetActive(true);
        }
        else
        {
            ControllKey.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _step0 == true)
        {
            _step0 = false;
            _step1 = true;
        }
    }

    void Step1()
    {
        if (_step1 == true)
        {
            StatusTipBox.SetActive(true);
        }
        else 
        {
            StatusTipBox.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _step1 == true)
        {
            _step1 = false;
            _step2 = true;
        }
    }

    void Step2()
    {
        if (_step2 == true)
        {
            ItemBox.SetActive(true);
            InventoryUI.SetActive(true);
        }
        else
        {
            ItemBox.SetActive(false);
            InventoryUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _step2 == true)
        {
            _step2 = false;
            _step3 = true;
        }
    }

    void Step3()
    {
        if (_step3 == true)
        {
            TargetTipBox.SetActive(true);
        }
        else
        {
            TargetTipBox.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _step3 == true)
        {
            _step3 = false;
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }

}
