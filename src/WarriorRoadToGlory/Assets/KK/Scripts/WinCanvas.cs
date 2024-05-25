using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private TextMeshProUGUI _coinsAnvil;
    [SerializeField] private int _baseCoins;

    private WaveManager _waveManager;

    public static int defeatedEnemy;
    
    private int _numberOfWave;
    private string namesave;
    private bool allSpawned;
    private int aliveEnemy;
    private int difficult;
    private bool isChange;

    private void Awake()
    {
        difficult = PlayerPrefs.GetInt("DifficultSettings");
        namesave = PlayerPrefs.GetString("NameSave");
        _waveManager = FindObjectOfType<WaveManager>();
        
    }

    private void Update()
    {
        _numberOfWave = _waveManager.waveNumber;
        allSpawned = _waveManager.allSpawned;
        aliveEnemy = WaveManager.aliveEnemies;
        if (allSpawned && aliveEnemy == 0 && !isChange && _numberOfWave != 10)
        {
            _winCanvas.SetActive(true);
            Time.timeScale = 0;
            _coins.text = $"{(_baseCoins * defeatedEnemy) / difficult}";
            isChange = true;
        }

        if (allSpawned && aliveEnemy == 0 && !isChange && _numberOfWave == 10)
        {
            //действие по запуску кат-сцены финальной
        }
    }

    public void Continue()
    {
        _waveManager.waveNumber += 1;
        _waveManager.StartWave();
    }

    public void toMerchant()
    {
        switch (namesave)
        {
            case "save1":
                PlayerPrefs.SetInt("Coins1", Int32.Parse(_coins.text) + Int32.Parse(_coinsAnvil.text));
                PlayerPrefs.SetInt("Wave1", _numberOfWave);
                break;
            case "save2":
                PlayerPrefs.SetInt("Coins2", Int32.Parse(_coins.text) + Int32.Parse(_coinsAnvil.text));
                PlayerPrefs.SetInt("Wave2", _numberOfWave);
                break;
            case "save3":
                PlayerPrefs.SetInt("Coins3", Int32.Parse(_coins.text) + Int32.Parse(_coinsAnvil.text));
                PlayerPrefs.SetInt("Wave3", _numberOfWave);
                break;
        }
        FindObjectOfType<LoadScene>().SceneLoad(SceneManager.GetActiveScene().name);
    }
}
