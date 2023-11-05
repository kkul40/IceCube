using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sapkaElements : MonoBehaviour
{
    public List<Sapka> sapkalar;
    
    
    // Start is called before the first frame update
    void Start()
    {
        var temp = Resources.FindObjectsOfTypeAll<Sapka>();
        foreach (var item in temp)
        {
            sapkalar.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
