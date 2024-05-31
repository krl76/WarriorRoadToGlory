using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
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
    private string nameOfSave;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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

    public void Click()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
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
                    _save1.text = $"Сохранение 1. {date}.{month}.{year} {hour}:{minute}"; 
                    nameOfSave = "save1";
                    break;
                case "Save2":
                    _save2.text = $"Сохранение 2. {date}.{month}.{year} {hour}:{minute}";
                    nameOfSave = "save2"; 
                    break;
                case "Save3":
                    _save3.text = $"Сохранение 3. {date}.{month}.{year} {hour}:{minute}"; 
                    nameOfSave = "save3"; 
                    break;
            }
            //SceneManager.LoadScene(_nameOfGameScene);
            PlayerPrefs.SetString("NameSave", nameOfSave);
            SaveSaves();
            FindObjectOfType<LoadScene>().SceneLoad(_nameOfGameScene);
        }
        else
        {
            DeleteSave(name);
            CancelButton();
        }
    }

    public string NameOfSave()
    {
        return nameOfSave;
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

    private void SaveSaves()
    {
        PlayerPrefs.SetString("Save1", _save1.text);
        PlayerPrefs.SetString("Save2", _save2.text);
        PlayerPrefs.SetString("Save3", _save3.text);
    }
    
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("DifficultSettings", _difficult.value);
        PlayerPrefs.SetFloat("VolumeSettings", _sliderVolume.value);
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("DifficultSettings"))
        {
            _difficult.value = PlayerPrefs.GetInt("DifficultSettings");
        }
        else
        {
            _difficult.value = 0;
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
        else
        {
            _save1.text = "Создать новое сохранение";
        }
        if (PlayerPrefs.HasKey("Save2"))
        {
            if (PlayerPrefs.GetString("Save2") != "Создать новое сохранение")
                _save2.text = PlayerPrefs.GetString("Save2");
        }
        else
        {
            _save2.text = "Создать новое сохранение";
        }
        if (PlayerPrefs.HasKey("Save3"))
        {
            if (PlayerPrefs.GetString("Save3") != "Создать новое сохранение")
                _save3.text = PlayerPrefs.GetString("Save3");
        }
        else
        {
            _save3.text = "Создать новое сохранение";
        }
    }

    private void DeleteSave(string name)
    {
        switch (name)
        {
            case "Save1":
                if (_save1.text != "Создать новое сохранение")
                {
                    PlayerPrefs.DeleteKey("Coins1");
                    PlayerPrefs.DeleteKey("Wave1");
                    PlayerPrefs.DeleteKey("Save1");
                    PlayerPrefs.DeleteKey("LevelSword1.1");
                    PlayerPrefs.DeleteKey("LevelSword2.1");
                    PlayerPrefs.DeleteKey("LevelSword3.1");
                    PlayerPrefs.DeleteKey("LevelSword4.1");
                    _save1.text = "Создать новое сохранение";
                }
                break;
            case "Save2":
                if (_save2.text != "Создать новое сохранение")
                {
                    PlayerPrefs.DeleteKey("Coins2");
                    PlayerPrefs.DeleteKey("Wave2");
                    PlayerPrefs.DeleteKey("Save2");
                    PlayerPrefs.DeleteKey("LevelSword1.2");
                    PlayerPrefs.DeleteKey("LevelSword2.2");
                    PlayerPrefs.DeleteKey("LevelSword3.2");
                    PlayerPrefs.DeleteKey("LevelSword4.2");
                    _save2.text = "Создать новое сохранение";
                }
                break;
            case "Save3":
                if (_save3.text != "Создать новое сохранение")
                {
                    PlayerPrefs.DeleteKey("Coins3");
                    PlayerPrefs.DeleteKey("Wave3");
                    PlayerPrefs.DeleteKey("Save3");
                    PlayerPrefs.DeleteKey("LevelSword1.3");
                    PlayerPrefs.DeleteKey("LevelSword2.3");
                    PlayerPrefs.DeleteKey("LevelSword3.3");
                    PlayerPrefs.DeleteKey("LevelSword4.3");
                    _save3.text = "Создать новое сохранение";
                }
                break;
        }
    }
    
    void Exit()
    {
        Application.Quit();
    }
}
