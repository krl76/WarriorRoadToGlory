using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _camSpeed;
    
    private InputController inputController;
    private CharacterController characterController;
    private Transform transformCam;


    private void Awake()
    {
        inputController = new InputController();
        characterController = GetComponent<CharacterController>();
        transformCam = _camera.GetComponent<Transform>();
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

        Vector2 move = inputController.RightHand.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(move.x, 0, move.y);
        characterController.Move(movement * _playerSpeed * Time.deltaTime);

        Vector2 rotation = inputController.LeftHand.RotationCam.ReadValue<Vector2>();
        Vector3 camRot = new Vector3(rotation.x, rotation.y, 0);
        transformCam.localEulerAngles = camRot;
    }
}
