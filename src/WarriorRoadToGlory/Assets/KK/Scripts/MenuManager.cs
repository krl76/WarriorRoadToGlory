using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Transform _head;
    [SerializeField] private GameObject _mainMenu;

    [Header("Settings")] 
    [SerializeField] private Slider _sliderVolume;
    [SerializeField] private TextMeshProUGUI _textVolume;
    void Update()
    {
        _mainMenu.transform.LookAt(new Vector3(_head.position.x, _mainMenu.transform.position.y, _head.position.z ));
        _mainMenu.transform.forward *= -1;

        _textVolume.text = Math.Round(_sliderVolume.value).ToString();
    }

    void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
