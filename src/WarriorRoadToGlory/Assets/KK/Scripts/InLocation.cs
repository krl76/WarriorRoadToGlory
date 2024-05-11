using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLocation : MonoBehaviour
{
    [SerializeField] private Animator _doors;
    public bool onMain;
    
    
    private void Awake()
    {
        onMain = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _doors.SetTrigger("isClose");
            onMain = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onMain = false;
        }
    }
}
