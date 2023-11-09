using UnityEngine;

public class UiManagerForMainMenu : MonoBehaviour
{
    [Header("ShopMenu")] public GameObject ShopMenu;
    [Header("Credits")] public GameObject Credits;

    public AudioClip ShopOpenSound;
    public AudioClip ShopCloseSound;
    public AudioClip CreditsOpenSound;
    public AudioClip CreditsCloseSound;


    public void OpenShopMenu()
    {
        MusicManager.instance.PlayAudio(ShopOpenSound);
        ShopMenu.SetActive(true);
    }
    
    public void CloseShopMenu()
    {
        MusicManager.instance.PlayAudio(ShopCloseSound);
        ShopMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        MusicManager.instance.PlayAudio(CreditsOpenSound);
        Credits.SetActive(true);
    }
    
    public void CloseCredits()
    {
        MusicManager.instance.PlayAudio(CreditsCloseSound);
        Credits.SetActive(false);
    }
}
