using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SapkaSlot : MonoBehaviour
{
    public Sapka sapka;

    public Image sprite;
    public TextMeshProUGUI price;
    public TextMeshProUGUI name;

    public sapkaElements sapkaElements;

    private void Start()
    {
        sprite.sprite = sapka.icon;
        if(sapka.isSold) price.text = "Purchased";
        else price.text = sapka.price.ToString();
        name.text = sapka.name;
        sapkaElements = FindObjectOfType<sapkaElements>();
    }

    public void OnClick()
    {
        sapkaElements.SelectSapka(sapka);
        if(sapka.isSold) price.text = "Purchased";
        else price.text = sapka.price.ToString();
    }

}
