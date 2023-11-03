using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public Transform StartPos;

    private void Awake()
    {
        Application.targetFrameRate = 120;


        if (instance == null)
        {
            instance = this;
            SaveHelper.SavePlayerPos(StartPos.position);
        }
        else
            Destroy(this);
        
        DontDestroyOnLoad(this);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
}