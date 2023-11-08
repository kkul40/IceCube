using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public AudioClip checkPointAudio;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out PlayerControl playerControl))
        {
            SaveHelper.SavePlayerPos(transform.position);
            Camera.main.transform.position = transform.position;
            MusicManager.instance.PlayAudio(checkPointAudio);
        }
    }
} 