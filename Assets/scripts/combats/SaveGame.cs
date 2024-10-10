using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Unity.VisualScripting;

[System.Serializable] 
public class GameData {
    public string time; 
    public string date;  
    public List <Item> SavedInventory;  
    public List <Character> SavedPlayer;  
    // public List <Character> Savedenemy; 
}

[System.Serializable]
public class GameDataList { 
    public List<GameData> gameDataList = new List<GameData>();    
}

public class SaveGame : MonoBehaviour
{
    private string fileJsonPath; // Path for the Json file

    public GameDataList gameDataList = new GameDataList(); // Instance to store data


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

    // Method to delete data by index
   public void DeleteDataByIndex(int index) {

    if (index >= 0 && index < gameDataList.gameDataList.Count) {

        // Remove the element at the specified index
        gameDataList.gameDataList.RemoveAt(index);
        Debug.Log($"Data at index {index} deleted.");

        // Convert the updated list to JSON
        string json = JsonUtility.ToJson(gameDataList, true);

        // Check if the JSON string is correctly generated
        Debug.Log("Updated JSON Data: " + json);

        // Write the updated JSON string to the file
        try {
            File.WriteAllText(fileJsonPath, json);  // Overwrite the JSON file with the updated list
            Debug.Log("File successfully updated at " + fileJsonPath);
        } catch (Exception e) {
            Debug.LogError("Error writing to file: " + e.Message);
        }
    } else {
        Debug.Log($"Invalid index: {index}. Cannot delete data.");
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



    public void SaveAllGameInfo(){

        Debug.Log(" Length of inventory : " + GameController.Instance.inventory.itemList.Count);
        foreach(Item item in GameController.Instance.inventory.itemList){
            Debug.Log("Name : " + item.Name + " Type  : " + item.Type); 
        }
        // Instance to store data
        GameData gameData = new()
        {

        // Time and Date
        time = DateTime.Now.ToString("HH:mm"),
        date = DateTime.Now.ToString("yyyy-MM-dd"),
        
        // Inventory
        SavedInventory = GameController.Instance.inventory.itemList,

        // Players
        SavedPlayer = PlayerController.Instance.player.characters

        // Enemies
        // Savedenemy = PlayerController.Instance.player.characters,             
        };

        // If gameDataList has more than 4 entries, exit 
        if (gameDataList.gameDataList.Count >= 4) {
            Debug.Log("The list is full. Cannot save more than 4 entries.");
            return; 
        }

            // If less than 4 entries, save the data
        gameDataList.gameDataList.Add(gameData);


        // Convert the list to JSON
        string json = JsonUtility.ToJson(gameDataList, true);

        // Write the JSON string to the file
        File.WriteAllText(fileJsonPath, json);
        Debug.Log("> Save All Data Game Info to :  " + fileJsonPath);          
    
    }


}
