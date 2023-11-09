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
        SaveHelper.OnCandyCollected += UpdateText;
    }
    
    private void OnDisable()
    {
        SaveHelper.OnCandyCollected -= UpdateText;
    }

    private void UpdateText()
    {
        textForCandy.text = SaveHelper.GetCandyCount().ToString();
    }
}
