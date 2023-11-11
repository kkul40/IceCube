using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public AudioClip checkPointAudio;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out PlayerControl playerControl))
        {
            SaveManager.instance.allGameDataHolder.PlayerLastCheckedPosition = transform.position;
            Camera.main.transform.position = transform.position;
            MusicManager.instance.PlayAudio(checkPointAudio);
            SaveManager.instance.SaveGame();
        }
    }
} 