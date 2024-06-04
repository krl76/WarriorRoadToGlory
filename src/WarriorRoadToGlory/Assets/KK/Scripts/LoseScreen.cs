using TMPro;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private GameObject _vignette;
    [SerializeField] private TextMeshProUGUI _wave;
    [SerializeField] private string _nameOfMenuScene;

    private int _numberOfWave;
    private string nameSave;

    private void OnEnable()
    {
        foreach (var obj in FindObjectsOfType<SoundsShield>())
        {
            Destroy(obj.gameObject);
        }
        _vignette.SetActive(false);
        Time.timeScale = 0f;
        _numberOfWave = FindObjectOfType<WaveManager>().waveNumber;
        _wave.text = $"{_numberOfWave - 1} волн";
        nameSave = PlayerPrefs.GetString("NameSave");
        DeleteSave();
    }

    public void ToMenu()
    {
        Time.timeScale = 1f;
        FindObjectOfType<LoadScene>().SceneLoad(_nameOfMenuScene);
    }
    
    private void DeleteSave()
    {
        switch (nameSave)
        {
            case "save1":
                PlayerPrefs.DeleteKey("Coins1");
                PlayerPrefs.DeleteKey("Wave1");
                PlayerPrefs.DeleteKey("Save1");
                PlayerPrefs.DeleteKey("LevelSword1.1");
                PlayerPrefs.DeleteKey("LevelSword2.1");
                PlayerPrefs.DeleteKey("LevelSword3.1");
                PlayerPrefs.DeleteKey("LevelSword4.1");
                break;
            case "save2":
                PlayerPrefs.DeleteKey("Coins2");
                PlayerPrefs.DeleteKey("Wave2");
                PlayerPrefs.DeleteKey("Save2");
                PlayerPrefs.DeleteKey("LevelSword1.2");
                PlayerPrefs.DeleteKey("LevelSword2.2");
                PlayerPrefs.DeleteKey("LevelSword3.2");
                PlayerPrefs.DeleteKey("LevelSword4.2");
                break;
            case "save3":
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
}
