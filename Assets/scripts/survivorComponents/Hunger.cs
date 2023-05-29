using UnityEngine;
using System.Collections.Generic;

public class Hunger : MonoBehaviour
{
    public float satiation;
    public float depletionRate;
    public float maxSatiation;
    public float hungryThreshold = 40;
    public bool isHungry;

    void Start()
    {
        depletionRate = .2f;
        maxSatiation = 100;
        satiation = 50;
    }

    void Update() 
    {
        isHungry = satiation < hungryThreshold;
        satiation -= depletionRate * Time.deltaTime;
        if (satiation <= 0)
            GetComponent<Health>().value -= depletionRate * Time.deltaTime;
    }
}
