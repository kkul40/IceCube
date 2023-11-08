using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPmanager : MonoBehaviour
{
   
    private string ads = "com.celikgames.pengwin.ads";
   public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == ads)
        {
            
            print("Ba�ar�l�");
            
        }
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason purchaseFailureReason)
    {
        print("ba�ar�s�z");
    }
}
