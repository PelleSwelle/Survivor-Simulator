using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsTargetClose")]
    [Help("Checks whether a target is close depending on a given distance")]
    public class IsTargetClose : GOCondition
    {
        [InParam("target")] public GameObject target;

        [InParam("closeDistance")] public float closeDistance;

        public override bool Check() => (gameObject.transform.position - target.transform.position).sqrMagnitude < closeDistance * closeDistance;
    }
}