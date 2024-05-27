using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundViewers : MonoBehaviour
{
   private List<AudioSource> _audioSources;

   private void Awake()
   {
      _audioSources = new List<AudioSource>(GetComponentsInChildren<AudioSource>());
   }

   public void TwoRandom()
   {
      int a = Random.Range(0, 2);
      int b = Random.Range(0, 2);
      while (a == b)
      {
         b = Random.Range(0, 2);
      }
      _audioSources[a].Play();
      _audioSources[b].Play();
   }

   public void OneRandom()
   {
      _audioSources[Random.Range(0, 2)].Play();
   }
   
   public void Barabans()
   {
      _audioSources[0].Play();
   }
   
   public void Happy1()
   {
      _audioSources[1].Play();
   }
   
   public void Happy2()
   {
      _audioSources[2].Play();
   }
}
