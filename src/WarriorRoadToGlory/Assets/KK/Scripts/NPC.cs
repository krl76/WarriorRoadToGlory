using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private List<Animator> _animators;

    private SoundViewers _soundViewers;
    public int defeatedEnemy;
    public int amountHit;
    private bool _isPause;
    private bool _isPause2;
    private bool _inWave;

    private void Awake()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        _soundViewers = FindObjectOfType<SoundViewers>();
        defeatedEnemy = 0;
        amountHit = 0;
    }

    private void Update()
    {
        _inWave = FindObjectOfType<WaveManager>().inWave;
        
        if (defeatedEnemy >= 2)
        {
            if (!_isPause)
            {
                foreach (var anim in _animators)
                {
                    anim.SetTrigger("Clap");
                }
                _soundViewers.TwoRandom();
                _isPause = true;
                StartCoroutine(Pause());
            }
            defeatedEnemy = 0;
        }

        if (!_isPause2 && _inWave)
        {
            _soundViewers.OneRandom();
            _isPause2 = true;
            StartCoroutine(Pause2());
        }

        /*if (amountHit >= 3)
        {
            foreach (var anim in _animators)
            {
                anim.SetTrigger("Clap");
            }
            _soundViewers.TwoRandom();
            amountHit = 0;
        }*/
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(4);
        _isPause = false;
    }
    
    IEnumerator Pause2()
    {
        yield return new WaitForSeconds(4);
        _isPause2 = false;
    }
}
