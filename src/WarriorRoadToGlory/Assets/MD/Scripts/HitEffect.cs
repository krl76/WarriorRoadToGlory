using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;
public class HitEffect : MonoBehaviour
    {
        public GameObject[] hitEffects = new GameObject[1];
        GameObject _hitEffectClone;
        private const string weaponTag = "Weapon";
        bool _sentinel = false;
    private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == weaponTag)
            {
                Debug.Log("Hit");
                foreach (ContactPoint swordHit in collision.contacts)
                {
                    Vector3 hitPoint = swordHit.point;
                    if (!_sentinel)
                    {
                        int index = Random.Range(0, hitEffects.Length);
                        _hitEffectClone = (GameObject)Instantiate(hitEffects[index], new Vector3(hitPoint.x, hitPoint.y, hitPoint.z), Quaternion.LookRotation(-collision.contacts[0].normal));
                        _sentinel = true;
                    }
                }
            }
        }
    private void OnCollisionExit(Collision collision)
    {
        if (_sentinel)
            _sentinel = false;
    }
}