using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NPC : MonoBehaviour
{
    private List<Animator> _animators;

    private SoundViewers _soundViewers;
    private Random rand;
    public static int defeatedEnemy;
    public static int amountHit;

    private void Awake()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        _soundViewers = FindObjectOfType<SoundViewers>();
        rand = new Random();
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
