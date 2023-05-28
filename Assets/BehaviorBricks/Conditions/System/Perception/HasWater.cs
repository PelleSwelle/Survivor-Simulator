using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("HasWater")]
    public class HasWater : GOCondition
    {
        public override bool Check()
        {
            return Inventory.instance.unitsOfWater > 0;
        }
    }

}
