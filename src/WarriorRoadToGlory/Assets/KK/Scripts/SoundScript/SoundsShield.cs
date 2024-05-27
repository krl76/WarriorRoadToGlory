using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundsShield : MonoBehaviour
{
   [SerializeField] private AudioClip[] _audioClips;

   private AudioSource _audioSource;
   private bool Pause;

   private void Awake()
   {
      _audioSource = GetComponent<AudioSource>();
   }

   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("UpgradedSword") || other.gameObject.CompareTag("TheBestSword") ||
          other.gameObject.CompareTag("StartSword") || other.gameObject.CompareTag("Shield"))
      {
         if (!Pause)
         {
            _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
            Pause = true;
            StartCoroutine(Pause2());
         }
      }
   }

   IEnumerator Pause2()
   {
      yield return new WaitForSeconds(0.5f);
      Pause = false;
   }
}
