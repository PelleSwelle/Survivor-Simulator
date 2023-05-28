using UnityEngine;
using System.Collections;

public class Freezer : MonoBehaviour
{
    public float bodyTemp, idealTemp = 37;
    public float currentDepletionRate, minDepletionRate = .1f, maxDepletionRate = .5f;
    float increaseRate = .2f;
    public float freezingTemp = 36, maxTemp = 38;
    public KeepWarmTimer timer;
    public float heatRetentionTime;
    public float timeUntilFreeze;
    void Start()
    {
        bodyTemp = idealTemp;
        timer = new KeepWarmTimer(heatRetentionTime);
        timeUntilFreeze = timer.currentTime;
    }

    void Update()
    {
        currentDepletionRate = calculateDepletionRate();

        if (isNearHeatSource())
            increaseBodyTemp();
        else
        {
            timer.count();
            timeUntilFreeze = timer.currentTime;

            if (timer.isFinished())
                decreaseBodyTemp();
        }
    }

    public bool isNearHeatSource() => Vector3.Distance(transform.position, Fire.instance.transform.position) <= 3;
    
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
