using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TakeDamage : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip[] _audioClips;
    
    [Header("Effects")]
    public GameObject[] hitEffects = new GameObject[1];
    
    [Header("Sword")]
    [SerializeField] private Sword _typeOfSword;
    [SerializeField] private float _damage;

    private AudioSource _audioSource;
    private Weapon _weapon;
    private bool _sentinel;
    private GameObject _hitEffectClone;
    private bool _isPause;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _weapon = FindObjectOfType<Weapon>();

        switch (_typeOfSword)
        {
            case Sword.First:
                _damage = _weapon._weapon1Damage;
                break;
            case Sword.Second:
                _damage = _weapon._weapon2Damage;
                break;
            case Sword.Third:
                _damage = _weapon._weapon3Damage;
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!_sentinel)
            {
                if (!_isPause)
                {
                    _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
                    _isPause = true;
                    StartCoroutine(Pause());
                }

                try
                {
                    other.gameObject.GetComponent<EnemyHp>()._enemyHp -= _damage;
                }
                catch
                {
                    other.gameObject.GetComponentInChildren<EnemyHp>()._enemyHp -= _damage;
                }
                foreach (ContactPoint swordHit in other.contacts)
                {
                    Vector3 hitPoint = swordHit.point;
                    int index = Random.Range(0, hitEffects.Length);
                    _hitEffectClone = (GameObject)Instantiate(hitEffects[index], new Vector3(hitPoint.x, hitPoint.y, hitPoint.z), Quaternion.LookRotation(-other.contacts[0].normal));
                    _sentinel = true;
                }
            }
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _sentinel = false;
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.5f);
        _isPause = false;

    }

    public void Upgrade()
    {
        switch (_typeOfSword)
        {
            case Sword.First:
                _damage = _weapon._weapon1Damage;
                break;
            case Sword.Second:
                _damage = _weapon._weapon2Damage;
                break;
            case Sword.Third:
                _damage = _weapon._weapon3Damage;
                break;
        }
    }
}

enum Sword{
    First,
    Second,
    Third
}
