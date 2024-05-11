using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] public int waveNumber = 0;
    [SerializeField] bool isReadyToSpawn = false;
    GameObject enemy;
    float xPos, yPos;
    float minXPos = -62f;
    float maxXPos = -43f;
    float minZPos = 0;
    float maxZPos = 2.5f;
    public static int aliveEnemies = 0;
    public List<GameObject> wave1 = new List<GameObject>();
    public List<GameObject> wave2 = new List<GameObject>();
    public List<GameObject> wave3 = new List<GameObject>();
    public List<GameObject> wave4 = new List<GameObject>();
    public List<GameObject> wave5 = new List<GameObject>();
    public List<GameObject> wave6 = new List<GameObject>();
    public List<GameObject> wave7 = new List<GameObject>();
    public List<GameObject> wave8 = new List<GameObject>();
    public List<GameObject> wave9 = new List<GameObject>();
    public List<GameObject> wave10 = new List<GameObject>();
    void Start()
    {
        
    }

    void Update()
    {
        if (isReadyToSpawn)
        {
            switch (waveNumber)
            {
                case 1:
                    for (int i = 0; i < wave1.Count; i++)
                    {
                        enemy = (GameObject)Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                        aliveEnemies += 1;
                    }
                    isReadyToSpawn = false;
                    break;
            }
        }
    }
}
