using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject _midPointVisual, _arrowPrefab, _arrowSpawnPoint;
    [SerializeField] private float _arrowMaxSpeed = 10f;
    
    
    public void PrepareArrow()
    {
        _midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        _midPointVisual.SetActive(false);

        GameObject arrow = Instantiate(_arrowPrefab);
        arrow.transform.position = _arrowSpawnPoint.transform.position;
        arrow.transform.rotation = _arrowSpawnPoint.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(_midPointVisual.transform.forward * strength * _arrowMaxSpeed, ForceMode.Impulse);
    }
}
