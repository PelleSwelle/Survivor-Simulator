using UnityEngine;
using System.Collections.Generic;

public class Fire : Fillable
{
    public static Fire instance {get; private set; }
    public float health;
    float maxHealth = 100;

    bool isAlive;
    
    [SerializeField] Light fireLight;
    [SerializeField] float maxLight;

    void Awake() => instance = this;
    
    void Start() 
    {
        add(); add();
    }

    void Update() 
    {
        isAlive = numberOfLogs > 0;
        if (isAlive)
        {
            burn();
            if (health <= 0)
                isAlive = false;
        }
        else
            fireLight.intensity = 0;
    }

    void burn()
    {
        logPrefabs[numberOfLogs -1].burn();

        if (logPrefabs[numberOfLogs -1].health <= 0)
            numberOfLogs--;
        updateHealth();
        fireLight.intensity = Util.mapRange(0, maxHealth, 0, maxLight, health);
    }

    void updateHealth()
    {
        float tempHealth = 0;
        foreach (Log log in logPrefabs)
        {
            if (log.state == LogState.BURNING)
                tempHealth += log.health;
        }
        health = tempHealth;
    }
}
