using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string bestScoreName;
    public int bestScore;
    public string tmpName;
   

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public void Start()
    {
        LoadPlayer();
    }

    public void BestScorePlayer(int score)
    {
       if (bestScore < score)
        {
            bestScore = score;
            bestScoreName = tmpName;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerBestScoreName;
        public int playerBestScore;
    }

    public void SavePlayer()
    {
        SaveData saveData = new SaveData();
        saveData.playerBestScore = bestScore;
        saveData.playerBestScoreName = bestScoreName;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
   
    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScoreName = data.playerBestScoreName;
            bestScore = data.playerBestScore;
        }
    }
    
}
