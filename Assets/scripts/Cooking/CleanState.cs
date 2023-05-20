using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanState : BoilerBaseState
{
    float timeToFreeze = 2;
    float elapsedTime;

    public override void EnterState(BoilerStateManager boiler)
    {
        elapsedTime = 0;
        setMaterial(boiler, boiler.cleanMaterial);
        boiler.statusText.SetText("clean");
    }

    public override void OnCollisionEnter(BoilerStateManager boiler)
    {
        boiler.takeWater();
        boiler.switchState(boiler.empty);
    }

    public override void UpdateState(BoilerStateManager boiler)
    {
        bool putLogsInFire = Fire.instance.numberOfLogs > 0;
        if (putLogsInFire)
            boiler.switchState(boiler.boiling);
        
        if (elapsedTime < timeToFreeze)
            elapsedTime += Time.deltaTime;
        else
            boiler.switchState(boiler.frozen);
    }
}
