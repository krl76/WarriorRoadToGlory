using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject _exitTrigger;
    private InLocation inLocation;
    public bool allSpawned = false;
    [SerializeField] public int waveNumber = 0;
    GameObject enemy;
    float xPos, yPos;
    float minXPos = -62f;
    float maxXPos = -43f;
    float minZPos = 0;
    float maxZPos = 2.5f;
    public int aliveEnemies = 0;
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

    private bool inSpawn;

    private void Awake()
    {
        namesave = PlayerPrefs.GetString("NameSave");
        LoadWave();
    }

    private void Update()
    {
        inWave = FindObjectOfType<inWave>().inWave2;
        if (inWave)
        {
            if (!allSpawned && !inSpawn)
            {
                inSpawn = true;
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
                allSpawned = true;
                for (int i = 0; i < wave1.Count; i++)
                {
                    enemy = Instantiate(wave1[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
            case 2:
                allSpawned = true;
                for (int i = 0; i < wave2.Count; i++)
                {
                    enemy = Instantiate(wave2[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
            case 3:
                allSpawned = true;
                for (int i = 0; i < wave3.Count; i++)
                {
                    enemy = Instantiate(wave3[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
            case 4:
                allSpawned = true;
                for (int i = 0; i < wave4.Count; i++)
                {
                    enemy = Instantiate(wave4[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
            case 5:
                allSpawned = true;
                for (int i = 0; i < wave5.Count; i++)
                {
                    enemy = Instantiate(wave5[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
            case 6:
                allSpawned = true;
                for (int i = 0; i < wave6.Count; i++)
                {
                    enemy = Instantiate(wave6[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
            case 7:
                allSpawned = true;
                for (int i = 0; i < wave7.Count; i++)
                {
                    enemy = Instantiate(wave7[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
            case 8:
                allSpawned = true;
                for (int i = 0; i < wave8.Count; i++)
                {
                    enemy = Instantiate(wave8[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
            case 9:
                allSpawned = true;
                for (int i = 0; i < wave9.Count; i++)
                {
                    enemy = Instantiate(wave9[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
            case 10:
                allSpawned = true;
                for (int i = 0; i < wave10.Count; i++)
                {
                    enemy = Instantiate(wave10[i], new Vector3(UnityEngine.Random.Range(minXPos, maxXPos), 10, UnityEngine.Random.Range(minZPos, maxZPos)), Quaternion.identity);
                    aliveEnemies += 1;
                }
                break;
        }
        inSpawn = false;
    }
    public void EndWave()
    {
        /*foreach (var obj in FindObjectsOfType<NavMeshAgent>())
        {
            Destroy(obj.gameObject);
        }
        allSpawned = false;*/
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
