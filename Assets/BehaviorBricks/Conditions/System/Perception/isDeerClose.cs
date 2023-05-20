using Pada1.BBCore;
using UnityEngine;
using System.Collections.Generic;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsDeerClose")]
    public class IsDeerClose : GOCondition
    {
        [OutParam("closeDeer")] Transform deer;
        public Transform deerParent;

        public override bool Check() 
        {
            deerParent = GameObject.Find("deerParent").transform;
            if (deerParent != null)
            {
                foreach (Transform _deer in deerParent)
                {
                    if ((gameObject.transform.position - _deer.position).sqrMagnitude < Rifle.instance.range * Rifle.instance.range)
                    {
                        deer = _deer;
                        Logger.instance.displayDeerInRange(true);
                        return true;
                    }
                }
            }
            Logger.instance.displayDeerInRange(false);
            return false;
        }
    }
}