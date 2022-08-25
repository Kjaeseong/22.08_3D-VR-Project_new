using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScope : MonoBehaviour
{
    public RectTransform _transform;
    private void Update()
    {
       _transform.Rotate(0f, 0.05f, 0f);
    }
}
