using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class debebe : MonoBehaviour
{
   
    public GameObject bilgilendirmePaneli; // Unity Editöründe bilgilendirme panelini bu deðiþkene baðlayýn
    public TextMeshProUGUI bilgilendirmeText; // Unity Editöründe bilgilendirme metni objesini bu deðiþkene baðlayýn

    private bool maðazayaGirdi = false;
    private float beklemeSüresi = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // "ShopTag" yerine kendi shop objenizin etiketini kullanýn
        {
            maðazayaGirdi = true;
        }
    }

    void Update()
    {
        if (maðazayaGirdi)
        {
            beklemeSüresi -= Time.deltaTime;

            if (beklemeSüresi <= 0f)
            {
                
                // Bilgilendirme mesajýný göster
                bilgilendirmePaneli.SetActive(true);
                bilgilendirmeText.text = ("You entered the store! Now, you can shop and will be directed to the menu. // Maðazaya girdiniz! Þimdi alýþveriþ yapabilir ve ardýndan menüye yönlendirileceksiniz");
                // 2 saniye sonra menüye yönlendirme
                Invoke("MenuyeYonlendir", 7f);

                // Bu iþlemleri bir kere yapmak için maðazayaGirdi'yi false yap
                maðazayaGirdi = false;
            }
        }
    }

    void MenuyeYonlendir()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
        // Menü sahnesine geçiþ yap
        // SceneManager.LoadScene("MenuScene"); // "MenuScene" yerine kendi menü sahnenizin adýný kullanýn
        SaveManager.instance.SaveGame();
    }
}
