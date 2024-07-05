using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class SaveSerial : MonoBehaviour
{
    [SerializeField] private Health health;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(100, 0, 125, 50), "Save Your Game"))
            SaveGame();
        if (GUI.Button(new Rect(250, 0, 125, 50), "Load Your Game"))
            LoadGame();
        if (GUI.Button(new Rect(400, 0, 125, 50), "Reset Save Data"))
            ResetData();
    }

    void SaveGame()
    { 
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedHealth = health.currentHealth;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            health.currentHealth = data.savedHealth;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.Log("There is no save data!");
    }

    private void ResetData()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/MySaveData.dat");
            health.currentHealth = 100f;
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete!");
    }

    [Serializable]
    class SaveData
    {
        public float savedHealth;
    }
}
