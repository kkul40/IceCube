using UnityEngine;

public class SapkaScr : MonoBehaviour
{
    public GameObject playerSapkaObjesi;

    private void Start()
    {
        for (int i = 0; i < playerSapkaObjesi.transform.childCount; i++)
        {
            Destroy(playerSapkaObjesi.transform.GetChild(i).gameObject);
        }
        if(PurchasedManager.instance.currentSapka != null)
            Instantiate(PurchasedManager.instance.currentSapka.Prefab, playerSapkaObjesi.transform);
    }

    public void FlipSapka(bool flip)
    {
        if (playerSapkaObjesi.transform.childCount < 1) return;

        playerSapkaObjesi.transform.GetComponentInChildren<SpriteRenderer>().flipX = flip;
    }
}
