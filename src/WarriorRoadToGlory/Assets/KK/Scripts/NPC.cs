using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NPC : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    
    private List<Animator> _animators;
    private AudioSource _audioSource;
    private Random rand;
    public static int defeatedEnemy;
    public static int amountHit;

    private void Awake()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        rand = new Random();
        _audioSource = GetComponent<AudioSource>();
        defeatedEnemy = 0;
    }

    private void Update()
    {
        if (defeatedEnemy >= 3)
        {
            foreach (var anim in _animators)
            {
                anim.SetTrigger("Clap");
            }
            _audioSource.PlayOneShot(_audioClips[rand.Next(0, _audioClips.Length)]);
            defeatedEnemy = 0;
        }

        if (amountHit >= 3)
        {
            foreach (var anim in _animators)
            {
                anim.SetTrigger("Clap");
            }
            _audioSource.PlayOneShot(_audioClips[rand.Next(0, _audioClips.Length)]);
            amountHit = 0;
        }
    }
}
