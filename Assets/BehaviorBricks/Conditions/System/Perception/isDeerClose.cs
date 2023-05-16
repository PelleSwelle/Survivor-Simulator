using Pada1.BBCore;
using UnityEngine;
using System.Collections.Generic;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsDeerClose")]
    [Help("Checks whether a target is close depending on a given distance")]
    public class IsDeerClose : GOCondition
    {
        [InParam("target")] [Help("Target to check the distance")]
        [OutParam("closeDeer")] GameObject deer;
        public Transform deerParent;

        public override bool Check() 
        {
            if (deerParent != null)
            {
                foreach (Transform _deer in deerParent)
                {
                    Debug.Log(_deer.name);
                    if ((gameObject.transform.position - _deer.position).sqrMagnitude < Rifle.instance.range * Rifle.instance.range)
                    {
                        deer = _deer.gameObject;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}