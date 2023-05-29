using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;

namespace BBUnity.Conditions
{
    [Condition("IsWaterInBoiler")]
    public class IsWaterInBoiler : GOCondition
    {
        public override bool Check()
        {
            BoilerStateManager boiler = GameObject.FindObjectOfType<BoilerStateManager>();
            bool isBoiling = boiler.currentState.GetType() == typeof(BoilingState); 
            bool isClean = boiler.currentState.GetType() == typeof(CleanState); 

            if (isBoiling || isClean)
            {
                Debug.Log("water is available");
                return true;
            }

            Debug.Log("no water available");
            return false;
        }
    }
}
