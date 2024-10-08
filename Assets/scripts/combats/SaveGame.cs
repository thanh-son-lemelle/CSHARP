using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

[System.Serializable] 
public class GameData {
    public string time; 
    public string date;    
}

[System.Serializable]
public class GameDataList { 
    public List<GameData> gameDataList = new List<GameData>();
}

public class SaveGame : MonoBehaviour
{
    private string fileJsonPath; // Path for the Json file
    private GameDataList gameDataList = new GameDataList(); // Instance to store data

    private void Start() {

        // Indicate the path to save the JSON data        
        fileJsonPath = Path.Combine(Application.dataPath, "data", "savedDataGame.json"); 

        // Create the json" file if it doesn't exist
        if (!File.Exists(fileJsonPath)) {
            File.Create(fileJsonPath).Close(); 
            Debug.Log("File does not exist, creating: " + fileJsonPath);
        }

        // Load existing data if the file exists
        else {
            LoadData(); 
        }
    }

    // Method to load the data from the JSON file
    public void LoadData()
    {
        if (File.Exists(fileJsonPath))
        {
            // Read the JSON string from the file
            string json = File.ReadAllText(fileJsonPath);
            
            // Convert the JSON string to a GameDataList object
            gameDataList = JsonUtility.FromJson<GameDataList>(json);
            Debug.Log("Data loaded from " + fileJsonPath);

            // Display data from the gameDataList
            GetDataByIndex(2); // only Data from Index 2
            DisplayTerminalData(); // All data
            
        }
        else
        {
            Debug.Log("! File not found: " + fileJsonPath);
        }   
    }

    // Display all Data from the list gameDataList
    public void DisplayTerminalData () {

             // Display the loaded data in the console
            foreach (GameData data in gameDataList.gameDataList)
            {
                Debug.Log($"Loaded Data - Time: {data.time}, Date: {data.date}");
            }                 
    }

    // Display data according to an index
    public void GetDataByIndex(int index) {
        if (index >= 0 && index < gameDataList.gameDataList.Count) {
            GameData data = gameDataList.gameDataList[index];
            Debug.Log($"Selected Data - Index: {index}, Time: {data.time}, Date: {data.date}");
        } else {
            Debug.Log($"Invalid index: {index}. Please enter a value between 0 and {gameDataList.gameDataList.Count - 1}.");
        }
    }

    // Method to save the time and date
    public void SaveTimeDate() {

        GameData timeData = new GameData
        {
            time = DateTime.Now.ToString("HH:mm:ss"),
            date = DateTime.Now.ToString("yyyy-MM-dd")
        };

        // Add the new data to the list
        gameDataList.gameDataList.Add(timeData);


        // Convert the list to JSON
        string json = JsonUtility.ToJson(gameDataList, true);

        // Write the JSON string to the file
        File.WriteAllText(fileJsonPath, json);

        Debug.Log("Data saved to " + fileJsonPath);    

        // Allow only 4 elements to be savec   
    }
}
