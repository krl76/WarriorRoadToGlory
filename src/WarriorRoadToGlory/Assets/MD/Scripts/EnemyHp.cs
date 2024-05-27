using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] public float _enemyHp = 100;
    [SerializeField] private float _weapon1Damage;
    [SerializeField] private float _weapon2Damage;
    [SerializeField] private float _weapon3Damage;
    [SerializeField] private float _multiplyForHP = 1.3f;
    public GameObject[] hitEffects = new GameObject[1];
    [SerializeField] private AudioClip[] _audioClips;
    
    public const string weaponTag1 = "StartSword";
    public const string weaponTag2 = "UpgradedSword";
    public const string weaponTag3 = "TheBestSword";
    private Animation anim;
    GameObject enemy;
    GameObject _hitEffectClone;
    bool _sentinel = false;

    private int difficult;
    private Weapon _weapon;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _weapon = FindObjectOfType<Weapon>();
        _weapon1Damage = _weapon._weapon1Damage;
        _weapon2Damage = _weapon._weapon2Damage;
        _weapon3Damage = _weapon._weapon3Damage;
        
        if (PlayerPrefs.HasKey("DifficultSettings"))
            difficult = PlayerPrefs.GetInt("DifficultSettings");
        else
            difficult = 1;
        _enemyHp = (_enemyHp * difficult) / _multiplyForHP;
    }
    private void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player hit enemy");
        switch (collision.transform.tag)
        {
            case weaponTag1:
                if (!_sentinel)
                {
                    _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
                    _enemyHp -= _weapon1Damage;
                    foreach (ContactPoint swordHit in collision.contacts)
                    {
                        Vector3 hitPoint = swordHit.point;
                        int index = Random.Range(0, hitEffects.Length);
                        _hitEffectClone = (GameObject)Instantiate(hitEffects[index], new Vector3(hitPoint.x, hitPoint.y, hitPoint.z), Quaternion.LookRotation(-collision.contacts[0].normal));
                        _sentinel = true;
                    }
                }
                break;

            case weaponTag2:
                if (!_sentinel)
                {
                    _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
                    _enemyHp -= _weapon2Damage;
                    foreach (ContactPoint swordHit in collision.contacts)
                    {
                        Vector3 hitPoint = swordHit.point;
                        int index = Random.Range(0, hitEffects.Length);
                        _hitEffectClone = (GameObject)Instantiate(hitEffects[index], new Vector3(hitPoint.x, hitPoint.y, hitPoint.z), Quaternion.LookRotation(-collision.contacts[0].normal));
                        _sentinel = true;
                    }
                }
                break;

            case weaponTag3:
                if (!_sentinel)
                {
                    _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
                    _enemyHp -= _weapon3Damage;
                    foreach (ContactPoint swordHit in collision.contacts)
                    {
                        Vector3 hitPoint = swordHit.point;
                        int index = Random.Range(0, hitEffects.Length);
                        _hitEffectClone = (GameObject)Instantiate(hitEffects[index], new Vector3(hitPoint.x, hitPoint.y, hitPoint.z), Quaternion.LookRotation(-collision.contacts[0].normal));
                        _sentinel = true;
                    }
                }
                break;
        }
        if (_enemyHp <= 0)
        {
            anim = GetComponent<Animation>();
            anim.Stop();
            WaveManager.aliveEnemies -= 1;
            NPC.defeatedEnemy += 1;
            WinCanvas.defeatedEnemy += 1;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        _sentinel = false;
    }
}
