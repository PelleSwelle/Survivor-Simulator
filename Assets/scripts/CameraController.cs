using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [SerializeField] float 
    distanceToTarget, 
    scrollStrength, turnSpeed, flySpeed,
    sensitivityX = 15f, sensitivityY = 15f,
    minimumX = -360f, maximumX = 360f,
    minimumY = -60f, maximumY = 60f,
    rotationY = 0f;
    
    RotationAxes axes = RotationAxes.MouseXAndY;

    CameraState state;

    void Awake() 
    {
        state = CameraState.ABOVE;
        instance = this;
    }

    void Start()
    {
        distanceToTarget = 10;
        scrollStrength = .5f;
    }

    void Update()
    {
        if (state == CameraState.ABOVE)
        {
            enableLockedTranslation();
        }
        if (state == CameraState.FREEFLY)
            enableFreeFlyControls();

        else if (state == CameraState.SURVIVOR)
            enableLockedControls();
    }

    void enableLockedTranslation()
    {
        enableTranslationOnPlane();
        enableplaneZoom();
    }

    void enableplaneZoom()
    {
        Transform plane = transform.parent;
        if (Input.mouseScrollDelta.y < 0)
            plane.transform.position +=  new Vector3(0, scrollStrength, 0);
        else if (Input.mouseScrollDelta.y > 0)
            plane.transform.position -=  new Vector3(0, scrollStrength, 0);
    }

    public void enableLockedMouseLook()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
 
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
 
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
 
            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    void enableLockedControls()
    {
        focusOn(Survivor.instance.transform);
        enableZoom();
        enableOrbit();
    }

    void enableFreeFlyControls()
    {
        if (!RadialMenu.instance.isActiveAndEnabled)
        {
            enableTranslationControls();
            enableMouseLook();
        }
    }

    void enableTranslationOnPlane()
    {
        Transform plane = transform.parent;

        if (Input.GetKey(KeyCode.W))            
            moveLocked(Vector3.forward);
        if (Input.GetKey(KeyCode.S))            
            moveLocked(Vector3.back);
        if (Input.GetKey(KeyCode.A))            
            moveLocked(Vector3.left);
        if (Input.GetKey(KeyCode.D))            
            moveLocked(Vector3.right);
        if (Input.GetKey(KeyCode.LeftControl))  
            moveLocked(Vector3.down);
        if (Input.GetKey(KeyCode.Space))        
            moveLocked(Vector3.up);
    }
    
    void enableTranslationControls()
    {
        if (Input.GetKey(KeyCode.W))            
            move(Vector3.forward);
        if (Input.GetKey(KeyCode.S))            
            move(Vector3.back);
        if (Input.GetKey(KeyCode.A))            
            move(Vector3.left);
        if (Input.GetKey(KeyCode.D))            
            move(Vector3.right);
        if (Input.GetKey(KeyCode.LeftControl))  
            move(Vector3.down);
        if (Input.GetKey(KeyCode.Space))        
            move(Vector3.up);
    }

    void move(Vector3 direction)
        => transform.position += Camera.main.transform.TransformDirection(direction * flySpeed);
    void moveLocked(Vector3 direction)
    {
        Vector3 lockedDirection = new Vector3(direction.x, 0, direction.z); 
        transform.position += Camera.main.transform.TransformDirection( direction * flySpeed);
    }
    void focusOn(Transform entity)
    {
        transform.LookAt(entity, Vector3.up);
    }

    void enableZoom()
    {
        if (Input.mouseScrollDelta.y < 0)
            distanceToTarget += scrollStrength;
        else if (Input.mouseScrollDelta.y > 0)
            distanceToTarget -= scrollStrength;
    }

    void enableOrbit()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 survivor = Survivor.instance.transform.position;
            float delta = Input.GetAxis("Mouse X") * turnSpeed;

            transform.RotateAround(survivor, Vector3.up, delta);
        }
    }

    List<Transform> getCameraTargetable()
    {
        List<Transform> targets = new List<Transform>();
        // add survivor
        targets.Add(Survivor.instance.transform);
        
        // add lakes with fish
        foreach (Transform lake in GameObject.Find("lakes").transform)
            targets.Add(lake);

        // add deer
        foreach (Transform deer in GameObject.Find("deer").transform)
            targets.Add(deer);

        // add wolves
        foreach (Transform wolf in GameObject.Find("wolves").transform)
            targets.Add(wolf);
        return targets;
    }
 
    public void enableMouseLook ()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
 
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
 
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
 
            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    public void disableMouseLook()
    {
        transform.localEulerAngles = transform.localEulerAngles;
    }
}

enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
enum CameraState
{
    FREEFLY, SURVIVOR, ABOVE
}
