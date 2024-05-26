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
    [SerializeField] private GameObject _loseCanvas;

    private int difficult;
    void Start()
    {
        if (PlayerPrefs.HasKey("DifficultSettings"))
            difficult = PlayerPrefs.GetInt("DifficultSettings");
        else
            difficult = 1;
    }

    void Update()
    {
        _hpBar.value = hp;
        if (hp <= 0)
        {
            _loseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.transform.tag) {

            case weaponTag1:
                hp -= ((_weapon1Damage * difficult) / _multiplyForDamage);
                NPC.amountHit += 1;
                break;

            case weaponTag2:
                hp -= ((_weapon2Damage * difficult) / _multiplyForDamage);
                NPC.amountHit += 1;
                break;

            case weaponTag3:
                hp -= ((_weapon3Damage * difficult) / _multiplyForDamage);
                NPC.amountHit += 1;
                break;
        }
    }
}
