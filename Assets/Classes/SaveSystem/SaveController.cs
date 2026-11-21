using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    [SerializeField] private Player playerObject;
    [SerializeField] private SceneChangeScript sceneChanger;

    private string saveFolder => Path.Combine(Application.persistentDataPath, "WayfarerSaves");
    private string SavePath => Path.Combine(saveFolder, "save.json");
    private string DefaultPath => Path.Combine(saveFolder, "defaultSave.json");
    public bool HasSaveFile => File.Exists(SavePath);

    private void Start()
    {
        Directory.CreateDirectory(saveFolder);
        
        playerObject = Player.Instance;

        if (playerObject == null)
        {
            Debug.LogError("Player not found!");
            return;
        }

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
        data.scene = SceneManager.GetActiveScene().name;

        return data;
    }


    public void SaveGame()
    {
        Directory.CreateDirectory(saveFolder);

        SaveData data = CapturePlayerData();

        Debug.Log("Saving scene: " + data.scene);
        Debug.Log("Saving position: " + data.playerPosition);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);

        Debug.Log("Saved to: " + SavePath);
    }

    public void LoadGame()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("No save file found.");
            return;
        }

        playerObject = Player.Instance;

        if (playerObject == null || sceneChanger == null)
        {
            Debug.LogError("Player or SceneChanger not found!");
            return;
        }

        string json = File.ReadAllText(SavePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        if (data == null)
        {
            Debug.LogError("Could not read save data!");
            return;
        }

        playerObject.setHealth(data.playerHealth);

        // Load the scene, then restore the saved position
        sceneChanger.LoadSavedScene(data.scene, data.playerPosition);

        Debug.Log("Loading saved position: " + data.playerPosition);
    }

    public void ResetToDefault()
    {
        // Overwrite the working save with the default.
        File.Copy(DefaultPath, SavePath, true);

        LoadGame();
    }
}
