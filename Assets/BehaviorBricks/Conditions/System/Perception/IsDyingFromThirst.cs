using Pada1.BBCore;
using UnityEngine;
namespace BBUnity.Conditions
{
    [Condition("general/IsDyingFromThirst")]
    public class IsDyingFromThirst : GOCondition
    {
        Thirst thirst;
        public override bool Check()
        {
            thirst = Survivor.instance.GetComponent<Thirst>();
            if (thirst.waterLevel <= 0)
            {
                Logger.instance.updateTaskText("need to get water now!");
                return true;
            }
            else return false;
        }
    }
}