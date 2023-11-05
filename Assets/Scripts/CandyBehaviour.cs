using UnityEngine;

public class CandyBehaviour : MonoBehaviour, IInteractable
{
    public int howManyCandy;
    
    public void Collect()
    {
        SaveHelper.SaveCandy(howManyCandy);
        Destroy(this.gameObject);
    }
}
