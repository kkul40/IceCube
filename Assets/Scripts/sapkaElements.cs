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
        foreach (var sapka in sapkalar)
        {
            var slott = Instantiate(slot, transform);
            slott.GetComponent<SapkaSlot>().sapka = sapka;
        }
    }

    public void SelectSapka(Sapka sapka)
    {
        selectedSapka = sapka;
        PurchasedManager.instance.SatinAl(sapka);
    }

}
