using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _speed;
    
    private InputController inputController;
    private CharacterController characterController;
    private Transform transform;


    private void Awake()
    {
        inputController = new InputController();
        characterController = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
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
        characterController.Move(movement * _speed * Time.deltaTime);

        //Quaternion rotcam = inputController.LeftHand.RotationCam.ReadValue<Quaternion>();
        //transform.rotation = rotcam;
    }
}
