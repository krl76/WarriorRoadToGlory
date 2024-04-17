using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

public class MenuManager : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Transform _head;
    [SerializeField] private GameObject _mainMenu;

    [Header("Saving Zone")] 
    [SerializeField] private TextMeshProUGUI _save1;
    [SerializeField] private TextMeshProUGUI _save2;
    [SerializeField] private TextMeshProUGUI _save3;
    
    [Header("Settings")]
    [SerializeField] private Slider _sliderVolume;
    [SerializeField] private TextMeshProUGUI _textVolume;
    [SerializeField] private TMP_Dropdown _difficult;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _nameOfGameScene;

    [Header("Delete/Start Zone")] 
    [SerializeField] private GameObject _returnToMenu;
    [SerializeField] private GameObject _cancelDelete;
    
    private bool delete = false;

    private void Awake()
    {
        LoadSettings();
    }

    void Update()
    {
        _mainMenu.transform.LookAt(new Vector3(_head.position.x, _mainMenu.transform.position.y, _head.position.z ));
        //_mainMenu.transform.forward *= -1;
    }

    void ChangeVolume()
    {
        _textVolume.text = Math.Round(_sliderVolume.value * 100).ToString();
        _audioMixer.SetFloat("Master", Mathf.Log10(_sliderVolume.value) * 20);
    }

    public void Save(string name)
    {
        int date, month, year, hour, minute;
        DateTime dt = DateTime.Now;
        date = dt.Day;
        month = dt.Month;
        year = dt.Year;
        hour = dt.Hour;
        minute = dt.Minute;
        if (!delete)
        {
            switch (name)
            {
                case "Save1":
                    if (_save1.text == "Создать новое сохранение")
                    {
                        _save1.text = $"Сохранение 1. {date}.{month}.{year} {hour}:{minute}";
                        FindObjectOfType<LoadScreen>().LoadLevel(_nameOfGameScene);
                    }
                    break;
                case "Save2":
                    if (_save2.text == "Создать новое сохранение")
                    {
                        _save2.text = $"Сохранение 2. {date}.{month}.{year} {hour}:{minute}";
                        FindObjectOfType<LoadScreen>().LoadLevel(_nameOfGameScene);
                    }
                    break;
                case "Save3":
                    if (_save3.text == "Создать новое сохранение")
                    {
                        _save3.text = $"Сохранение 3. {date}.{month}.{year} {hour}:{minute}";
                        FindObjectOfType<LoadScreen>().LoadLevel(_nameOfGameScene);
                    }
                    break;
            }
        }
        else
        {
            switch (name)
            {
                case "Save1":
                    _save1.text = "Создать новое сохранение";
                    break;
                case "Save2":
                    _save2.text = "Создать новое сохранение";
                    break;
                case "Save3":
                    _save3.text = "Создать новое сохранение";
                    break;
            }
            CancelButton();
        }
    }

    public void DeleteButton()
    {
        delete = true;
        _cancelDelete.SetActive(true);
        _returnToMenu.SetActive(false);
    }

    public void CancelButton()
    {
        delete = false;
        _cancelDelete.SetActive(false);
        _returnToMenu.SetActive(true);
    }
    
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("DifficultSettings", _difficult.value);
        PlayerPrefs.SetFloat("VolumeSettings", _sliderVolume.value);
        PlayerPrefs.SetString("Save1", _save1.text);
        PlayerPrefs.SetString("Save2", _save2.text);
        PlayerPrefs.SetString("Save3", _save3.text);
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
        if (PlayerPrefs.HasKey("Save1"))
        {
            if (PlayerPrefs.GetString("Save1") != "Создать новое сохранение")
                _save1.text = PlayerPrefs.GetString("Save1");
        }
        if (PlayerPrefs.HasKey("Save2"))
        {
            if (PlayerPrefs.GetString("Save2") != "Создать новое сохранение")
                _save2.text = PlayerPrefs.GetString("Save2");
        }
        if (PlayerPrefs.HasKey("Save3"))
        {
            if (PlayerPrefs.GetString("Save3") != "Создать новое сохранение")
                _save3.text = PlayerPrefs.GetString("Save3");
        }
    }
    
    void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}