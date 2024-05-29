using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvas : MonoBehaviour
{
    [Header("Player")] 
    [SerializeField] private Transform _head;
    
    [Header("Canvas Sets")]
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private TextMeshProUGUI _coinsAnvil;
    [SerializeField] private int _baseCoins;

    private WaveManager _waveManager;

    public int defeatedEnemy;
    
    private int _numberOfWave;
    private string namesave;
    private bool allSpawned;
    private int aliveEnemy;
    private int difficult;
    private float wavesInARow;
    private bool isChange;

    private void Awake()
    {
        wavesInARow = 1;
        LoadSettings();
        _waveManager = FindObjectOfType<WaveManager>();
    }

    private void Update()
    {
        _winCanvas.transform.LookAt(new Vector3(_head.position.x, _winCanvas.transform.position.y, _head.position.z));
        _winCanvas.transform.forward *= -1;
        
        _numberOfWave = _waveManager.waveNumber;
        allSpawned = _waveManager.allSpawned;
        aliveEnemy = WaveManager.aliveEnemies;
        if (allSpawned && aliveEnemy == 0 && !isChange && _numberOfWave != 10)
        {
            _winCanvas.SetActive(true);
            Time.timeScale = 0;
            if(wavesInARow > 1)
                _coins.text = $"{Convert.ToInt32((_baseCoins * defeatedEnemy * wavesInARow) / difficult)}";
            isChange = true;
        }

        if (allSpawned && aliveEnemy == 0 && !isChange && _numberOfWave == 10)
        {
            isChange = true;
            FindObjectOfType<Final>().StartFinal();
        }
    }

    public void Continue()
    {
        isChange = false;
        wavesInARow += 0.2f;
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

    private void LoadSettings()
    {
        namesave = PlayerPrefs.GetString("NameSave");
        if (PlayerPrefs.HasKey("DifficultSettings"))
            difficult = PlayerPrefs.GetInt("DifficultSettings");
        else
            difficult = 1;
    }
}
