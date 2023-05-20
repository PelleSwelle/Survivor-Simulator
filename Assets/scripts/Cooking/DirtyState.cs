using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyState : BoilerBaseState
{
    float timeToBoil = 10;
    float timeToFreeze = 10;
    float elapsedTime = 0;
    public override void EnterState(BoilerStateManager boiler) => setMaterial(boiler, boiler.dirtyMaterial);

    public override void OnCollisionEnter(BoilerStateManager boiler)
    {
        Debug.Log("the water is dirty. You can't drink this");
    }

    public override void UpdateState(BoilerStateManager boiler)
    {
        if (Fire.instance.isAlive)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime < timeToBoil)
                boiler.statusText.SetText(elapsedTime.ToString("F2"));
            else 
                boiler.switchState(boiler.boiling);
        }
        else if (!Fire.instance.isAlive)
        {
            if (elapsedTime < timeToFreeze)
                elapsedTime += Time.deltaTime;
            else 
                boiler.switchState(boiler.frozen);
        }
    }
}
