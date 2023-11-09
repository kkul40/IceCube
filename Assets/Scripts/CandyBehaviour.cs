using UnityEngine;

public class CandyBehaviour : MonoBehaviour, IInteractable
{
    public AudioClip candySound;
    public void Collect()
    {
        MusicManager.instance.PlayAudio(candySound);
        SaveHelper.SaveCandy(1);
        Destroy(this.gameObject);
    }
}
