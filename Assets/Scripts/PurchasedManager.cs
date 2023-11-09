using System.Collections.Generic;
using UnityEngine;

public class PurchasedManager : MonoBehaviour
{
    public static PurchasedManager instance;
    public List<Sapka> sapkalar;

    public Sapka currentSapka;

    private void Awake()
    {
        if (instance == null) instance = this;
        
        DontDestroyOnLoad(this);
    }
    
    
    public bool SatinAl(Sapka sapka)
    {
        if (sapka.isSold) return true;
        
        if (SaveHelper.GetCandyCount() - sapka.price < 0) return false;
        
        SaveHelper.SaveCandy(-sapka.price);
        currentSapka = sapka;
        sapka.isSold = true;
        return true;
    }
    
    
}
