using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionMachineUI : MonoBehaviour
{
    public MissionMachine _machine;
    public Image _image;
    

    private void Update()
    {
        _image.fillAmount = _machine.WaitingTime / _machine.TotalTime;
    }

}
