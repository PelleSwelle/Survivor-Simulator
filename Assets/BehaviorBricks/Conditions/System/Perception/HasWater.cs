using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("HasWater")]
    public class HasWater : GOCondition
    {
        public override bool Check()
        {
            Inventory inventory = GameObject.FindObjectOfType<Inventory>();
            return inventory.unitsOfWater > 0;
        }
    }

}
