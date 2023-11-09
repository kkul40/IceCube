using System.Collections;
using UnityEngine;

public class Fallable : MonoBehaviour
{
    public float timerToFallDown;
    private Rigidbody2D rb2;


    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timerToFallDown);
        rb2.bodyType = RigidbodyType2D.Dynamic;
    }
}