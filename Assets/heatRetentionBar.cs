using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatRetentionBar : Bar
{
    KeepWarmTimer timer;
    Freezer freezer;
    void Start()
    {
        timer = Survivor.instance.GetComponent<Freezer>().timer;
        freezer = Survivor.instance.GetComponent<Freezer>();
    }

    void Update() 
    {
        if (timer.isCounting)
        {
            var scale = bar.localScale;
            scale.x = Util.mapRange(0, timer.keepTime, 0, 1, freezer.timeUntilFreeze);
            bar.localScale = scale;
        }
        else
        {
            var scale = bar.localScale;
            scale.x = 1;
            bar.localScale = scale;
        }
    }
}
