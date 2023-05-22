using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointOfInterest : MonoBehaviour
{
    public bool hasBeenVisited;

    void Start() => hasBeenVisited = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "survivor")
            hasBeenVisited = true;
    }
}
