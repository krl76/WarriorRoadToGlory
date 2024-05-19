using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] public int hp = 100;
    public const string weaponTag1 = "StartSword";
    public const string weaponTag2 = "UpgradedSword";
    public const string weaponTag3 = "TheBestSword";
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag) {

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
