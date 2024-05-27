using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHp : MonoBehaviour
{
    [Header("Model Sets")]
    [SerializeField] public float _enemyHp = 100;
    [SerializeField] private float _multiplyForHP = 1.3f;
    public GameObject[] hitEffects = new GameObject[1];
    [SerializeField] private GameObject _ragdoll;
    [SerializeField] private GameObject _objectToOff;
    
    [Header("SFX")]
    [SerializeField] private AudioClip[] _audioClips;
    
    public const string weaponTag1 = "StartSword";
    public const string weaponTag2 = "UpgradedSword";
    public const string weaponTag3 = "TheBestSword";

    private NPC _npc;
    private Animator anim;
    GameObject enemy;
    GameObject _hitEffectClone;
    bool _sentinel = false;

    private int difficult;
    private Weapon _weapon;
    private AudioSource _audioSource;
    private WinCanvas _win;

    private void Awake()
    {
        _npc = FindObjectOfType<NPC>();
        _win = FindObjectOfType<WinCanvas>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        
        if (PlayerPrefs.HasKey("DifficultSettings"))
            difficult = PlayerPrefs.GetInt("DifficultSettings");
        else
            difficult = 1;
        _enemyHp = (_enemyHp * difficult) / _multiplyForHP;
    }
    private void Update()
    {
        if (_enemyHp <= 0)
        {
            anim.enabled = false;
            WaveManager.aliveEnemies -= 1;
            _npc.defeatedEnemy += 1;
            _win.defeatedEnemy += 1;
            _ragdoll.SetActive(true);
            _objectToOff.SetActive(false);
        }
    }
}
