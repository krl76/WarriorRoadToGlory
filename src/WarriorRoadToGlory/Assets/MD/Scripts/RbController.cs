using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbController : MonoBehaviour
{
    private List<Rigidbody> _rigidbodies;
    void Start()
    {
        _rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        foreach (Rigidbody _rigidbody in _rigidbodies)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
