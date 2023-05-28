using UnityEngine;

public class KeepWarmTimer
{
    public float keepTime;
    public float currentTime;

    public bool isCounting;

    public KeepWarmTimer(float _keepTime)
    {
        keepTime = _keepTime;
        currentTime = _keepTime;
        isCounting = false;
    }

    public void count()
    {
        isCounting = true;

        if (currentTime > 0)
            currentTime -= Time.time;
        else
        {
            currentTime = 0;
            isCounting = true;
        }
    }

    public bool isFinished() => currentTime <= 0;
}
