using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] public int _enemyHp = 100;
    public GameObject[] hitEffects = new GameObject[1];
    public const string weaponTag1 = "StartSword";
    public const string weaponTag2 = "UpgradedSword";
    public const string weaponTag3 = "TheBestSword";
    GameObject enemy;
    GameObject _hitEffectClone;
    bool _sentinel = false;
    Animation anim;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player hit enemy");
        switch (collision.transform.tag)
        {
            case weaponTag1:
                _enemyHp -= 5;
                break;

            case weaponTag2:
                _enemyHp -= 15;
                break;

            case weaponTag3:
                _enemyHp -= 40;
                break;
        }
        if (_enemyHp <= 0)
        {
            anim = GetComponent<Animation>();
            anim.Stop();
            WaveManager.aliveEnemies -= 1;
            NPC.defeatedEnemy += 1;
        }
    }
}
