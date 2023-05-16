using UnityEngine;
using Pada1.BBCore;

namespace BBUnity.Conditions
{
    [Condition("IsSurvivorClose")]
    public class IsSurvivorClose : GOCondition
    {
        [InParam("Wolf")] Wolf wolf;
        public override bool Check() => Vector3.Distance(wolf.transform.position, Survivor.instance.transform.position) < wolf.sightRange;
    }

}
