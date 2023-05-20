using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : BoilerBaseState
{
    public override void EnterState(BoilerStateManager boiler)
    {
        setMaterial(boiler, boiler.emptyMaterial);
        boiler.statusText.SetText("empty");
    }

    public override void OnCollisionEnter(BoilerStateManager boiler)
    {
        boiler.switchState(boiler.dirty); // until now we prented that survivor just picks up some snow and throws it in.
    }

    public override void UpdateState(BoilerStateManager boiler)
    {
        throw new System.NotImplementedException();
    }
}
