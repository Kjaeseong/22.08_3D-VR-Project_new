using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Data
{ 

}
public class Item : MonoBehaviour
{
    public string[] ItemData = new string[7];

    public int Index;
    public string Name;
    public string Target;
    public string Subject;
    public int Effect;
    public int ActTime;
    public string Discription;

    public bool Active;

    private void Update()
    {


    }
}
