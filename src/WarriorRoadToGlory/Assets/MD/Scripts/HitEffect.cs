using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class HitEffect : MonoBehaviour
    {
        public GameObject[] hitEffects = new GameObject[5];
        GameObject hitEffectClone;
        private const string weaponTag = "Weapon";

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == weaponTag)
            {
                Debug.Log("Hit");
                foreach (ContactPoint swordHit in collision.contacts)
                {
                    Vector3 hitPoint = swordHit.point;
                    int index = Random.Range(0, hitEffects.Length);
                    hitEffectClone = (GameObject)Instantiate(hitEffects[index], new Vector3(hitPoint.x, hitPoint.y, hitPoint.z), Quaternion.LookRotation(collision.contacts[0].normal));
                    Destroy(hitEffectClone, 1);
                }
            }
        }
    }