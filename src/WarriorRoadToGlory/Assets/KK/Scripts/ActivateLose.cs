using TMPro;
using UnityEngine;

public class ActivateLose : MonoBehaviour
{
    [Header("Waves")] 
    [SerializeField] private GameObject _waveObject;
    
    [Header("Lose Sets")]
    [SerializeField] private GameObject _loseCanvas;
    [SerializeField] private TextMeshProUGUI _numbersOfWaves;
    [SerializeField] private TextMeshProUGUI _numbersOfcoins;

    private PlayerHp _playerHp;
    private WaveManager _waveManager;
    private int _hp;
    private string nameSave;
    private bool _active;

    private void Awake()
    {
        _active = false;
        _playerHp = GetComponent<PlayerHp>();
        _waveManager = _waveObject.GetComponent<WaveManager>();
        nameSave = PlayerPrefs.GetString("NameSave");
    }

    private void Update()
    {
        _hp = _playerHp.hp;
        if (_hp <= 0 && !_active)
        {
            _active = true;
            ActiveLose();
        }
    }

    private void ActiveLose()
    {
        _loseCanvas.SetActive(true);
        _numbersOfWaves.text = $"{_waveManager.waveNumber - 1} волн";
    }

    public void DeleteSave()
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
