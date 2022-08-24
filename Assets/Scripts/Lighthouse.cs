using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour
{
    private float _rotateSpeed = 400f;
    void Update()
    {
        transform.Rotate(0f, _rotateSpeed * Time.deltaTime, 0f);
    }
}
