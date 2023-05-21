using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerBar : Bar
{
    Hunger hunger;
    void Start() => hunger = FindObjectOfType<Hunger>();

    void Update() 
    {
        if (hunger.satiation > 0)
        {
            var scale = bar.localScale;
            scale.x = Util.mapRange(0, hunger.maxSatiation, 0, 1, hunger.satiation);
            bar.localScale = scale;
        }
    }
}
