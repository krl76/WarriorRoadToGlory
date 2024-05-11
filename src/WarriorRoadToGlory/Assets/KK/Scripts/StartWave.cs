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
    private InLocation inLocation;
    private bool inTrigger = false;
    public bool inWave = false;

    private void Awake()
    {
        inputController = new InputController();

        inputController.LeftHand.Interact.started += ctx => WaveStart();

        inLocation = _inLocationObject.GetComponent<InLocation>();
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

    private void Update()
    {
        if (inLocation.onMain)
        {
            animator.SetTrigger("isClose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
            _interactCanvas.SetActive(true);
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

    private void WaveStart()
    {
        if (inTrigger)
        {
            inWave = true;
            _interactCanvas.SetActive(false);
            animator.SetTrigger("isOpen");
        }
    }
}
