using UnityEngine;
public class WeatherSystem : MonoBehaviour
{ 
    public static WeatherSystem instance { get; private set; }
    float windForce, snowAmount;
    public float temperature;
    public float minTemp = -1f, maxTemp = -40f; // TODO: put together with sun temp

    [SerializeField] GameObject lightWind, blizzard, heavyStorm, fxAudio;
    
    GameObject currentWeather;

    void Awake() => instance = this;

    void Update() => updateTemperature();
    
    public void storm()
    {
        disableAll();
        heavyStorm.SetActive(true);
        fxAudio.SetActive(true);
        Debug.Log("Storm");
    }

    public void activateBlizzard()
    {
        disableAll();
        blizzard.SetActive(true);
        fxAudio.SetActive(true);
        Debug.Log("Blizzard");
    }

    public void activateSnow()
    {
        disableAll();
        heavyStorm.SetActive(true);
        Debug.Log("Snow");
    }

    public void noFx()
    {
        disableAll();
        Debug.Log("NoFX");
    }

    void disableAll()
    {
        heavyStorm.SetActive(false);
        blizzard.SetActive(false);
        lightWind.SetActive(false);
        fxAudio.SetActive(false);
    }

    void updateTemperature()
    {
        temperature = Sun.instance.temperature;
    }
    public void setTemperature(float newTemperature) => temperature = newTemperature;
}
