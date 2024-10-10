using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LoadGameUI : MonoBehaviour
{


    public TextMeshProUGUI[] InfoGameDate; 
    public TextMeshProUGUI[] InfoGameTime; 
    public SaveGame saveGame; 


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log( "> START LOAD GAME");

        
        int i = 0; 
        foreach (GameData datum in saveGame.gameDataList.gameDataList){   
        InfoGameTime[i].text = datum.time; 
        InfoGameDate[i].text = datum.date; 
        i++; 

        Debug.Log( InfoGameTime[i].text +" "+ InfoGameTime[i].text);

        }
        
    }


}
