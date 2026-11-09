using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{
    [SerializeField] private Player playerObject;

    public void SaveGame()
    {
        SaveData data = new SaveData(); //Create instance of SaveData class

        data.playerHealth = playerObject.getCurrentHealth(); //Store current health in SaveData instance
        data.playerPosition = playerObject.transform.position; //Store current position in SaveData instance

        string json = JsonUtility.ToJson(data, true); //Convert SaveData instance to JSON string
        Debug.Log(json);

        // Choose the folder location.
        string saveFolder = Path.Combine(Application.persistentDataPath, "WayfarerSaves");

        // Create the folder if it doesn't already exist.
        Directory.CreateDirectory(saveFolder);

        string path = Path.Combine(saveFolder, "save.json"); //This line sets the path
        File.WriteAllText(path, json); //Write JSON string to file. This line actually creates the file
    }

    public void LoadGame()
    {
        // For demonstration purposes, we will create a JSON string manually.
        // In a real scenario, you would load this from a file or PlayerPrefs.
        string path = Path.Combine(Application.persistentDataPath, "WayfarerSaves", "save.json");
        Debug.Log("Loading from: " + path);

        // Check if the file exists before attempting to read it
        if (!File.Exists(path))
        {
            Debug.Log("No save file found.");
            return;
        }

        string json = File.ReadAllText(path); //Read JSON file
        SaveData data = JsonUtility.FromJson<SaveData>(json); //Convert JSON string back to SaveData instance

        playerObject.setHealth(data.playerHealth); //Set player's health from loaded data
        playerObject.transform.position = data.playerPosition; //Set player's position from loaded data
    }

    public void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "WayfarerSaves", "save.json");
    }
}
