using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float _rotateX;

    public PlayerMovement Movement;
    public PlayerStatus Player;
    public PlayerInput Input;
    public Transform Hips;

    void Update()
    {
        if (Player.IsDie == false)
        {
            _rotateX += Input.Rotate_x * Time.deltaTime * Movement.RotateSpeed; ;

            _rotateX = Mathf.Clamp(_rotateX, -70, 40);
            transform.rotation = Movement.transform.rotation;
            transform.eulerAngles = new Vector3(_rotateX, Hips.transform.eulerAngles.y, 0f);
        }
    }
}
