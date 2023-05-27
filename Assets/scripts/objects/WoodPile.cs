using UnityEngine;

public class WoodPile : Fillable
{
    public static WoodPile instance { get; private set;}
    
    void Awake() => instance = this;

    
    void Start() 
    {
        maxNumberOfLogs = 10;
        numberOfLogs = 0;
        
        foreach ( Transform log in transform)
        {
            log.GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
