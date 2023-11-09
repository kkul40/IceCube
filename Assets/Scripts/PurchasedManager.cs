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
    
    
    public bool SatinAl(int fiyat)
    {
        if (SaveHelper.GetCandyCount() - fiyat < 0) return false;
        
        SaveHelper.SaveCandy(-fiyat);
        return true;
    }
    
    
}
