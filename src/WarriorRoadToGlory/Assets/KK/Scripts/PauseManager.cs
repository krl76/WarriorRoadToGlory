using System;
using TMPro;
using Unity.XR.CoreUtils;
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
    [SerializeField] private Slider _sliderPos;
    [SerializeField] private TextMeshProUGUI _textPos;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _nameOfMenuScene;

    [Header("Player")] 
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _basePosition;

    private Transform playerTransform;
    private string nameSave;
    private WaveManager waveManager;
    private Merchant _merchant;
    private XROrigin _xrOrigin;

    private void Awake()
    {
        inputController = new InputController();
        inputController.RightHand.UI.started += ctx => ActivePause(ctx.ReadValueAsButton());

        _xrOrigin = GetComponentInParent<XROrigin>();

        waveManager = _waveManager.GetComponent<WaveManager>();
        _merchant = FindObjectOfType<Merchant>();
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

    public void ChangePosCam()
    {
        _textPos.text = Math.Round(_sliderPos.value, 2).ToString();
        _xrOrigin.CameraYOffset = _sliderPos.value;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("VolumeSettings", _sliderVolume.value);
        PlayerPrefs.SetFloat("PosCamSettings", _sliderPos.value);
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
            if (isPause && !waveManager.inWave && !_merchant.inShop)
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

        if (PlayerPrefs.HasKey("PosCamSettings"))
        {
            _sliderPos.value = PlayerPrefs.GetFloat("PosCamSettings");
            ChangePosCam();
        }
        else
        {
            _sliderVolume.value = 0.4f;
            ChangePosCam();
        }
    }
}
