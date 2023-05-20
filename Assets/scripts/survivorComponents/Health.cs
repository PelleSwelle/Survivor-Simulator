using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int value;
    public int maxValue = 100;

    void Start() => value = maxValue;

    public void decrease(int amount) => value -= amount;

    public void increase(int amount) 
    {
        if (value < maxValue)
            value += amount;
    }
}
