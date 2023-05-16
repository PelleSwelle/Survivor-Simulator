using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;

namespace BBUnity.Conditions
{
    [Condition("Survivor/IsCold")]
    public class IsCold : GOCondition
    {
        public override bool Check()
        {
            Freezer freezer = GameObject.FindObjectOfType<Freezer>();
            return freezer.bodyTemp < freezer.freezingTemp;
        }
            
    }
}
