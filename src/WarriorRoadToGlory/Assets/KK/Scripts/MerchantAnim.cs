using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantAnim : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        StartCoroutine(TakePause());
    }
    
    IEnumerator TakePause()
    {
        yield return new WaitForSeconds(10);
        _animator.SetTrigger("AfterTime");
    }
}
