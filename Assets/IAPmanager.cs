using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class IAPmanager : MonoBehaviour
{
    public GameObject reklamADS;
    private void Start()
    {
        if (PlayerPrefs.GetInt("reklam") == 1)
        {
            reklamADS.SetActive(false);
        }
        else
        {
            reklamADS.SetActive(true);
        }
        StandardPurchasingModule.Instance().useFakeStoreAlways = true;
    }

    private string ads = "com.celikgames.pengwin.ads";
   public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == ads)
        {
            
            print("Ba�ar�l�");
            removeAds();
            
        }
    }
    
    public void OnPurchaseFailed(Product product, PurchaseFailureReason purchaseFailureReason)
    {
        print("ba�ar�s�z");
    }

    private void removeAds()
    {
        reklamADS.SetActive(false);
        PlayerPrefs.SetInt("reklam", 1);
        SceneManager.LoadScene(0);
        


    }
}
