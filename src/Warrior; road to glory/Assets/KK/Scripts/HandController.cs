using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{

    private InputController inputController;
    private Animator animator;
    private void Awake()
    {
        inputController = new InputController();
        animator = GetComponent<Animator>();

        inputController.RightHand.Grip.performed += ctx => Grip(ctx.ReadValueAsButton());
        inputController.RightHand.Fist.performed += ctx => Fist(ctx.ReadValueAsButton());
        inputController.RightHand.Pointing.performed += ctx => Pointing(ctx.ReadValueAsButton());
        
        inputController.LeftHand.Grip.performed += ctx => Grip(ctx.ReadValueAsButton());
        inputController.LeftHand.Fist.performed += ctx => Fist(ctx.ReadValueAsButton());
        inputController.LeftHand.Pointing.performed += ctx => Pointing(ctx.ReadValueAsButton());
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void Grip(bool isGrip)
    {
        animator.SetBool("Grip", isGrip);
    }

    private void Fist(bool isFist)
    {
        animator.SetBool("Fist", isFist);
    }
    
    private void Pointing(bool isPointing)
    {
        animator.SetBool("Pointing", isPointing);
    }
}
