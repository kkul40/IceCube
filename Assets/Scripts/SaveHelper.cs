﻿using System;
using UnityEngine;

public static class SaveHelper
{
    public static event Action OnCandyCollected; 
    
    /// <summary>
    /// Saves Player Position
    /// </summary>
    /// <param name="pos"></param>
    public static void SavePlayerPos(Vector3 pos)
    {
        PlayerPrefs.SetFloat("x", pos.x);
        PlayerPrefs.SetFloat("y", pos.y);
        PlayerPrefs.SetFloat("z", pos.z);
    }

    /// <summary>
    /// Loads Player Position
    /// </summary>
    /// <returns></returns>
    public static Vector3 LoadPlayerPos()
    {
        var pos = Vector3.zero;

        pos.x = PlayerPrefs.GetFloat("x");
        pos.y = PlayerPrefs.GetFloat("y");
        pos.z = PlayerPrefs.GetFloat("z");

        return pos;
    }


    /// <summary>
    /// Resets Player Position Data to Start Position
    /// </summary>
    public static void ResetData()
    {
        SavePlayerPos(GameData.instance.StartPos.position);
    }
    
    public static void SaveCandy(int addCandy)
    {
        int a = GetCandyCount() + addCandy;
        PlayerPrefs.SetInt("CandyCount", a);
        OnCandyCollected?.Invoke();
    }

    public static int GetCandyCount()
    {
        // OnCandyCollected?.Invoke();
        return PlayerPrefs.GetInt("CandyCount");
    }
}
