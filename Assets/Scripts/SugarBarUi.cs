using System;
using TMPro;
using UnityEngine;

public class SugarBarUi : MonoBehaviour
{
    public TextMeshProUGUI textForCandy;

    private void Start()
    {
        UpdateText();
    }

    private void OnEnable()
    {
        CandyBehaviour.OnCandyCollected += UpdateText;
        RewardAD.RewardCandy += UpdateText;
        SaveManager.GameSaved += UpdateText;
    }
    
    private void OnDisable()
    {
        CandyBehaviour.OnCandyCollected -= UpdateText;
        RewardAD.RewardCandy -= UpdateText;
        SaveManager.GameSaved -= UpdateText;
    }

    private void UpdateText()
    {
        textForCandy.text = SaveManager.instance.allGameDataHolder.CandyCount.ToString();
    }
}
