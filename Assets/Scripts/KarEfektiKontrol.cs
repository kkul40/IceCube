using UnityEngine;

public class KarEfektiKontrol : MonoBehaviour
{
    public GameObject karakter; // Oyuncu karakterini referans almak i�in bir de�i�ken

    void Update()
    {
        if (karakter != null)
        {
            Vector3 karakterKonumu = karakter.transform.position;
            transform.position = new Vector3(karakterKonumu.x,transform.position.y, transform.position.z);
        }
    }
}
