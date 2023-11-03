using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out PlayerControl playerControl))
        {
            SaveHelper.SavePlayerPos(transform.position);
        }
    }
} 