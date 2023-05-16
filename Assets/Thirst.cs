using UnityEngine;

public class Thirst : MonoBehaviour
{
    public float waterLevel, maxWaterLevel;
    float depletionRate = 2;
    void Start() 
    {
        maxWaterLevel = 100;
        waterLevel = maxWaterLevel;
    }
    
    public void drink() 
    {
        if (waterLevel < maxWaterLevel)
            waterLevel ++;
        else
            Debug.Log("Cannot drink any more");
    }

    void Update() => waterLevel -= Time.deltaTime * depletionRate;
}
