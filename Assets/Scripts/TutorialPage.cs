using System;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPage : MonoBehaviour
{
    public AudioClip pageButtonAudio;
    public List<GameObject> Stages;

    public int currentStage = 0;
    
    private void OnEnable()
    {
        currentStage = 0;
        foreach (var sta in Stages)
        {
            sta.SetActive(false);
        }
        Stages[currentStage].SetActive(true);
    }

    public void Next()
    {
        MusicManager.instance.PlayAudio(pageButtonAudio);
        Stages[currentStage].SetActive(false);
        currentStage++;
        if (currentStage > Stages.Count - 1) return;
        Stages[currentStage].SetActive(true);
    }

    public void Previous()
    {
        Stages[currentStage].SetActive(false);
        currentStage--;
        if (currentStage < 0) return;
        Stages[currentStage].SetActive(true);
    }

    public void CloseTutorial()
    {
        MusicManager.instance.PlayAudio(pageButtonAudio);
        this.gameObject.SetActive(false);
        SaveManager.instance.allGameDataHolder.showTutorial = false;
        SaveManager.instance.SaveGame();
    }
}