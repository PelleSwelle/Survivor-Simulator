using UnityEngine;

public class EmitterPositionController : MonoBehaviour
{
    public Transform cameraTransform;

	void Start ()
        => cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    
	
	void Update ()
    {
        if(cameraTransform != null)
            transform.position = cameraTransform.position;
    }
}
