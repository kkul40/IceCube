using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    public List<Rigidbody2D> rigidbody2Ds;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.TryGetComponent(out PlayerControl playerControl))
            StartCoroutine(StartFalling());
    }

    IEnumerator StartFalling()
    {
        yield return new WaitForSeconds(1f);

        foreach (var rigit in rigidbody2Ds)
        {
            rigit.gravityScale = 1f;
            yield return new WaitForSeconds(1f);
        }
    }
}
