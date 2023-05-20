using UnityEngine;

public class Thirst : MonoBehaviour
{
    public float waterLevel, maxWaterLevel, thirstyThreshold;
    float depletionRate = 2;
    public bool isThirsty;
    void Start() 
    {
        maxWaterLevel = 100;
        waterLevel = maxWaterLevel;
        thirstyThreshold = 30;
    }
    
    void Update()
    {
        isThirsty = waterLevel < thirstyThreshold;
        waterLevel -= Time.deltaTime * depletionRate;
    }
}
