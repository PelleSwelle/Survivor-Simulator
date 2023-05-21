using UnityEngine;
using System.Collections;

public class Wolf : MonoBehaviour
{
    int health;
    public float sightRange = 20;
    [SerializeField] GameObject rangeRing;

    void OnValidate() => rangeRing.transform.localScale = new Vector3(sightRange, sightRange, sightRange);
    void Start()
    {
        health = 2;
    }
}
