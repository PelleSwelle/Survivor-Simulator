using Pada1.BBCore;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsFireGoingOut")] [Help("Checks whether the fire built is about to go out")]
    public class IsFireGoingOut : GOCondition
    {
        public override bool Check() => Fire.instance.health < 30;
    }
}
