using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [Header("Main")] 
    [SerializeField] private Transform _head;
    [SerializeField] private GameObject _interactCanvas;
    [SerializeField] private GameObject _shopCanvas;
    [SerializeField] private GameObject _coinsCanvas;
    
    [Header("Coins")]
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private string _baseCoins;

    private InputController inputController;
    private bool onTrigger;
    private bool inShop = false;

    private string nameSave;

    private void Awake()
    {
        inputController = new InputController();
        inputController.LeftHand.Interact.started += ctx => ActiveShop(ctx.ReadValueAsButton());
        nameSave = PlayerPrefs.GetString("NameSave");
        LoadCoin();
    }

    private void Update()
    {
        _interactCanvas.transform.LookAt(new Vector3(_head.position.x, _interactCanvas.transform.position.y, _head.position.z));
        _interactCanvas.transform.forward *= -1;
        _coinsCanvas.transform.LookAt(new Vector3(_head.position.x, _coinsCanvas.transform.position.y, _head.position.z));
        _coinsCanvas.transform.forward *= -1;
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void LoadCoin()
    {
        switch (nameSave)
        {
            case "save1":
                if (PlayerPrefs.HasKey("Coins1"))
                {
                    _coins.text = PlayerPrefs.GetInt("Coins1").ToString();
                }
                else
                {
                    _coins.text = _baseCoins;
                }
                break;
            case "save2":
                if (PlayerPrefs.HasKey("Coins2"))
                {
                    _coins.text = PlayerPrefs.GetInt("Coins2").ToString();
                }
                else
                {
                    _coins.text = _baseCoins;
                }
                break;
            case "save3":
                if (PlayerPrefs.HasKey("Coins3"))
                {
                    _coins.text = PlayerPrefs.GetInt("Coins3").ToString();
                }
                else
                {
                    _coins.text = _baseCoins;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = true;
            _interactCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = false;
            _interactCanvas.SetActive(false);
        }
    }

    private void ActiveShop(bool isActive)
    {
        if (isActive && onTrigger && !inShop)
        {
            Time.timeScale = 0f;
            inShop = true;
            _shopCanvas.SetActive(true);
            _interactCanvas.SetActive(false);
        }
        else if (isActive && onTrigger && inShop)
        {
            Time.timeScale = 1f;
            inShop = false;
            _shopCanvas.SetActive(false);
            _interactCanvas.SetActive(true);
        }
    }

}
