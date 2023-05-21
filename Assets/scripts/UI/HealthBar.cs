using UnityEngine;

public class HealthBar : Bar
{
    Health health;
    void Start() => health = Survivor.instance.GetComponent<Health>();
    

    void Update() 
    {
        if (health.value > 0)
        {
            Vector3 scale = bar.localScale;
            scale.x = Util.mapRange(0, health.maxValue, 0, 1, health.value);
            bar.localScale = scale;
        }
    }
}
