using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NPC : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    
    private Animator _animator;
    private AudioSource _audioSource;
    private Random rand;
    public static int defeatedEnemy;
    public static int amountHit;

    private void Awake()
    {
        rand = new Random();
        _audioSource = GetComponent<AudioSource>();
        defeatedEnemy = 0;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (defeatedEnemy >= 3)
        {
            _animator.SetTrigger("Clap");
            _audioSource.PlayOneShot(_audioClips[rand.Next(0, _audioClips.Length)]);
            defeatedEnemy = 0;
        }

        if (amountHit >= 3)
        {
            _animator.SetTrigger("Clap");
            _audioSource.PlayOneShot(_audioClips[rand.Next(0, _audioClips.Length)]);
            amountHit = 0;
        }
    }
}
