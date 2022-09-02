using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private PlayerInput _input;
    public RaycastHit hit;
    public GameObject MissionObject;
    public Outline MissionObjectOutLine;
    [Range(0, 5)] public float MaxDistance;
    



    void Start()
    {
        _input = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.red, 0.3f);
        //

        Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance);
        if(hit.transform != null)
        {
            if(hit.transform.tag == "MissionObject")
            {
                MissionObject = hit.transform.GetComponent<GameObject>();
                MissionObjectOutLine = MissionObject.GetComponent<Outline>();
                MissionObjectOutLine.enabled = true;
                    
                

                if(_input.MouseL)
                {

                    Debug.Log($"--------");

                }

            }
            else
            {
                MissionObjectOutLine.enabled = false;
                MissionObject = null;
                MissionObjectOutLine = null;
            }
        }
    }
}
