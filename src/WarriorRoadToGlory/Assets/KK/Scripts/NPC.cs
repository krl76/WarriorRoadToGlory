using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Animator _animator;
    public static int defeatedEnemy;
    public static int amountHit;

    private void Awake()
    {
        defeatedEnemy = 0;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (defeatedEnemy >= 3)
        {
            _animator.SetTrigger("Clap");
            defeatedEnemy = 0;
        }

        if (amountHit >= 3)
        {
            _animator.SetTrigger("Clap");
            amountHit = 0;
        }
    }
}
