using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] public float _enemyHp = 100;
    [SerializeField] private float _weapon1Damage;
    [SerializeField] private float _weapon2Damage;
    [SerializeField] private float _weapon3Damage;
    [SerializeField] private float _multiplyForHP = 1.3f;
    public GameObject[] hitEffects = new GameObject[1];
    public const string weaponTag1 = "StartSword";
    public const string weaponTag2 = "UpgradedSword";
    public const string weaponTag3 = "TheBestSword";
    private Animation anim;
    GameObject enemy;
    GameObject _hitEffectClone;
    bool _sentinel = false;

    private int difficult;
    private Weapon _weapon;
    
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
                _enemyHp -= _weapon1Damage;
                break;

            case weaponTag2:
                _enemyHp -= _weapon2Damage;
                break;

            case weaponTag3:
                _enemyHp -= _weapon3Damage;
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
}
