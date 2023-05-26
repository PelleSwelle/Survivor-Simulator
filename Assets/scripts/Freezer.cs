using UnityEngine;

public class Freezer : MonoBehaviour
{
    public float bodyTemp;
    float depletionRate;
    public float freezingTemp = 36, maxTemp = 38;
    bool isNearHeatSource;
    
    void Start()
    {
        bodyTemp = 37.5f;
        depletionRate = .2f;    
    }

    void Update()
    {
        isNearHeatSource = Vector3.Distance(transform.position, Fire.instance.transform.position) <= 3;

        if (isNearHeatSource)
            increaseBodyTemp();
        else
            decreaseBodyTemp();
    }

    void decreaseBodyTemp() => bodyTemp -= Time.deltaTime * depletionRate;
    void increaseBodyTemp() => bodyTemp += Time.deltaTime * depletionRate;
}
