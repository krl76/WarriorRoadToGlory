using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] private GameObject _interactCanvas;
    [SerializeField] private GameObject _shopCanvas;

    private InputController inputController;
    
    private void Awake()
    {
        inputController = new InputController();
        inputController.LeftHand.Interact.started += ctx => ActiveShop();
    }
}
