using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int highestWave;
    public string playerName;
}

public static class SaveSystem
{
    private static string saveFilePath = Application.persistentDataPath + "/saveData.json";

    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
        //Debug.Log("Data Saved to " + saveFilePath);
    }

    public static SaveData Load()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
           // Debug.LogWarning("Save file not found!");
            return null;
        }
    }
}
