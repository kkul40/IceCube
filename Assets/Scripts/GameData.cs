using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public Vector3 PlayerSpawnPoint;
    public Transform StartPos;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        
        
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        
        
        
        // SaveHelper.SavePlayerPos(StartPos.position);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
}