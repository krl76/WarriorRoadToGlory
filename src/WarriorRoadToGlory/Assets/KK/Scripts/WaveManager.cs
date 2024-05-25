using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject _exitTrigger;
    [SerializeField] private GameObject _winCanvas;
    private InLocation inLocation;
    public bool allSpawned = false;
    [SerializeField] public int waveNumber = 0;
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

    public bool inWave;

    private string namesave;

    private void Awake()
    {
        namesave = PlayerPrefs.GetString("NameSave");
        inLocation = _exitTrigger.GetComponent<InLocation>();
        LoadWave();
    }

    private void Update()
    {
        inWave = inLocation.onMain;
        if (inWave)
        {
            if (!allSpawned)
            {
                waveNumber += 1;
                StartWave();
            }
        }
    }

    public void StartWave()
    {
        switch (waveNumber)
        {
            case 1:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
            case 2:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
            case 3:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
            case 4:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
            case 5:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
            case 6:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
            case 7:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
            case 8:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
            case 9:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
            case 10:
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                allSpawned = true;
                break;
        }
    }

    private void LoadWave()
    {
        switch (namesave)
        {
            case "save1":
                if (PlayerPrefs.HasKey("Wave1"))
                    waveNumber = PlayerPrefs.GetInt("Wave1");
                else
                    waveNumber = 0;
                break;
            case "save2":
                if (PlayerPrefs.HasKey("Wave2"))
                    waveNumber = PlayerPrefs.GetInt("Wave2");
                else
                    waveNumber = 0;
                break;
            case "save3":
                if (PlayerPrefs.HasKey("Wave3"))
                    waveNumber = PlayerPrefs.GetInt("Wave3");
                else
                    waveNumber = 0;
                break;
        }
    }
}
