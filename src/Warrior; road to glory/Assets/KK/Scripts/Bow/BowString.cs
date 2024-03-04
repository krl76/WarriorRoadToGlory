using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BowString : MonoBehaviour
{
    [SerializeField] private Transform _end1, _end2;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        CreateString(null);
    }

    public void CreateString(Vector3? midPosition)
    {
        Vector3[] linePoints = new Vector3[midPosition == null ? 2 : 3];
        linePoints[0] = _end1.localPosition;
        if (midPosition != null)
        {
            linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
        }

        linePoints[^1] = _end2.localPosition;
        lineRenderer.positionCount = linePoints.Length;
        lineRenderer.SetPositions(linePoints);
    }
}
