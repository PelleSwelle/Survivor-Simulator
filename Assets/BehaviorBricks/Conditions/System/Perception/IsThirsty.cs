using Pada1.BBCore;
using UnityEngine;
namespace BBUnity.Conditions
{
    [Condition("general/IsThirsty")]
    public class IsThirsty : GOCondition
    {
        Thirst thirst;
        public override bool Check()
        {
            thirst = Survivor.instance.GetComponent<Thirst>();
            return thirst.isThirsty;
        }
    }
}
