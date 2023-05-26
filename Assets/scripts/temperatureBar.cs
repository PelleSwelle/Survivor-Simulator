using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temperatureBar : Bar
{
    Freezer freezer;
    void Start() => freezer = Survivor.instance.GetComponent<Freezer>();

    void Update() 
    {
        var scale = bar.localScale;
        scale.x = Util.mapRange(0, freezer.maxTemp, 0, 1, freezer.bodyTemp);
        bar.localScale = scale;
    }
}
