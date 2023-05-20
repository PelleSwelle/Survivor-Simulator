using UnityEngine;

public class Range : MonoBehaviour
{
    [SerializeField] GameObject parent;
    
    // void OnTriggerEnter(Collider collider)
    // {
    //     if (collider.gameObject.tag == "deer")
    //     {
    //         rifle.deerInRange.Add(collider.gameObject.GetComponent<Deer>());
    //     }

    // }

    // void OnTriggerExit(Collider collider)
    // {
    //     if (collider.gameObject.tag == "deer")
    //     {
    //         rifle.deerInRange.Remove(collider.gameObject.GetComponent<Deer>());
    //     }
    // }
}
