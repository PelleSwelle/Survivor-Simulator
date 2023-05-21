using Pada1.BBCore;
using UnityEngine;
namespace BBUnity.Conditions
{
    [Condition("general/IsHungry")]
    public class IsHungry : GOCondition
    {
        Hunger hunger;
        public override bool Check()
        {
            hunger = Survivor.instance.GetComponent<Hunger>();
            return hunger.isHungry;
        }
    }
}
