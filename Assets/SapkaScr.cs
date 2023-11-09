using UnityEngine;

public class SapkaScr : MonoBehaviour
{
    public GameObject playerSapkaObjesi;

    private void Start()
    {
        for (int i = 0; i < playerSapkaObjesi.transform.childCount; i++)
        {
            Destroy(playerSapkaObjesi.transform.GetChild(i));
        }
        if(PurchasedManager.instance.currentSapka != null)
            Instantiate(PurchasedManager.instance.currentSapka.Prefab, playerSapkaObjesi.transform);
    }
}
