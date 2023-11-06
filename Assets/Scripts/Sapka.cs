using UnityEngine;

[CreateAssetMenu(fileName = "Sapka", menuName = "new Sapka", order = 0)]
public class Sapka : ScriptableObject
{
    public string names;
    public int price;
    public Sprite icon;
    public bool isSold;

    public GameObject Prefab;

}
