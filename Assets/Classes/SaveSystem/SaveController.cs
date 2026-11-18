using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{
    [SerializeField] private Player playerObject;

    private string saveFolder => Path.Combine(Application.persistentDataPath, "WayfarerSaves");
    private string SavePath => Path.Combine(saveFolder, "save.json");
    private string DefaultPath => Path.Combine(saveFolder, "defaultSave.json");

    private void Start()
    {
        Directory.CreateDirectory(saveFolder);

        // Create the default once, using the player's starting state.
        if (!File.Exists(DefaultPath))
        {
            SaveData defaultData = CapturePlayerData();

            string json = JsonUtility.ToJson(defaultData, true);
            File.WriteAllText(DefaultPath, json);
        }

        LoadGame();
    }

    private SaveData CapturePlayerData()
    {
        SaveData data = new SaveData();

        data.playerHealth = playerObject.getCurrentHealth();
        data.playerPosition = playerObject.transform.position;

        return data;
    }


    public void SaveGame()
    {
        Directory.CreateDirectory(saveFolder);

        SaveData data = CapturePlayerData();
        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(SavePath, json);
        Debug.Log("Game saved!");
    }

    public void LoadGame()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("No save file found.");
            return;
        }

        string json = File.ReadAllText(SavePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        playerObject.setHealth(data.playerHealth);
        playerObject.transform.position = data.playerPosition;

        Debug.Log("Game loaded!");
    }

    public void ResetToDefault()
    {
        // Overwrite the working save with the default.
        File.Copy(DefaultPath, SavePath, true);

        LoadGame();
    }
}
