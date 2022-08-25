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

    private bool _step1 = true;
    private bool _step2 = false;
    private bool _step3 = false;

    private void Update()
    {

        Step1();
        Step2();
        Step3();

    }

    void Step0()
    { 
        
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
        if (_step2 == true)
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
            gameObject.SetActive(false);
        }
    }

}
