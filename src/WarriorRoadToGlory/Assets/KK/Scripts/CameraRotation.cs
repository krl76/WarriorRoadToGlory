using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _camSpeed;
    
    private InputController inputController;


    private void Awake()
    {
        inputController = new InputController();
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void Update()
    {
        Vector2 rotation = inputController.LeftHand.RotationCam.ReadValue<Vector2>();
        Vector3 rotateValue = new Vector3(rotation.x, rotation.y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        transform.eulerAngles += rotateValue * _camSpeed;
    }
}
