using UnityEngine;

public class Controls : MonoBehaviour
{
    void Update()
    {
        enableWeatherControls();
        enableCameraControls();
        enableRifleControls();
        enableClickControls();

        if (Input.GetKeyUp(KeyCode.N))
            WoodPile.instance.take();
        if (Input.GetKeyUp(KeyCode.M))
            WoodPile.instance.add();
    }

    void enableClickControls()
    {
        if (Input.GetMouseButtonUp(1))
            RadialMenu.instance.open();
    }

    private static void enableCameraControls()
    {
        // if (Input.GetKeyUp(KeyCode.C))
        //     CameraController.instance.cycleActiveTargets();
        // if (Input.GetKey(KeyCode.H))
        //     CameraController.instance.highLightDeer();

    }

    private void enableRifleControls()
    {
        if (Input.GetKeyUp(KeyCode.R))
            Rifle.instance.toggleRangeIsVisible();
    }

    void enableWeatherControls()
    {
        if (Input.GetKeyUp(KeyCode.R))
            WeatherSystem.instance.storm();
        if (Input.GetKeyUp(KeyCode.T))
            WeatherSystem.instance.activateBlizzard();
        if (Input.GetKeyUp(KeyCode.Y))
            WeatherSystem.instance.activateSnow();
        if (Input.GetKeyUp(KeyCode.U))
            WeatherSystem.instance.noFx();
    }
}
