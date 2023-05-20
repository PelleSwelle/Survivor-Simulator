using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    protected float value;
    protected float minValue = 0, maxValue = 100;
    protected float minWidth = 0, maxWidth = 185;
    protected float barHeight = 25;
    protected RectTransform bar;
    
    void Awake() => bar = transform.GetChild(0).GetComponent<RectTransform>();
}
