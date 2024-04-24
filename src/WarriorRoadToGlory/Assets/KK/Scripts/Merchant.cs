using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] private GameObject _interactCanvas;
    [SerializeField] private GameObject _shopCanvas;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private int _baseCoins;

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
                    _coins.text = _baseCoins.ToString();
                }
                break;
            case "save2":
                if (PlayerPrefs.HasKey("Coins2"))
                {
                    _coins.text = PlayerPrefs.GetInt("Coins2").ToString();
                }
                else
                {
                    _coins.text = _baseCoins.ToString();
                }
                break;
            case "save3":
                if (PlayerPrefs.HasKey("Coins3"))
                {
                    _coins.text = PlayerPrefs.GetInt("Coins3").ToString();
                }
                else
                {
                    _coins.text = _baseCoins.ToString();
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
        _interactCanvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        _interactCanvas.SetActive(false);
    }

    private void ActiveShop(bool isActive)
    {
        if (isActive && onTrigger && !inShop)
        {
            inShop = true;
            _shopCanvas.SetActive(true);
            _interactCanvas.SetActive(false);
        }
        else if (isActive && onTrigger && inShop)
        {
            inShop = false;
            _shopCanvas.SetActive(false);
            _interactCanvas.SetActive(true);
        }
    }

}
