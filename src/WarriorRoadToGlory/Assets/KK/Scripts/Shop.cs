using System;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class Shop : MonoBehaviour
{
    [Header("Weapons")] 
    [SerializeField] private GameObject _sword1;
    [SerializeField] private GameObject _sword2;
    [SerializeField] private GameObject _sword3;
    [SerializeField] private GameObject _shield;
    [SerializeField] private float _multiplyForWeapon;

    [Header("Buttons")] 
    [SerializeField] private Button[] _buy;
    [SerializeField] private Button[] _pick;
    [SerializeField] private Button[] _upgrade;


    [Header("Coins")]
    [SerializeField] private TextMeshProUGUI[] _coinCost;
    [SerializeField] private GameObject[] _coinSprites;
    [SerializeField] private float _multiplyForCoins;

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
    }

    private void Start()
    {
        LoadShop();
    }

    public void Buy(int typeOfSword)
    {
        switch (typeOfSword)
        {
            case 2:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword - 1].text))
                {
                    _coins.text = (Convert.ToInt32(_coins.text) - Convert.ToInt32(_coinCost[typeOfSword - 1].text)).ToString();
                    _buy[typeOfSword - 1].gameObject.SetActive(false);
                    _upgrade[typeOfSword - 1].interactable = true;
                    _coinCost[typeOfSword - 1].gameObject.SetActive(false);
                    _coinSprites[typeOfSword - 1].gameObject.SetActive(false);
                    _coinCost[typeOfSword + 3].gameObject.SetActive(true);
                    _coinSprites[typeOfSword + 3].gameObject.SetActive(true);
                    levelOfSword2 = 1;
                    _pick[typeOfSword - 1].gameObject.SetActive(true);
                }
                break;
            case 3:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword - 1].text))
                {
                    _coins.text = (Convert.ToInt32(_coins.text) - Convert.ToInt32(_coinCost[typeOfSword - 1].text)).ToString();
                    _buy[typeOfSword - 1].gameObject.SetActive(false);
                    _upgrade[typeOfSword - 1].interactable = true;
                    _coinCost[typeOfSword - 1].gameObject.SetActive(false);
                    _coinSprites[typeOfSword - 1].gameObject.SetActive(false);
                    _coinCost[typeOfSword + 3].gameObject.SetActive(true);
                    _coinSprites[typeOfSword + 3].gameObject.SetActive(true);
                    levelOfSword3 = 1;
                    _pick[typeOfSword - 1].gameObject.SetActive(true);
                }
                break;
            case 4:
                if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword - 1].text))
                {
                    _coins.text = (Convert.ToInt32(_coins.text) - Convert.ToInt32(_coinCost[typeOfSword - 1].text)).ToString();
                    _buy[typeOfSword - 1].interactable = false;
                    _coinCost[typeOfSword - 1].gameObject.SetActive(false);
                    _coinSprites[typeOfSword - 1].gameObject.SetActive(false);
                    levelOfSword4 = 1;
                    _shield.SetActive(true);
                }
                break;
        }
    }

    public void Upgrade(int typeOfSword)
    {
        if(typeOfSword == 1)
        {
            if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword + 3].text))
            {
                _coins.text = (Convert.ToInt32(_coins.text) - Convert.ToInt32(_coinCost[typeOfSword + 3].text)).ToString();
                _coinCost[typeOfSword + 3].text = Convert.ToInt32((Convert.ToInt32(_coinCost[typeOfSword + 3].text) *
                                                   _multiplyForCoins)).ToString();
                levelOfSword1 += 1;
                if (levelOfSword1 - 1 == 4)
                {
                    _upgrade[typeOfSword - 1].interactable = false;
                    _coinCost[typeOfSword + 3].text = "MAX";
                    _coinSprites[typeOfSword + 3].gameObject.SetActive(false);
                }
                UpgradeWeapon(typeOfSword);
            }
        }
        if(typeOfSword == 2)
        {
            if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword + 3].text))
            {
                _coins.text = (Convert.ToInt32(_coins.text) - Convert.ToInt32(_coinCost[typeOfSword + 3].text)).ToString();
                _coinCost[typeOfSword + 3].text = Convert.ToInt32((Convert.ToInt32(_coinCost[typeOfSword + 3].text) *
                                                   _multiplyForCoins)).ToString();
                levelOfSword2 += 1;
                if (levelOfSword2 - 1 == 4)
                {
                    _upgrade[typeOfSword - 1].interactable = false;
                    _coinCost[typeOfSword + 3].text = "MAX";
                    _coinSprites[typeOfSword + 3].gameObject.SetActive(false);
                }
                UpgradeWeapon(typeOfSword);
            }
        }
        if(typeOfSword == 3)
        {
            if (Convert.ToInt32(_coins.text) >= Convert.ToInt32(_coinCost[typeOfSword + 3].text))
            {
                _coins.text = (Convert.ToInt32(_coins.text) - Convert.ToInt32(_coinCost[typeOfSword + 3].text)).ToString(); ;
                _coinCost[typeOfSword + 3].text = Convert.ToInt32((Convert.ToInt32(_coinCost[typeOfSword + 3].text) *
                                                   _multiplyForCoins)).ToString();
                levelOfSword3 += 1;
                if (levelOfSword3 - 1 == 4)
                {
                    _upgrade[typeOfSword - 1].interactable = false;
                    _coinCost[typeOfSword + 3].text = "MAX";
                    _coinSprites[typeOfSword + 3].gameObject.SetActive(false);
                }
                UpgradeWeapon(typeOfSword);
            }
        }
    }

    public void Pick(int typeOfSword)
    {
        switch (typeOfSword)
        {
            case 1:
                _pick[typeOfSword - 1].interactable = false;
                _pick[typeOfSword].interactable = true;
                _pick[typeOfSword + 1].interactable = true;
                _sword1.SetActive(true);
                _sword2.SetActive(false);
                _sword3.SetActive(false);
                break;
            case 2:
                _pick[typeOfSword - 1].interactable = false;
                _pick[typeOfSword].interactable = true;
                _pick[typeOfSword - 2].interactable = true;
                _sword1.SetActive(false);
                _sword2.SetActive(true);
                _sword3.SetActive(false);
                break;
            case 3:
                _pick[typeOfSword - 1].interactable = false;
                _pick[typeOfSword - 2].interactable = true;
                _pick[typeOfSword - 3].interactable = true;
                _sword1.SetActive(false);
                _sword2.SetActive(false);
                _sword3.SetActive(true);
                break;
        }
    }

    private void UpgradeWeapon(int typeOfSword)
    {
        Weapon weaponScript = FindObjectOfType<Weapon>();
        if(typeOfSword == 1) {
            weaponScript._weapon1Damage *= _multiplyForWeapon;
            _sword1.GetComponent<TakeDamage>().Upgrade();
        }
        if (typeOfSword == 2)
        {
            weaponScript._weapon2Damage *= _multiplyForWeapon;
            _sword1.GetComponent<TakeDamage>().Upgrade();
        }
        if (typeOfSword == 3)
        {
            weaponScript._weapon3Damage *= _multiplyForWeapon;
            _sword1.GetComponent<TakeDamage>().Upgrade();
        }
        
    }

    public void SaveShop()
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

    public void LoadShop()
    {
        int j;
        switch (nameSave)
        {
            case "save1":
                j = 0;
                if (PlayerPrefs.HasKey("LevelSword1.1"))
                {
                    if (PlayerPrefs.GetInt("LevelSword1.1") != 0)
                    {
                        int levelOfSword11 = PlayerPrefs.GetInt("LevelSword1.1");
                        _buy[j].gameObject.SetActive(false);
                        _pick[j].gameObject.SetActive(true);
                        _pick[j].interactable = false;
                        _upgrade[j].interactable = true;
                        _coinCost[j].gameObject.SetActive(false);
                        _coinSprites[j].gameObject.SetActive(false);
                        _coinCost[j + 4].gameObject.SetActive(true);
                        _coinSprites[j + 4].gameObject.SetActive(true);
                        for (int i = 0; i < levelOfSword11; i++)
                        {
                            _coinCost[4].text = Convert.ToInt32((Convert.ToInt32(_coinCost[4].text) *
                                   _multiplyForCoins)).ToString();
                            levelOfSword1 += 1;
                            if (levelOfSword1 - 1 == 4)
                            {
                                _upgrade[1 - 1].interactable = false;
                                _coinCost[4].text = "MAX";
                                _coinSprites[4].gameObject.SetActive(false);
                            }
                            UpgradeWeapon(1);
                        }   
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword2.1"))
                {
                    if (PlayerPrefs.GetInt("LevelSword2.1") != 0)
                    {
                        int levelOfSword12 = PlayerPrefs.GetInt("LevelSword2.1");
                        _buy[j + 1].gameObject.SetActive(false);
                        _pick[j + 1].gameObject.SetActive(true);
                        _pick[j + 1].interactable = true;
                        _upgrade[j + 1].interactable = true;
                        _coinCost[j + 1].gameObject.SetActive(false);
                        _coinSprites[j + 1].gameObject.SetActive(false);
                        _coinCost[j + 5].gameObject.SetActive(true);
                        _coinSprites[j + 5].gameObject.SetActive(true);
                        for (int i = 0; i < levelOfSword12; i++)
                        {
                            _coinCost[5].text = Convert.ToInt32((Convert.ToInt32(_coinCost[5].text) *
                                   _multiplyForCoins)).ToString();
                            levelOfSword2 += 1;
                            if (levelOfSword2 - 1 == 4)
                            {
                                _upgrade[2 - 1].interactable = false;
                                _coinCost[5].text = "MAX";
                                _coinSprites[5].gameObject.SetActive(false);
                            }
                            UpgradeWeapon(2);
                        }
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword3.1"))
                {
                    if (PlayerPrefs.GetInt("LevelSword3.1") != 0)
                    {
                        int levelOfSword13 = PlayerPrefs.GetInt("LevelSword3.1");
                        _buy[j + 2].gameObject.SetActive(false);
                        _pick[j + 2].gameObject.SetActive(true);
                        _pick[j + 2].interactable = true;
                        _upgrade[j + 2].interactable = true;
                        _coinCost[j + 2].gameObject.SetActive(false);
                        _coinSprites[j + 2].gameObject.SetActive(false);
                        _coinCost[j + 6].gameObject.SetActive(true);
                        _coinSprites[j + 6].gameObject.SetActive(true);
                        for (int i = 0; i < levelOfSword13; i++)
                        {
                            _coinCost[6].text = Convert.ToInt32((Convert.ToInt32(_coinCost[6].text) *
                                   _multiplyForCoins)).ToString();
                            levelOfSword3 += 1;
                            if (levelOfSword3 - 1 == 4)
                            {
                                _upgrade[3 - 1].interactable = false;
                                _coinCost[6].text = "MAX";
                                _coinSprites[6].gameObject.SetActive(false);
                            }
                            UpgradeWeapon(3);
                        }
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword4.1"))
                {
                    if (PlayerPrefs.GetInt("LevelSword4.1") != 0)
                    {
                        levelOfSword4 = PlayerPrefs.GetInt("LevelSword4.1");
                        _shield.SetActive(true);
                        _buy[j + 3].interactable = false;
                        _coinCost[j + 3].gameObject.SetActive(false);
                        _coinSprites[j + 3].gameObject.SetActive(false);
                    }
                }
                break;
            case "save2":
                j = 0;
                if (PlayerPrefs.HasKey("LevelSword1.2"))
                {
                    if (PlayerPrefs.GetInt("LevelSword1.2") != 0)
                    {
                        levelOfSword1 = PlayerPrefs.GetInt("LevelSword1.2");
                        _buy[j].gameObject.SetActive(false);
                        _pick[j].gameObject.SetActive(true);
                        _pick[j].interactable = false;
                        _upgrade[j].interactable = true;
                        _coinCost[j].gameObject.SetActive(false);
                        _coinSprites[j].gameObject.SetActive(false);
                        _coinCost[j + 4].gameObject.SetActive(true);
                        _coinSprites[j + 4].gameObject.SetActive(true);
                        for (int i = 0; i < levelOfSword1; i++)
                        {
                            Upgrade(1);
                        }
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword2.2"))
                {
                    if (PlayerPrefs.GetInt("LevelSword2.2") != 0)
                    {
                        levelOfSword2 = PlayerPrefs.GetInt("LevelSword2.2");
                        _buy[j + 1].gameObject.SetActive(false);
                        _pick[j + 1].gameObject.SetActive(true);
                        _pick[j + 1].interactable = true;
                        _upgrade[j + 1].interactable = true;
                        _coinCost[j + 1].gameObject.SetActive(false);
                        _coinSprites[j + 1].gameObject.SetActive(false);
                        _coinCost[j + 5].gameObject.SetActive(true);
                        _coinSprites[j + 5].gameObject.SetActive(true);
                        for (int i = 0; i < levelOfSword2; i++)
                        {
                            Upgrade(2);
                        }
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword3.2"))
                {
                    if (PlayerPrefs.GetInt("LevelSword3.2") != 0)
                    {
                        levelOfSword3 = PlayerPrefs.GetInt("LevelSword3.2");
                        _buy[j + 2].gameObject.SetActive(false);
                        _pick[j + 2].gameObject.SetActive(true);
                        _pick[j + 2].interactable = true;
                        _upgrade[j + 2].interactable = true;
                        _coinCost[j + 2].gameObject.SetActive(false);
                        _coinSprites[j + 2].gameObject.SetActive(false);
                        _coinCost[j + 6].gameObject.SetActive(true);
                        _coinSprites[j + 6].gameObject.SetActive(true);
                        for (int i = 0; i < levelOfSword3; i++)
                        {
                            Upgrade(3);
                        }
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword4.2"))
                {
                    if (PlayerPrefs.GetInt("LevelSword4.2") != 0)
                    {
                        levelOfSword4 = PlayerPrefs.GetInt("LevelSword4.2");
                        _buy[j + 3].interactable = false;
                        _shield.SetActive(true);
                        _coinCost[j + 3].gameObject.SetActive(false);
                        _coinSprites[j + 3].gameObject.SetActive(false);
                    }
                }
                break;
            case "save3":
                j = 0;
                if (PlayerPrefs.HasKey("LevelSword1.3"))
                {
                    if (PlayerPrefs.GetInt("LevelSword1.3") != 0)
                    {
                        levelOfSword1 = PlayerPrefs.GetInt("LevelSword1.3");
                        _buy[j].gameObject.SetActive(false);
                        _pick[j].gameObject.SetActive(true);
                        _pick[j].interactable = false;
                        _upgrade[j].interactable = true;
                        _coinCost[j].gameObject.SetActive(false);
                        _coinSprites[j].gameObject.SetActive(false);
                        _coinCost[j + 4].gameObject.SetActive(true);
                        _coinSprites[j + 4].gameObject.SetActive(true);
                        for (int i = 0; i < levelOfSword1; i++)
                        {
                            Upgrade(1);
                        }
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword2.3"))
                {
                    if (PlayerPrefs.GetInt("LevelSword2.3") != 0)
                    {
                        levelOfSword2 = PlayerPrefs.GetInt("LevelSword2.3");
                        _buy[j + 1].gameObject.SetActive(false);
                        _pick[j + 1].gameObject.SetActive(true);
                        _pick[j + 1].interactable = true;
                        _upgrade[j + 1].interactable = true;
                        _coinCost[j + 1].gameObject.SetActive(false);
                        _coinSprites[j + 1].gameObject.SetActive(false);
                        _coinCost[j + 5].gameObject.SetActive(true);
                        _coinSprites[j + 5].gameObject.SetActive(true);
                        for (int i = 0; i < levelOfSword2; i++)
                        {
                            Upgrade(2);
                        }
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword3.3"))
                {
                    if (PlayerPrefs.GetInt("LevelSword3.3") != 0)
                    {
                        levelOfSword3 = PlayerPrefs.GetInt("LevelSword3.3");
                        _buy[j + 2].gameObject.SetActive(false);
                        _pick[j + 2].gameObject.SetActive(true);
                        _pick[j + 2].interactable = true;
                        _upgrade[j + 2].interactable = true;
                        _coinCost[j + 2].gameObject.SetActive(false);
                        _coinSprites[j + 2].gameObject.SetActive(false);
                        _coinCost[j + 6].gameObject.SetActive(true);
                        _coinSprites[j + 6].gameObject.SetActive(true);
                        for (int i = 0; i < levelOfSword3; i++)
                        {
                            Upgrade(3);
                        }
                    }
                }
                if (PlayerPrefs.HasKey("LevelSword4.3"))
                {
                    if (PlayerPrefs.GetInt("LevelSword4.3") != 0)
                    {
                        levelOfSword4 = PlayerPrefs.GetInt("LevelSword4.3");
                        _buy[j + 3].interactable = false;
                        _shield.SetActive(true);
                        _coinCost[j + 3].gameObject.SetActive(false);
                        _coinSprites[j + 3].gameObject.SetActive(false);
                    }
                }
                break;
        }
    }
}
