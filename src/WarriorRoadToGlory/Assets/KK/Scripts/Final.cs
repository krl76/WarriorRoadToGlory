using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private string _nameOfMenuScene;

    private AudioSource _audioSource;
    private bool inFinal;
    private string nameSave;

    private void Start()
    {
        nameSave = PlayerPrefs.GetString("NameSave");
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartFinal()
    {
        _audioSource.PlayOneShot(_audioClips[0]);
        inFinal = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && inFinal)
        {
            _audioSource.PlayOneShot(_audioClips[1]);
            StartCoroutine(TakePause());
            DeleteSave();
            FindObjectOfType<LoadScene>().SceneLoad(_nameOfMenuScene);
        }
    }
    
    private void DeleteSave()
    {
        switch (nameSave)
        {
            case "Save1":
                PlayerPrefs.DeleteKey("Coins1");
                PlayerPrefs.DeleteKey("Wave1");
                PlayerPrefs.DeleteKey("Save1");
                PlayerPrefs.DeleteKey("LevelSword1.1");
                PlayerPrefs.DeleteKey("LevelSword2.1");
                PlayerPrefs.DeleteKey("LevelSword3.1");
                PlayerPrefs.DeleteKey("LevelSword4.1");
                break;
            case "Save2":
                PlayerPrefs.DeleteKey("Coins2");
                PlayerPrefs.DeleteKey("Wave2");
                PlayerPrefs.DeleteKey("Save2");
                PlayerPrefs.DeleteKey("LevelSword1.2");
                PlayerPrefs.DeleteKey("LevelSword2.2");
                PlayerPrefs.DeleteKey("LevelSword3.2");
                PlayerPrefs.DeleteKey("LevelSword4.2");
                break;
            case "Save3":
                PlayerPrefs.DeleteKey("Coins3");
                PlayerPrefs.DeleteKey("Wave3");
                PlayerPrefs.DeleteKey("Save3");
                PlayerPrefs.DeleteKey("LevelSword1.3");
                PlayerPrefs.DeleteKey("LevelSword2.3");
                PlayerPrefs.DeleteKey("LevelSword3.3");
                PlayerPrefs.DeleteKey("LevelSword4.3");
                break;
        }
    }

    IEnumerator TakePause()
    {
        yield return new WaitForSeconds(10);
    }
}