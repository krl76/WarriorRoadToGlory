using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Slider = UnityEngine.UI.Slider;

public class PauseManager : MonoBehaviour
{
    [Header("Pause")] 
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private GameObject _waveManager;
    private InputController inputController;
    
    [Header("Settings")] 
    [SerializeField] private Slider _sliderVolume;
    [SerializeField] private TextMeshProUGUI _textVolume;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private TMP_Dropdown _difficult;
    [SerializeField] private string _nameOfMenuScene;

    [Header("Player")] 
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _basePosition;

    private Transform playerTransform;
    private string nameSave;
    private WaveManager waveManager;

    private void Awake()
    {
        inputController = new InputController();
        inputController.RightHand.UI.started += ctx => ActivePause(ctx.ReadValueAsButton());

        waveManager = _waveManager.GetComponent<WaveManager>();
        nameSave = PlayerPrefs.GetString("NameSave");
        playerTransform = _player.GetComponent<Transform>();
        LoadSettings();
        LoadPlayer();
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    public void ChangeVolume()
    {
        _textVolume.text = Math.Round(_sliderVolume.value * 100).ToString();
        _audioMixer.SetFloat("Master", Mathf.Log10(_sliderVolume.value) * 20);
    }
    
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("DifficultSettings", _difficult.value);
        PlayerPrefs.SetFloat("VolumeSettings", _sliderVolume.value);
    }

    private void SavePlayer()
    {
        int date, month, year, hour, minute;
        DateTime dt = DateTime.Now;
        date = dt.Day;
        month = dt.Month;
        year = dt.Year;
        hour = dt.Hour;
        minute = dt.Minute;
        
        switch (nameSave)
        {
            case "save1":
                PlayerPrefs.SetString("Save1", $"Сохранение 1. {date}.{month}.{year} {hour}:{minute}");
                break;
            case "save2":
                PlayerPrefs.SetString("Save2", $"Сохранение 2. {date}.{month}.{year} {hour}:{minute}");
                break;
            case "save3":
                PlayerPrefs.SetString("Save3", $"Сохранение 2. {date}.{month}.{year} {hour}:{minute}");
                break;
        }
    }

    private void LoadPlayer()
    { 
        playerTransform.position = _basePosition;
    }

    private void ActivePause(bool isPause)
    {
        if (SceneManager.GetActiveScene().name != _nameOfMenuScene)
        {
            if (isPause && !waveManager.inWave)
            {
                Time.timeScale = 0f;
                _pauseCanvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                _pauseCanvas.SetActive(false);
            }
        }
    }

    public void ContinueBtn()
    {
        ActivePause(false);
    }
    
    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SavePlayer();
        //SceneManager.LoadScene(_nameOfMenuScene);
        FindObjectOfType<LoadScene>().SceneLoad(_nameOfMenuScene);
    }
    
    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("DifficultSettings"))
        {
            _difficult.value = PlayerPrefs.GetInt("DifficultSettings");
        }
        else
        {
            _difficult.value = 1;
        }
        if (PlayerPrefs.HasKey("VolumeSettings"))
        {
            _sliderVolume.value = PlayerPrefs.GetFloat("VolumeSettings");
            ChangeVolume();
        }
        else
        {
            _sliderVolume.value = 1f;
            ChangeVolume();
        }
    }
}
