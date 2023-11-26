using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class debebe : MonoBehaviour
{
   
    public GameObject bilgilendirmePaneli; // Unity Edit�r�nde bilgilendirme panelini bu de�i�kene ba�lay�n
    public TextMeshProUGUI bilgilendirmeText; // Unity Edit�r�nde bilgilendirme metni objesini bu de�i�kene ba�lay�n

    private bool ma�azayaGirdi = false;
    private float beklemeS�resi = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // "ShopTag" yerine kendi shop objenizin etiketini kullan�n
        {
            ma�azayaGirdi = true;
        }
    }

    void Update()
    {
        if (ma�azayaGirdi)
        {
            beklemeS�resi -= Time.deltaTime;

            if (beklemeS�resi <= 0f)
            {
                
                // Bilgilendirme mesaj�n� g�ster
                bilgilendirmePaneli.SetActive(true);
                bilgilendirmeText.text = ("You entered the store! Now, you can shop and will be directed to the menu. // Ma�azaya girdiniz! �imdi al��veri� yapabilir ve ard�ndan men�ye y�nlendirileceksiniz");
                // 2 saniye sonra men�ye y�nlendirme
                Invoke("MenuyeYonlendir", 7f);

                // Bu i�lemleri bir kere yapmak i�in ma�azayaGirdi'yi false yap
                ma�azayaGirdi = false;
            }
        }
    }

    void MenuyeYonlendir()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
        // Men� sahnesine ge�i� yap
        // SceneManager.LoadScene("MenuScene"); // "MenuScene" yerine kendi men� sahnenizin ad�n� kullan�n
        SaveManager.instance.SaveGame();
    }
}
