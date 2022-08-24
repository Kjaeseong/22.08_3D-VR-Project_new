using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItemStatus : MonoBehaviour
{
    public int Health;
    public float ActiveTime = 0f;
    public Vector3 Position;

    private bool _haveHealth = false;
    private bool _haveActiveTime = false;
    

    private void Update()
    {

        if (Health > 0)
        {
            _haveHealth = true;
        }
        if (ActiveTime > 0)
        {
            _haveActiveTime = true;
            ActiveTime -= Time.deltaTime;
        }

        DestroyItem();

    }

    void DestroyItem()
    {
        if (Health <= 0 && _haveHealth == true)
        {
            Destroy(gameObject);
        }
        if (ActiveTime <= 0 && _haveActiveTime == true)
        {
            Destroy(gameObject);
        }
    }
}
