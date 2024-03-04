using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringContoller : MonoBehaviour
{
    [SerializeField] private BowString _bowStringRenderer;
    [SerializeField] private Transform _midPointGrab, _midPointVisual, _midPointParent;
    [SerializeField] private float bowStringStretchLimit = 0.3f;
    
    private XRGrabInteractable interactable;
    private Transform interactor;
    private float strength;

    public UnityEvent OnBowPulled;
    public UnityEvent<float> OnBowReleases;
    private void Awake()
    {
        interactable = _midPointGrab.GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }

    private void Update()
    {
        if (interactor != null)
        {
            Vector3 midPointLocalSpace = _midPointParent.InverseTransformPoint(_midPointGrab.position);
            float midPointLocalZAbs = Mathf.Abs(midPointLocalSpace.z);
            HandleStringPushedBackToStart(midPointLocalSpace);
            HandleStringPulledBackToLimit(midPointLocalZAbs, midPointLocalSpace);
            HandlePullingString(midPointLocalZAbs, midPointLocalSpace);
            
            _bowStringRenderer.CreateString(_midPointGrab.transform.position);
        }
    }

    private void HandlePullingString(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs < bowStringStretchLimit)
        {
            strength = Remap(midPointLocalZAbs, 0, bowStringStretchLimit, 0, 1);
            _midPointVisual.localPosition = new Vector3(0, 0, midPointLocalSpace.z);
        }
    }

    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    private void HandleStringPulledBackToLimit(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs >= bowStringStretchLimit)
        {
            strength = 1;
            _midPointVisual.localPosition = new Vector3(0, 0, -midPointLocalSpace.z);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z >= 0)
        {
            strength = 0;
            _midPointVisual.localPosition = Vector3.zero;
        }
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        OnBowReleases?.Invoke(strength);
        strength = 0;
        
        interactor = null;
        _midPointGrab.localPosition = Vector3.zero;
        _midPointVisual.localPosition = Vector3.zero;
        _bowStringRenderer.CreateString(null);
    }

    private void PrepareBowString(SelectEnterEventArgs arg0)
    {
        interactor = arg0.interactableObject.transform;
        OnBowPulled?.Invoke();
    }
}
