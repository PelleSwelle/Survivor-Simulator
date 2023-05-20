using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Logger : MonoBehaviour
{
    public static Logger instance { get; private set; }
    WoodPile woodPile;
    [SerializeField] GameObject trees;
    [SerializeField] Fire fire;

    [SerializeField] TMP_Text 
    // base
    logsInFire, 
    fireHealthValue, 
    
    // survivor
    currentTask,
    bodyTempValue, 
    energyValue, 
    
    // world
    worldTempValue, 
    timeOfDayValue, 
    
    // animals
    isVisibleToWolfValue, 
    isDeerClose, 

    // inventory
    woodHeld, waterHeld,
    meatHeld, rationsHeld, fishHeld;

    void Awake() => instance = this;
    void Update()
    {   
        displayWaterHeld();
        displayFireHealth();
        displayTimeOfDay();
        displayWorldTemp();
        displayBodyTemp();
        displayLogsInFire();
        displayWoodHeld();
        displayFood();
    }

    void displayWaterHeld() => waterHeld.SetText(FindObjectOfType<Inventory>().unitsOfWater.ToString());

    public void updateTaskText(string text) => currentTask.SetText(text); 

    void displayFood()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        rationsHeld.SetText(FindObjectOfType<Inventory>().rations.Count.ToString());
        meatHeld.SetText(FindObjectOfType<Inventory>().meat.Count.ToString());
        fishHeld.SetText(FindObjectOfType<Inventory>().fish.Count.ToString());
    }

    void displayWoodHeld() => woodHeld.SetText(Survivor.instance.heldWood.ToString());
    void displayLogsInFire() => logsInFire.SetText(Fire.instance.numberOfLogs.ToString());
    void displayFireHealth() => fireHealthValue.SetText(Fire.instance.health.ToString("F2"));
    void displayTimeOfDay() => timeOfDayValue.SetText(Sun.instance.timeOfDay.ToString("F2"));
    void displayWorldTemp() => worldTempValue.SetText(WeatherSystem.instance.temperature.ToString("F2"));
    void displayBodyTemp() => bodyTempValue.SetText(GameObject.FindObjectOfType<Freezer>().bodyTemp.ToString("F2"));
    public void displayDeerInRange(bool value) => isDeerClose.SetText(value.ToString());
}
