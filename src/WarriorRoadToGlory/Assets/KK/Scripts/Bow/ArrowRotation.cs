using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        transform.forward = Vector3.Slerp(transform.forward, _rb.velocity.normalized, Time.deltaTime);
    }
}
