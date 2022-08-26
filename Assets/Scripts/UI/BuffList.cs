using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffList : MonoBehaviour
{
    public GameObject Buff;
    public List<GameObject> _bufflist = new List<GameObject>();

    public string Name;

    public int Index;
    public string Target;
    public float ResetTime;

    public int Health;
    public float Battery;
    public float WalkSpeed;
    public float RunSpeed;
    public Image image;

    public bool buffActive;


    private void Update()
    {
        if (buffActive == true)
        {
            CreateBuff();
        }
    }

    void CreateBuff()
    {
        _bufflist.Add(Instantiate(Buff) as GameObject);
        _bufflist[_bufflist.Count - 1].transform.parent = gameObject.transform;
        _bufflist[_bufflist.Count - 1].name = "Buff " + (_bufflist.Count - 1);
        buffActive = false;
    }

}
