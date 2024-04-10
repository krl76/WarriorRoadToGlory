using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
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
    [SerializeField] private DropdownField _dropdown;
    private AudioSource audioSource;
    
    //Serializable components
    private Saving saving;
    
    void Update()
    {
        _mainMenu.transform.LookAt(new Vector3(_head.position.x, _mainMenu.transform.position.y, _head.position.z ));
        //_mainMenu.transform.forward *= -1;
    }

    public void ChangeVolumeText()
    {
        _textVolume.text = Math.Round(_sliderVolume.value).ToString();
    }

    void ChangeVolume()
    {
        audioSource.volume = _sliderVolume.value / 100;
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
        switch (name)
        {
            case "Save1":
                if (_save1.text.Length == 24)
                {
                    _save1.text = $"Сохранение 1. {date}.{month}.{year} {hour}:{minute}";
                    //SceneManager.LoadScene("KK/TestScenes/Game");
                }
                else
                {
                    
                }
                break;
            case "Save2":
                if (_save2.text.Length == 24)
                {
                    _save2.text = $"Сохранение 2. {date}.{month}.{year} {hour}:{minute}";
                }
                else
                {
                    
                }
                break;
            case "Save3":
                if (_save3.text.Length == 24)
                {
                    _save3.text = $"Сохранение 3. {date}.{month}.{year} {hour}:{minute}";
                }
                else
                {
                    
                }
                break;
        }
    }
    
    void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
