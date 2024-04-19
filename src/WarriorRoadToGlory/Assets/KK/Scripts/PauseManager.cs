using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class PauseManager : MonoBehaviour
{
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
    private MenuManager menuManager;
    private string nameSave;

    private void Awake()
    {
        nameSave = menuManager.NameOfSave();
        playerTransform = _player.GetComponent<Transform>();
        LoadSettings();
    }

    void ChangeVolume()
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
                PlayerPrefs.SetFloat("Save1PlayerX", playerTransform.position.x);
                PlayerPrefs.SetFloat("Save1PlayerY", playerTransform.position.y);
                PlayerPrefs.SetFloat("Save1PlayerZ", playerTransform.position.z);
                PlayerPrefs.SetString("Save1", $"Сохранение 1. {date}.{month}.{year} {hour}:{minute}");
                break;
            case "save2":
                PlayerPrefs.SetFloat("Save2PlayerX", playerTransform.position.x);
                PlayerPrefs.SetFloat("Save2PlayerY", playerTransform.position.y);
                PlayerPrefs.SetFloat("Save2PlayerZ", playerTransform.position.z);
                PlayerPrefs.SetString("Save2", $"Сохранение 2. {date}.{month}.{year} {hour}:{minute}");
                break;
            case "save3":
                PlayerPrefs.SetFloat("Save3PlayerX", playerTransform.position.x);
                PlayerPrefs.SetFloat("Save3PlayerY", playerTransform.position.y);
                PlayerPrefs.SetFloat("Save3PlayerZ", playerTransform.position.z);
                PlayerPrefs.SetString("Save3", $"Сохранение 2. {date}.{month}.{year} {hour}:{minute}");
                break;
        }
    }

    private void LoadPlayer()
    {
        switch (nameSave)
        {
            case "save1":
                if (PlayerPrefs.HasKey("Save1PlayerX") && PlayerPrefs.HasKey("Save1PlayerY") && PlayerPrefs.HasKey("Save1PlayerZ"))
                {
                    playerTransform.position = new Vector3(PlayerPrefs.GetFloat("Save1PlayerX"), PlayerPrefs.GetFloat("Save1PlayerY"),
                        PlayerPrefs.GetFloat("Save1PlayerZ"));
                }
                else
                {
                    playerTransform.position = _basePosition;
                }
                break;
            case "save2":
                if (PlayerPrefs.HasKey("Save2PlayerX") && PlayerPrefs.HasKey("Save2PlayerY") && PlayerPrefs.HasKey("Save2PlayerZ"))
                {
                    playerTransform.position = new Vector3(PlayerPrefs.GetFloat("Save2PlayerX"), PlayerPrefs.GetFloat("Save2PlayerY"),
                        PlayerPrefs.GetFloat("Save2PlayerZ"));
                }
                else
                {
                    playerTransform.position = _basePosition;
                }
                break;
            case "save3":
                if (PlayerPrefs.HasKey("Save3PlayerX") && PlayerPrefs.HasKey("Save3PlayerY") && PlayerPrefs.HasKey("Save3PlayerZ"))
                {
                    playerTransform.position = new Vector3(PlayerPrefs.GetFloat("Save3PlayerX"), PlayerPrefs.GetFloat("Save3PlayerY"),
                        PlayerPrefs.GetFloat("Save3PlayerZ"));
                }
                else
                {
                    playerTransform.position = _basePosition;
                }
                break;
        }
    }
    
    public void ExitToMenu()
    {
        SavePlayer();
        FindObjectOfType<LoadScreen>().LoadLevel(_nameOfMenuScene);
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
