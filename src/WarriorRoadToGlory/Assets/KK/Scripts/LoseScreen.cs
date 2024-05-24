using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private GameObject _waveManagerObject;
    [SerializeField] private TextMeshProUGUI _wave;
    [SerializeField] private string _nameOfMenuScene;

    private int _numberOfWave;
    private string nameSave;

    private void OnEnable()
    {
        _numberOfWave = _waveManagerObject.GetComponent<WaveManager>().waveNumber;
        _wave.text = $"{_numberOfWave - 1} волн";
        nameSave = PlayerPrefs.GetString("NameSave");
    }

    public void ToMenu()
    {
        //Time.timeScale = 1f;
        DeleteSave();
        //SceneManager.LoadScene(_nameOfMenuScene);
        FindObjectOfType<LoadScene>().SceneLoad(_nameOfMenuScene);
    }
    
    private void DeleteSave()
    {
        switch (nameSave)
        {
            case "Save1":
                PlayerPrefs.DeleteKey("Coins1");
                PlayerPrefs.DeleteKey("Save1PlayerX");
                PlayerPrefs.DeleteKey("Save1PlayerY");
                PlayerPrefs.DeleteKey("Save1PlayerZ");
                PlayerPrefs.DeleteKey("Save1");
                PlayerPrefs.DeleteKey("Coins1");
                PlayerPrefs.DeleteKey("LevelSword1.1");
                PlayerPrefs.DeleteKey("LevelSword2.1");
                PlayerPrefs.DeleteKey("LevelSword3.1");
                PlayerPrefs.DeleteKey("LevelSword4.1");
                break;
            case "Save2":
                PlayerPrefs.DeleteKey("Coins2");
                PlayerPrefs.DeleteKey("Save2PlayerX");
                PlayerPrefs.DeleteKey("Save2PlayerY");
                PlayerPrefs.DeleteKey("Save2PlayerZ");
                PlayerPrefs.DeleteKey("Save2");
                PlayerPrefs.DeleteKey("Coins2");
                PlayerPrefs.DeleteKey("LevelSword1.2");
                PlayerPrefs.DeleteKey("LevelSword2.2");
                PlayerPrefs.DeleteKey("LevelSword3.2");
                PlayerPrefs.DeleteKey("LevelSword4.2");
                break;
            case "Save3":
                PlayerPrefs.DeleteKey("Coins3");
                PlayerPrefs.DeleteKey("Save3PlayerX");
                PlayerPrefs.DeleteKey("Save3PlayerY");
                PlayerPrefs.DeleteKey("Save3PlayerZ");
                PlayerPrefs.DeleteKey("Save3");
                PlayerPrefs.DeleteKey("Coins3");
                PlayerPrefs.DeleteKey("LevelSword1.3");
                PlayerPrefs.DeleteKey("LevelSword2.3");
                PlayerPrefs.DeleteKey("LevelSword3.3");
                PlayerPrefs.DeleteKey("LevelSword4.3");
                break;
        }
    }
}
