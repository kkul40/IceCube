using System;
using System.Collections.Generic;
using UnityEngine;

public class PurchasedManager : MonoBehaviour
{
    public static PurchasedManager instance;
    public List<Sapka> sapkalar;

    public Sapka currentSapka;

    private void Awake()
    {
        if (instance != null && instance != this) 
            Destroy(this.gameObject); 
        else 
            instance = this; 
        
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        var id = SaveManager.instance.allGameDataHolder.CurrentSapkaID;
        currentSapka = sapkalar.Find(obj => obj.id == id);
    }

    public bool SatinAl(Sapka sapka)
    {
        if (sapka.isSold)
        {
            currentSapka = sapka;
            SaveManager.instance.allGameDataHolder.CurrentSapkaID = sapka.id;
            SaveManager.instance.SaveGame();
            return true;
        }
        
        if (SaveManager.instance.allGameDataHolder.CandyCount - sapka.price < 0) return false;
        
        currentSapka = sapka;
        SaveManager.instance.allGameDataHolder.CandyCount -= sapka.price;
        SaveManager.instance.allGameDataHolder.CurrentSapkaID = sapka.id;
        SaveManager.instance.SaveGame();
        sapka.isSold = true;
        return true;
    }
    
    
}
