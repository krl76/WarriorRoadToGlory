using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    private StartWave startWave;

    public bool inWave;

    private void Awake()
    {
        startWave = _door.GetComponent<StartWave>();
    }

    private void Update()
    {
        inWave = startWave.inWave;
    }
}
