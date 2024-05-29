using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantAnim : MonoBehaviour
{
    private Animator _animator;
    private bool _isPause;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isPause)
        {
            StartCoroutine(TakePause());
            _isPause = true;
        }
    }
    
    IEnumerator TakePause()
    {
        yield return new WaitForSeconds(10);
        _animator.SetTrigger("AfterTime");
        _isPause = false;
    }
}
