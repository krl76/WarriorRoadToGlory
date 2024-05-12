using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject _exitTrigger;
    private InLocation inLocation;

    public bool inWave;
    private int count;

    private void Awake()
    {
        count = 0;
        inLocation = _exitTrigger.GetComponent<InLocation>();
    }

    private void Update()
    {
        inWave = inLocation.onMain;
        if (inWave)
        {
            if (count == 0)
            {
                count += 1;
                StartWave();
            }
        }
    }

    private void StartWave()
    {
        
    }
}
