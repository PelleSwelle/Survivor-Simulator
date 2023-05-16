using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour
{
    public bool debug = true;
    public float detectionRate = 0.0f;
    protected float elapsedTime = 0.0f;

    protected virtual void Initialize() {}

    protected virtual void updateSense() {}

    void Start()
    {
        elapsedTime = 0.0f;
        Initialize();
    }

    void Update() => updateSense();
}
