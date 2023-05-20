using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenState : BoilerBaseState
{
    public override void EnterState(BoilerStateManager boiler)
    {
        setMaterial(boiler, boiler.frozenMaterial);
        boiler.statusText.SetText("frozen");
    }

    public override void OnCollisionEnter(BoilerStateManager boiler)
    {
        Debug.Log("the water is frozen. You need to heat it up first");
    }

    public override void UpdateState(BoilerStateManager boiler)
    {
        bool putLogsInFire = Fire.instance.numberOfLogs > 0;
        if (putLogsInFire)
            boiler.switchState(boiler.dirty);
    }
}
