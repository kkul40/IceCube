using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sapkaElements : MonoBehaviour
{
    public List<Sapka> sapkalar;
    public Sapka selectedSapka;

    public Transform slot;
    
    
    // Start is called before the first frame update
    void Start()
    {
        var temp = Resources.FindObjectsOfTypeAll<Sapka>();
        foreach (var item in temp)
        {
            sapkalar.Add(item);
            var slott = Instantiate(slot, transform);
            slott.GetComponent<SapkaSlot>().sapka = item;
        }
    }

    public void SelectSapka(Sapka sapka)
    {
        selectedSapka = sapka;
        PurchasedManager.instance.currentSapka = sapka;
    }

}
