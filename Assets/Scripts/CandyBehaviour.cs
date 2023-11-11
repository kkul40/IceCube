using System;
using UnityEngine;

public class CandyBehaviour : MonoBehaviour, IInteractable
{
    public AudioClip candySound;
    public static event Action OnCandyCollected;
    public void Collect()
    {
        MusicManager.instance.PlayAudio(candySound);
        SaveManager.instance.allGameDataHolder.CandyCount += 1;
        OnCandyCollected?.Invoke();
        Destroy(this.gameObject);
    }
}
