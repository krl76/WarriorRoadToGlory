using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using Button = UnityEngine.UI.Button;

public class Shop : MonoBehaviour
{
    [Header("Weapons")] 
    [SerializeField] private GameObject _sword1;
    [SerializeField] private GameObject _sword2;
    [SerializeField] private GameObject _sword3;
    [SerializeField] private GameObject _shield;
    [SerializeField] private int _multiplyForWeapon;

    [Header("Buttons")] 
    [SerializeField] private Button[] _buy;
    [SerializeField] private Button[] _pick;
    [SerializeField] private Button[] _upgrade;
    
    
    [Header("Coins")] 
    [SerializeField] private TextMeshProUGUI[] _coinCost;
    [SerializeField] private GameObject[] _coinSprites;
    [SerializeField] private int _multiplyForCoins;

    [Header("Merchant Sets")] 
    [SerializeField] private TextMeshProUGUI _coins;

    private int coins;
    private int levelOfSword1 = 1;
    private int levelOfSword2 = 0;
    private int levelOfSword3 = 0;
    private int levelOfSword4 = 0;

    private string nameSave;

    private void Awake()
    {
        coins = Convert.ToInt32(_coins.text);
        nameSave = PlayerPrefs.GetString("NameSave");
        LoadShop();
    }

    public void Buy(int typeOfSword)
    {
        switch (typeOfSword)
        {
            /*case 1:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword - 1].text))
                {
                    _coins.text = (Convert.ToInt32(_coinCost[typeOfSword - 1].text) - Convert.ToInt32(_coins.text)).ToString();
                    _buy[typeOfSword - 1].interactable = false;
                    _upgrade[typeOfSword - 1].interactable = true;
                    _coinCost[typeOfSword - 1].gameObject.SetActive(false);
                    _coinSprites[typeOfSword - 1].gameObject.SetActive(false);
                    _coinCost[typeOfSword + 3].gameObject.SetActive(true);
                    _coinSprites[typeOfSword + 3].gameObject.SetActive(true);
                    levelOfSword1 = 1;
                    // продумать меч
                }
                break;*/
            case 2:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword - 1].text))
                {
                    _coins.text = (Convert.ToInt32(_coinCost[typeOfSword - 1].text) - Convert.ToInt32(_coins.text)).ToString();
                    _buy[typeOfSword - 1].interactable = false;
                    _upgrade[typeOfSword - 1].interactable = true;
                    _coinCost[typeOfSword - 1].gameObject.SetActive(false);
                    _coinSprites[typeOfSword - 1].gameObject.SetActive(false);
                    _coinCost[typeOfSword + 3].gameObject.SetActive(true);
                    _coinSprites[typeOfSword + 3].gameObject.SetActive(true);
                    levelOfSword2 = 1;
                    _pick[typeOfSword - 1].gameObject.SetActive(true);
                    //_sword2.SetActive(true);
                }
                break;
            case 3:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword - 1].text))
                {
                    _coins.text = (Convert.ToInt32(_coinCost[typeOfSword - 1].text) - Convert.ToInt32(_coins.text)).ToString();
                    _buy[typeOfSword - 1].interactable = false;
                    _upgrade[typeOfSword - 1].interactable = true;
                    _coinCost[typeOfSword - 1].gameObject.SetActive(false);
                    _coinSprites[typeOfSword - 1].gameObject.SetActive(false);
                    _coinCost[typeOfSword + 3].gameObject.SetActive(true);
                    _coinSprites[typeOfSword + 3].gameObject.SetActive(true);
                    levelOfSword3 = 1;
                    _pick[typeOfSword - 1].gameObject.SetActive(true);
                    //_sword3.SetActive(true);
                }
                break;
            case 4:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword - 1].text))
                {
                    _coins.text = (Convert.ToInt32(_coinCost[typeOfSword - 1].text) - Convert.ToInt32(_coins.text)).ToString();
                    _buy[typeOfSword - 1].interactable = false;
                    //_upgrade[typeOfSword - 1].interactable = true;
                    _coinCost[typeOfSword - 1].gameObject.SetActive(false);
                    _coinSprites[typeOfSword - 1].gameObject.SetActive(false);
                    //_coinCost[typeOfSword + 3].gameObject.SetActive(true);
                    //_coinSprites[typeOfSword + 3].gameObject.SetActive(true);
                    levelOfSword4 = 1;
                    _shield.SetActive(true);
                }
                break;
        }
    }

    public void Upgrade(int typeOfSword)
    {
        switch (typeOfSword)
        {
            case 1:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword + 3].text))
                {
                    _coins.text = (Convert.ToInt32(_coinCost[typeOfSword + 3].text) - Convert.ToInt32(_coins.text)).ToString();
                    _coinCost[typeOfSword + 3].text = (Convert.ToInt32(_coinCost[typeOfSword + 3].text) *
                                                       _multiplyForCoins).ToString();
                    levelOfSword1 += 1;
                    //UpgradeWeapon(levelOfSword1, _sword1)
                    if (levelOfSword1 - 1 == 4)
                    {
                        _upgrade[typeOfSword - 1].interactable = false;
                        _coinCost[typeOfSword + 3].text = "MAX";
                        _coinSprites[typeOfSword + 3].gameObject.SetActive(false);
                    }
                }
                break;
            case 2:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword + 3].text))
                {
                    _coins.text = (Convert.ToInt32(_coinCost[typeOfSword + 3].text) - Convert.ToInt32(_coins.text)).ToString();
                    _coinCost[typeOfSword + 3].text = (Convert.ToInt32(_coinCost[typeOfSword + 3].text) *
                                                       _multiplyForCoins).ToString();
                    levelOfSword2 += 1;
                    //UpgradeWeapon(levelOfSword2, _sword2)
                    if (levelOfSword2 - 1 == 4)
                    {
                        _upgrade[typeOfSword - 1].interactable = false;
                        _coinCost[typeOfSword + 3].text = "MAX";
                        _coinSprites[typeOfSword + 3].gameObject.SetActive(false);
                    }
                }
                break;
            case 3:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword + 3].text))
                {
                    _coins.text = (Convert.ToInt32(_coinCost[typeOfSword + 3].text) - Convert.ToInt32(_coins.text)).ToString();
                    _coinCost[typeOfSword + 3].text = (Convert.ToInt32(_coinCost[typeOfSword + 3].text) *
                                                       _multiplyForCoins).ToString();
                    levelOfSword3 += 1;
                    //UpgradeWeapon(levelOfSword3, _sword3)
                    if (levelOfSword3 - 1 == 4)
                    {
                        _upgrade[typeOfSword - 1].interactable = false;
                        _coinCost[typeOfSword + 3].text = "MAX";
                        _coinSprites[typeOfSword + 3].gameObject.SetActive(false);
                    }
                }
                break;
            /*case 4:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword + 3].text))
                {
                    _coins.text = (Convert.ToInt32(_coinCost[typeOfSword + 3].text) - Convert.ToInt32(_coins.text)).ToString();
                    _coinCost[typeOfSword + 3].text = (Convert.ToInt32(_coinCost[typeOfSword + 3].text) *
                                                       _multiplyForCoins).ToString();
                    levelOfSword4 += 1;
                    //UpgradeWeapon(levelOfSword4, _spear)
                    if (levelOfSword4 - 1 == 4)
                    {
                        _upgrade[typeOfSword - 1].interactable = false;
                        _coinCost[typeOfSword + 3].text = "MAX";
                        _coinSprites[typeOfSword + 3].gameObject.SetActive(false);
                    }
                }
                break;*/
        }
    }

    public void Pick(int typeOfSword)
    {
        switch (typeOfSword)
        {
            case 1:
                _pick[typeOfSword - 1].interactable = false;
                _sword1.SetActive(true);
                _sword2.SetActive(false);
                _sword3.SetActive(false);
                break;
            case 2:
                _pick[typeOfSword - 1].interactable = false;
                _sword1.SetActive(false);
                _sword2.SetActive(true);
                _sword3.SetActive(false);
                break;
            case 3:
                _pick[typeOfSword - 1].interactable = false;
                _sword1.SetActive(false);
                _sword2.SetActive(false);
                _sword3.SetActive(true);
                break;
        }
    }

    /*private void UpgradeWeapon(int level, GameObject weapon)
    {
        WeaponScript damage = weapon.GetComponent<WeaponScript>;
        damage.damage = level * _multiplyForWeapon;
    }*/

    private void OnDisable()
    {
        SaveShop();
    }

    private void SaveShop()
    {
        switch (nameSave)
        {
            case "save1":
                PlayerPrefs.SetInt("Coins1", Convert.ToInt32(_coins.text));
                PlayerPrefs.SetInt("LevelSword1.1", levelOfSword1);
                PlayerPrefs.SetInt("LevelSword2.1", levelOfSword2);
                PlayerPrefs.SetInt("LevelSword3.1", levelOfSword3);
                PlayerPrefs.SetInt("LevelSword4.1", levelOfSword4);
                break;
            case "save2":
                PlayerPrefs.SetInt("Coins2", Convert.ToInt32(_coins.text));
                PlayerPrefs.SetInt("LevelSword1.2", levelOfSword1);
                PlayerPrefs.SetInt("LevelSword2.2", levelOfSword2);
                PlayerPrefs.SetInt("LevelSword3.2", levelOfSword3);
                PlayerPrefs.SetInt("LevelSword4.2", levelOfSword4);
                break;
            case "save3":
                PlayerPrefs.SetInt("Coins3", Convert.ToInt32(_coins.text));
                PlayerPrefs.SetInt("LevelSword1.3", levelOfSword1);
                PlayerPrefs.SetInt("LevelSword2.3", levelOfSword2);
                PlayerPrefs.SetInt("LevelSword3.3", levelOfSword3);
                PlayerPrefs.SetInt("LevelSword4.3", levelOfSword4);
                break;
        }
    }

    private void LoadShop()
    {
        int j;
        switch (nameSave)
        {
            case "save1":
                j = 0;
                if (PlayerPrefs.HasKey("LevelSword1.1"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword1.1");
                    _buy[j].interactable = false;
                    _upgrade[j].interactable = true;
                    _coinCost[j].gameObject.SetActive(false);
                    _coinSprites[j].gameObject.SetActive(false);
                    _coinCost[j + 4].gameObject.SetActive(true);
                    _coinSprites[j + 4].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 4].text = (Convert.ToInt32(_coinCost[j + 4].text) *
                                                           _multiplyForCoins).ToString();
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword2.1"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword2.1");
                    _buy[j + 1].interactable = false;
                    _upgrade[j + 1].interactable = true;
                    _coinCost[j + 1].gameObject.SetActive(false);
                    _coinSprites[j + 1].gameObject.SetActive(false);
                    _coinCost[j + 5].gameObject.SetActive(true);
                    _coinSprites[j + 5].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 5].text = (Convert.ToInt32(_coinCost[j + 5].text) *
                                                 _multiplyForCoins).ToString();
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword3.1"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword3.1");
                    _buy[j + 2].interactable = false;
                    _upgrade[j + 2].interactable = true;
                    _coinCost[j + 2].gameObject.SetActive(false);
                    _coinSprites[j + 2].gameObject.SetActive(false);
                    _coinCost[j + 6].gameObject.SetActive(true);
                    _coinSprites[j + 6].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 6].text = (Convert.ToInt32(_coinCost[j + 6].text) *
                                                 _multiplyForCoins).ToString();
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword4.1"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword4.1");
                    _buy[j + 3].interactable = false;
                    _upgrade[j + 3].interactable = true;
                    _coinCost[j + 3].gameObject.SetActive(false);
                    _coinSprites[j + 3].gameObject.SetActive(false);
                    _coinCost[j + 7].gameObject.SetActive(true);
                    _coinSprites[j + 7].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 7].text = (Convert.ToInt32(_coinCost[j + 7].text) *
                                                 _multiplyForCoins).ToString();
                    }
                }
                break;
            case "save2":
                j = 0;
                if (PlayerPrefs.HasKey("LevelSword1.2"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword1.2");
                    _buy[j].interactable = false;
                    _upgrade[j].interactable = true;
                    _coinCost[j].gameObject.SetActive(false);
                    _coinSprites[j].gameObject.SetActive(false);
                    _coinCost[j + 4].gameObject.SetActive(true);
                    _coinSprites[j + 4].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 4].text = (Convert.ToInt32(_coinCost[j + 4].text) *
                                                           _multiplyForCoins).ToString();
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword2.2"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword2.2");
                    _buy[j + 1].interactable = false;
                    _upgrade[j + 1].interactable = true;
                    _coinCost[j + 1].gameObject.SetActive(false);
                    _coinSprites[j + 1].gameObject.SetActive(false);
                    _coinCost[j + 5].gameObject.SetActive(true);
                    _coinSprites[j + 5].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 5].text = (Convert.ToInt32(_coinCost[j + 5].text) *
                                                 _multiplyForCoins).ToString();
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword3.2"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword3.2");
                    _buy[j + 2].interactable = false;
                    _upgrade[j + 2].interactable = true;
                    _coinCost[j + 2].gameObject.SetActive(false);
                    _coinSprites[j + 2].gameObject.SetActive(false);
                    _coinCost[j + 6].gameObject.SetActive(true);
                    _coinSprites[j + 6].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 6].text = (Convert.ToInt32(_coinCost[j + 6].text) *
                                                 _multiplyForCoins).ToString();
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword4.2"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword4.2");
                    _buy[j + 3].interactable = false;
                    _upgrade[j + 3].interactable = true;
                    _coinCost[j + 3].gameObject.SetActive(false);
                    _coinSprites[j + 3].gameObject.SetActive(false);
                    _coinCost[j + 7].gameObject.SetActive(true);
                    _coinSprites[j + 7].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 7].text = (Convert.ToInt32(_coinCost[j + 7].text) *
                                                 _multiplyForCoins).ToString();
                    }
                }
                break;
            case "save3":
                j = 0;
                if (PlayerPrefs.HasKey("LevelSword1.3"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword1.3");
                    _buy[j].interactable = false;
                    _upgrade[j].interactable = true;
                    _coinCost[j].gameObject.SetActive(false);
                    _coinSprites[j].gameObject.SetActive(false);
                    _coinCost[j + 4].gameObject.SetActive(true);
                    _coinSprites[j + 4].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 4].text = (Convert.ToInt32(_coinCost[j + 4].text) *
                                                           _multiplyForCoins).ToString();
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword2.3"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword2.3");
                    _buy[j + 1].interactable = false;
                    _upgrade[j + 1].interactable = true;
                    _coinCost[j + 1].gameObject.SetActive(false);
                    _coinSprites[j + 1].gameObject.SetActive(false);
                    _coinCost[j + 5].gameObject.SetActive(true);
                    _coinSprites[j + 5].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 5].text = (Convert.ToInt32(_coinCost[j + 5].text) *
                                                 _multiplyForCoins).ToString();
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword3.3"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword3.3");
                    _buy[j + 2].interactable = false;
                    _upgrade[j + 2].interactable = true;
                    _coinCost[j + 2].gameObject.SetActive(false);
                    _coinSprites[j + 2].gameObject.SetActive(false);
                    _coinCost[j + 6].gameObject.SetActive(true);
                    _coinSprites[j + 6].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 6].text = (Convert.ToInt32(_coinCost[j + 6].text) *
                                                 _multiplyForCoins).ToString();
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword4.3"))
                {
                    levelOfSword1 = PlayerPrefs.GetInt("LevelSword4.3");
                    _buy[j + 3].interactable = false;
                    _upgrade[j + 3].interactable = true;
                    _coinCost[j + 3].gameObject.SetActive(false);
                    _coinSprites[j + 3].gameObject.SetActive(false);
                    _coinCost[j + 7].gameObject.SetActive(true);
                    _coinSprites[j + 7].gameObject.SetActive(true);
                    for (int i = 0; i < levelOfSword1; i++)
                    {
                        _coinCost[j + 7].text = (Convert.ToInt32(_coinCost[j + 7].text) *
                                                 _multiplyForCoins).ToString();
                    }
                }
                break;
        }
    }
}
