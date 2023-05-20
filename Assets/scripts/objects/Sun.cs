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
    float minY = -567, maxY = 567;
    public float tempWeight = .8f; // how much the temperature influences the world temp
    
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
        timeOfDay = getTimeOfDayFromRotation();
    }

    float getTimeOfDayFromRotation()
    {
        return Util.mapRange(minY, maxY, 0, 24, transform.position.y);
    }

    public void updateTemperature()
    {
        temperature = Util.mapRange(minY, maxY, minTemp, maxTemp, transform.position.y);
    }

    void rotate()
    {
        transform.RotateAround(origin.position, rotationAxis, speed * Time.deltaTime);
        sunLight.transform.LookAt(origin);
    }
}
