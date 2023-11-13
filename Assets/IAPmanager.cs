using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class IAPmanager : MonoBehaviour
{

    private void Start()
    {
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
        SceneManager.LoadScene(0);
        GameObject.FindGameObjectWithTag("ReklamADS").SetActive(false);
        

    }
}
