using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManagerForMainMenu : MonoBehaviour
{
    [Header("ShopMenu")] public GameObject ShopMenu;
    [Header("Credits")] public GameObject Credits;


    public void OpenShopMenu()
    {
        ShopMenu.SetActive(true);
    }
    
    public void CloseShopMenu()
    {
        ShopMenu.SetActive(false);

    }



    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        Credits.SetActive(true);
    }
    
    public void CloseCredits()
    {
        Credits.SetActive(false);
    }
}
