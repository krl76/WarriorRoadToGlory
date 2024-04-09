using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbsController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _power;
    private const string weaponTag = "Weapon";
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(weaponTag))
        {
            return;
        }
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up * _power);
    }
}