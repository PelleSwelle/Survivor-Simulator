using Pada1.BBCore;

namespace BBUnity.Conditions
{
    [Condition("general/IsHungry")]
    public class IsHungry : GOCondition
    {
        Hunger hunger;
        public override bool Check() => hunger.isHungry;
    }
}
