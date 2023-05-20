using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, Eatable
{
    public Transform lake;
    Transform waypointsParent;
    [SerializeField] float swimSpeed = .001f;
    [SerializeField] Transform currentWaypoint;

    public float nutritionalValue 
    { 
        get => 15; 
        set => nutritionalValue = value; 
    }

    void Start()
    {
        waypointsParent = lake.GetChild(1);
        currentWaypoint = lake.GetChild(1).GetChild(0);
    }
    void Update()
    {
        // if (Vector3.Distance(transform.position, currentWaypoint.position) > 1)
        // transform.Translate(currentWaypoint.position * swimSpeed, Space.World);
        // else
        //     currentWaypoint = getRandomWaypoint();
    }

    Transform getRandomWaypoint()
    {
        int seed = Random.Range(0, waypointsParent.childCount);
        return waypointsParent.GetChild(seed);
    }
}
