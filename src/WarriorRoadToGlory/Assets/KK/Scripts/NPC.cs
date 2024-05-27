using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private List<Animator> _animators;

    private SoundViewers _soundViewers;
    public int defeatedEnemy;
    public int amountHit;

    private void Awake()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        _soundViewers = FindObjectOfType<SoundViewers>();
        defeatedEnemy = 0;
        amountHit = 0;
    }

    private void Update()
    {
        if (defeatedEnemy >= 3)
        {
            foreach (var anim in _animators)
            {
                anim.SetTrigger("Clap");
            }
            _soundViewers.TwoRandom();
            defeatedEnemy = 0;
        }

        if (amountHit >= 3)
        {
            foreach (var anim in _animators)
            {
                anim.SetTrigger("Clap");
            }
            _soundViewers.TwoRandom();
            amountHit = 0;
        }
    }
}
