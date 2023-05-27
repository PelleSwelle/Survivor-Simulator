using UnityEngine;

public class KeepWarmTimer
{
    float keepTime;
    float currentTime;
    public bool isFinished;

    public KeepWarmTimer(float _keepTime)
    {
        keepTime = _keepTime;
        currentTime = _keepTime;
        isFinished = false;
    }

    public void count()
    {
        if (currentTime <= 0)
            stop();
        else
        {
            currentTime -= Time.time;
            Debug.Log("time until start getting cold: " + currentTime);
        }
    }

    void stop()
    {
        Debug.Log("timer is done");
        currentTime = 0;
        isFinished = true;
    }
}
