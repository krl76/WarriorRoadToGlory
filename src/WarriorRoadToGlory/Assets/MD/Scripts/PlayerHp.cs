using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [Header("Weapon&HP Settings")]
    [SerializeField] public float hp = 100;
    [SerializeField] private int _weapon1Damage;
    [SerializeField] private int _weapon2Damage;
    [SerializeField] private int _weapon3Damage;
    [SerializeField] private float _multiplyForDamage = 1.5f;
    public const string weaponTag1 = "StartSword";
    public const string weaponTag2 = "UpgradedSword";
    public const string weaponTag3 = "TheBestSword";
    
    
    [Header("PLayer Settings")]
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Image _vignette;
    [SerializeField] private GameObject _loseCanvas;

    private NPC _npc;
    private int difficult;
    private bool _isLose;
    public bool _endGame;

    private void Awake()
    {
        _npc = FindObjectOfType<NPC>();
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("DifficultSettings"))
            difficult = PlayerPrefs.GetInt("DifficultSettings") + 1;
        else
            difficult = 1;
    }

    void Update()
    {
        _hpBar.value = hp;
        _vignette.color = new Color(1, 1, 1, Mathf.Abs(hp / 100 - 1));
        if (hp <= 0 && !_isLose)
        {
            _isLose = true;
            _loseCanvas.SetActive(true);
            _endGame = true;
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.transform.tag) {

            case weaponTag1:
                hp -= ((_weapon1Damage * difficult) / _multiplyForDamage);
                //_npc.amountHit += 1;
                break;

            case weaponTag2:
                hp -= ((_weapon2Damage * difficult) / _multiplyForDamage);
                //_npc.amountHit += 1;
                break;

            case weaponTag3:
                hp -= ((_weapon3Damage * difficult) / _multiplyForDamage);
                //_npc.amountHit += 1;
                break;
        }
    }
}
