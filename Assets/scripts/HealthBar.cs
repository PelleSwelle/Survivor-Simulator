using UnityEngine;

public class HealthBar : Bar
{
    Health health;
    void Start() => health = FindObjectOfType<Health>();

    void Update() 
    {
        var scale = bar.localScale;
        scale.x = Util.mapRange(0, health.maxValue, 0, 1, health.value);
        bar.localScale = scale;
    }
}
