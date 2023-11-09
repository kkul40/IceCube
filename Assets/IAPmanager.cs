using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

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
            
            print("Baþarýlý");
            removeAds();
            
        }
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason purchaseFailureReason)
    {
        print("baþarýsýz");
    }

    private void removeAds()
    {

        GameObject.Find("ADSButton").SetActive(false);

    }
}
