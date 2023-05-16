using UnityEngine;

public class Sun : MonoBehaviour
{
    public static Sun instance { get; private set; }
    [SerializeField] Transform origin;
    
    Light sunLight;
    float dayDuration = 24.0f;
    [SerializeField] Vector3 rotationAxis;
    [SerializeField] float rotationAngle;
    [SerializeField] float speed;
    public float temperature;
    float maxTemp = 5, minTemp = -40;
    public float timeOfDay;
    
    bool isUp;

    void Awake()
    {
        instance = this;
        sunLight = GetComponentInChildren<Light>();
    }
    void Update()
    {
        rotate();
        updateTemperature();
        timeOfDay += Util.mapRange(-567, 567, 0, 24, transform.position.y);
    }

    public void updateTemperature()
    {
        float maxY = 567;
        float minY = -567;

        temperature = Util.mapRange(minY, maxY, minTemp, maxTemp, transform.position.y);
    }

    // midday = y = 567
    // midnight = = -567

    void rotate()
    {
        transform.RotateAround(origin.position, rotationAxis, speed * Time.deltaTime);
        sunLight.transform.LookAt(origin);
    }
}
