using UnityEngine;
using System.Collections;

public class Freezer : MonoBehaviour
{
    public float bodyTemp, idealTemp = 37;
    public float currentDepletionRate, minDepletionRate = .1f, maxDepletionRate = .5f;
    float increaseRate = .2f;
    public float freezingTemp = 36, maxTemp = 38;
    bool isNearHeatSource;
    void Start()
    {
        bodyTemp = idealTemp;
    }

    void Update()
    {
        currentDepletionRate = calculateDepletionRate();
        isNearHeatSource = Vector3.Distance(transform.position, Fire.instance.transform.position) <= 3;

        if (isNearHeatSource)
            increaseBodyTemp();
        else
        {
            KeepWarmTimer timer = new KeepWarmTimer(10);
            timer.count();
            if (timer.isFinished)
            {
                Debug.Log("you're starting to get cold");
                decreaseBodyTemp();
            }
        }
    }

    float currCountdownValue;
    
    void decreaseBodyTemp() => bodyTemp -= Time.deltaTime * currentDepletionRate;
    void increaseBodyTemp() => bodyTemp += Time.deltaTime * increaseRate;

    float calculateDepletionRate()
    {
        WeatherSystem weather = WeatherSystem.instance;
        float worldTemperature = weather.temperature;
        float minTemp = weather.minTemp;
        float maxTemp = weather.maxTemp;
        return Util.mapRange(minTemp, maxTemp, minDepletionRate, maxDepletionRate, worldTemperature);
    }
}
