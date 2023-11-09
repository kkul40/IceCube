using UnityEngine;
using UnityEngine.Serialization;

public class ParticalEffect : MonoBehaviour
{
    [FormerlySerializedAs("ParticalPrefa")] [SerializeField] private Transform ParticalPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.TryGetComponent(out PlayerControl playerControl))
        {
            var temp = Instantiate(ParticalPrefab, transform);

            Destroy(temp.gameObject, 3);
        }
    }
}
