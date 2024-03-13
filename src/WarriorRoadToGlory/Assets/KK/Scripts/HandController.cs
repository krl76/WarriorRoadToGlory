using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] private Animator _animatorLeft;
    [SerializeField] private Animator _animatorRight;
    
    private InputController inputController;
    private void Awake()
    {
        inputController = new InputController();

        inputController.RightHand.Grip.started += ctx => Grip(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Grip.canceled += ctx => Grip(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Fist.started += ctx => Fist(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Fist.canceled += ctx => Fist(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Pointing.started += ctx => Pointing(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Pointing.canceled += ctx => Pointing(ctx.ReadValueAsButton(), "Right");
        
        inputController.LeftHand.Grip.started += ctx => Grip(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Grip.canceled += ctx => Grip(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Fist.started += ctx => Fist(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Fist.canceled += ctx => Fist(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Pointing.started += ctx => Pointing(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Pointing.canceled += ctx => Pointing(ctx.ReadValueAsButton(), "Left");
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void Grip(bool isGrip, string hand)
    {
        if (hand == "Right")
        {
            _animatorRight.SetBool("Grip", isGrip);
        }
        else
        {
            _animatorLeft.SetBool("Grip", isGrip);
        }
    }

    private void Fist(bool isFist, string hand)
    {
        if (hand == "Right")
        {
            _animatorRight.SetBool("Fist", isFist);
        }
        else
        {
            _animatorLeft.SetBool("Fist", isFist);
        }
    }
    
    private void Pointing(bool isPointing, string hand)
    {
        if (hand == "Right")
        {
            _animatorRight.SetBool("Pointing", isPointing);
        }
        else
        {
            _animatorLeft.SetBool("Pointing", isPointing);
        }
    }
}
