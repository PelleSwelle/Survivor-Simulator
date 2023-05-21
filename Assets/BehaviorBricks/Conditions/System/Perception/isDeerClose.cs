using Pada1.BBCore;
using UnityEngine;
using System.Collections.Generic;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsDeerClose")]
    public class IsDeerClose : GOCondition
    {
        public Transform deerParent;

        public override bool Check() 
        {
            deerParent = GameObject.Find("deerParent").transform;
            if (deerParent != null)
            {
                foreach (Transform _deer in deerParent)
                {
                    float distance = Vector3.Distance(gameObject.transform.position, _deer.position);
                    if (distance > 30)
                    {
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