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

    public override void OnCollisionEnter(BoilerStateManager boiler, Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boiler.takeWater();
            boiler.switchState(boiler.empty);
        }
    }

    public override void UpdateState(BoilerStateManager boiler)
    {
        if (!Fire.instance.isAlive)
            boiler.switchState(boiler.clean);
    }
}
