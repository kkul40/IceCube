using System;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string savePath;

    public static SaveManager instance;
    public static event Action GameSaved;
    
    public AllGameDataHolder allGameDataHolder;

    private void Awake()
    {
        if (instance != null && instance != this) 
            Destroy(this.gameObject); 
        else 
            instance = this; 
        
        DontDestroyOnLoad(this);
        
        savePath = Path.Combine(Application.persistentDataPath, "saveData.json");

        if (!File.Exists(savePath))
        {
            File.Create(Application.persistentDataPath + "/saveData.json");
        }
        
        allGameDataHolder = new AllGameDataHolder();
        allGameDataHolder = LoadGame();
    }

    public void SaveGame(AllGameDataHolder data)
    {
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, jsonData);
        Debug.Log("Game is Saved");
        GameSaved?.Invoke();
    }

    public void SaveGame()
    {
        SaveGame(allGameDataHolder);
    }
    
    
    [ContextMenu("Set GameData to default")]
    public void SetSettingToDefault()
    {
        allGameDataHolder = new AllGameDataHolder();
        SaveGame(allGameDataHolder);
    }

    public AllGameDataHolder LoadGame()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            return JsonUtility.FromJson<AllGameDataHolder>(jsonData);
        }
        else
        {
            Debug.LogWarning("No saved data found.");
            return null;
        }
    }
}

[Serializable]
public class AllGameDataHolder
{
    // PlayerData
    public Vector3 PlayerLastCheckedPosition = new Vector3(-142, -6, 0);
    public int CandyCount = 0;
    public int CurrentSapkaID = 0;
    
    // CanvasData
    public bool showTutorial = true;
    
    
    // SoundData
    public float MusicVolume = 1;
    public float SoundEffectVolume = 1;
    public bool isMuted = false;
}