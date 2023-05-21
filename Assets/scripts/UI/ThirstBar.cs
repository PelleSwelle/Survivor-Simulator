using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstBar : Bar
{
    Thirst thirst;
    void Start() => thirst = FindObjectOfType<Thirst>();

    void Update() 
    {
        if (thirst.waterLevel > 0)
        {
            var scale = bar.localScale;
            scale.x = Util.mapRange(0, thirst.maxWaterLevel, 0, 1, thirst.waterLevel);
            bar.localScale = scale;
        }
    }
}
