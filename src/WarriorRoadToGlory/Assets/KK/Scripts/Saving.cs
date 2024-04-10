using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Saving : MonoBehaviour
{
    public string nameToSave;
    public int volumeToSave;
    public string difficultToSave;

    private MenuManager menuManager;

    private void Awake()
    {
        LoadGame();
    }

    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = new FileStream(Application.persistentDataPath 
                                      + "/MySaveData.dat", FileMode.OpenOrCreate); 
        SaveData data = new SaveData();
        data.saveName = nameToSave;
        data.volumeValue = volumeToSave;
        data.difficult = difficultToSave;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath 
                        + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                File.Open(Application.persistentDataPath 
                          + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            nameToSave = data.saveName;
            volumeToSave = data.volumeValue;
            difficultToSave = data.difficult;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}


[Serializable]
class SaveData
{
    public string saveName;
    public int volumeValue;
    public string difficult;
}