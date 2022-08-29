using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DetectionTarget : MonoBehaviour
{
    [Range(0, 100)]
    public float viewArea = 40f;
    [Range(0, 360)]
    public float viewAngle = 90f;

    private ZombieSpawner _spawner;

    public LayerMask targetMask;

    private float _minDistance;
    public Transform SelectTarget;
    private PlayerStatus _player;

    public Transform Target;
    public float Distance;
    public int ColliderSize;

    [HideInInspector]
    public List<Transform> Targets = new List<Transform>();


    private void Start()
    {
        _spawner = GameObject.Find("ZombieSpawner").GetComponent<ZombieSpawner>();
    }

    void Update()
    {
        GetTarget();
        Angry();
    }

    public void GetTarget()
    {
        ClearTarget();

        Collider[] TargetCollider = Physics.OverlapSphere(transform.position, viewArea, targetMask);
        ColliderSize = TargetCollider.Length;
        for (int i = 0; i < TargetCollider.Length; i++)
        {

            Debug.Log($"{TargetCollider[i].tag}");

            Target = TargetCollider[i].transform;
            Vector3 direction = Target.position - transform.position;


            if (Vector3.Dot(direction.normalized, transform.forward) > GetAngle(viewAngle / 2).z)
            {
                InsideEyesight();
            }
            if (SelectTarget == null)
            {
                OutsideEyesight(); 

            }
        }

    }
    void InsideEyesight()
    {
        Targets.Add(Target);
        Distance = Vector3.Distance(transform.position, Target.position);
        if (Distance < _minDistance)
        {
            _minDistance = Distance;
            SelectTarget = Target;
            _player = Target.GetComponent<PlayerStatus>();
        }
    }

    void OutsideEyesight()
    {
        if (Target.tag == "FieldItem")
        {
            SelectTarget = Target;



        }
        else if (Target.tag == "Player")
        {
            _player = Target.GetComponent<PlayerStatus>();
            if (_player.IsMoving == true && _player.IsRunning == true)
            {
                SelectTarget = Target;
            }
        }
    }

    void ClearTarget()
    {
        SelectTarget = null;
        _player = null;
        Target = null;
        _minDistance = viewArea;
        Distance = 0f;
        Targets.Clear();
    }

    void Angry()
    {
        if (_spawner.Phase == 5)
        {
            viewArea = 500;
        }
    }

    public Vector3 GetAngle(float AngleInDegree)
    {
        return new Vector3(Mathf.Sin(AngleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(AngleInDegree * Mathf.Deg2Rad));
    }
    /*
    private void OnDrawGizmos()
    {
        Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, 360, viewArea);
        //Handles.DrawLine(transform.position, transform.position + GetAngle(-viewAngle / 2) * viewArea);
        //Handles.DrawLine(transform.position, transform.position + GetAngle(viewAngle / 2) * viewArea);

        foreach (Transform Target in Targets)
        {
            Handles.DrawLine(transform.position, Target.position);
        }
    }
    */
}