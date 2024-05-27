using System.Collections;
using UnityEngine;

public class DoorEnemy : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    
    private Animator _animator;
    private WaveManager _waveManager;
    private AudioSource _audioSource;
    
    private bool _trigger;
    private bool _trigger2;
    private int _enemyInArena;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _waveManager = FindObjectOfType<WaveManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_waveManager.inWave && !_trigger)
        {
            _audioSource.PlayOneShot(_audioClips[0]);
            _animator.SetTrigger("isOpen");
            _trigger = true;
        }

        if (!_trigger2)
        {
            switch (_waveManager.waveNumber)
            {
                case 1:
                    if (_waveManager.allSpawned && _waveManager.wave1.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
                case 2:
                    if (_waveManager.allSpawned && _waveManager.wave2.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
                case 3:
                    if (_waveManager.allSpawned && _waveManager.wave3.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
                case 4:
                    if (_waveManager.allSpawned && _waveManager.wave4.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
                case 5:
                    if (_waveManager.allSpawned && _waveManager.wave5.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
                case 6:
                    if (_waveManager.allSpawned && _waveManager.wave6.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
                case 7:
                    if (_waveManager.allSpawned && _waveManager.wave7.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
                case 8:
                    if (_waveManager.allSpawned && _waveManager.wave8.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
                case 9:
                    if (_waveManager.allSpawned && _waveManager.wave9.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
                case 10:
                    if (_waveManager.allSpawned && _waveManager.wave10.Count == _enemyInArena)
                    {
                        StartCoroutine(Pause());
                        _enemyInArena = 0;
                        _trigger2 = true;
                    }
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            _enemyInArena += 1;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        _audioSource.PlayOneShot(_audioClips[1]);
        _animator.SetTrigger("isClose");
    }
}
