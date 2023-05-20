using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilingState : BoilerBaseState
{
    public override void EnterState(BoilerStateManager boiler)
    {
        setMaterial(boiler, boiler.boilingMaterial);
        boiler.statusText.SetText("boiling");
    }

    public override void OnCollisionEnter(BoilerStateManager boiler)
    {
        boiler.takeWater();
        boiler.switchState(boiler.empty); // TODO: actually put it in inventory
    }

    public override void UpdateState(BoilerStateManager boiler)
    {
        if (!Fire.instance.isAlive)
            boiler.switchState(boiler.clean);
    }
}
