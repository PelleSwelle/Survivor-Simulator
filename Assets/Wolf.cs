using UnityEngine;
using System.Collections;

public class Wolf : MonoBehaviour
{
    int health;
    public float sightRange;
    
    void Start()
    {
        health = 2;
        sightRange = 30;

    }
}
