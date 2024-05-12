using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : MonoBehaviour
{
    [SerializeField] private GameObject _interactCanvas;
    [SerializeField] private GameObject _inLocationObject;

    private InputController inputController;
    private Animator animator;
    private bool inTrigger = false;
    private bool isOpen = false;

    private void Awake()
    {
        inputController = new InputController();

        inputController.LeftHand.Interact.started += ctx => DoorOpen();
        
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isOpen)
            {
                inTrigger = true;
                _interactCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
            _interactCanvas.SetActive(false);
        }
    }

    private void DoorOpen()
    {
        if (inTrigger)
        {
            isOpen = true;
            _interactCanvas.SetActive(false);
            animator.SetTrigger("isOpen");
        }
    }
}
