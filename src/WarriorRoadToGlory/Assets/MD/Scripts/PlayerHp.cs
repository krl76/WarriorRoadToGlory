using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] public int hp = 100;
    [SerializeField] private Slider _hpBar;
    [SerializeField] private GameObject _loseCanvas;
    public const string weaponTag1 = "StartSword";
    public const string weaponTag2 = "UpgradedSword";
    public const string weaponTag3 = "TheBestSword";
    void Start()
    {
        
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
                hp -= 5;
                NPC.amountHit += 1;
                break;

            case weaponTag2:
                hp -= 15;
                NPC.amountHit += 1;
                break;

            case weaponTag3:
                hp -= 40;
                NPC.amountHit += 1;
                break;
        }
    }
}
