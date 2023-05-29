using Pada1.BBCore;
using UnityEngine;
namespace BBUnity.Conditions
{
    [Condition("general/IsDyingFromHunger")]
    public class IsDyingFromHunger : GOCondition
    {
        Hunger hunger;
        public override bool Check()
        {
            hunger = Survivor.instance.GetComponent<Hunger>();
            if (hunger.satiation <= 0)
            {
                Logger.instance.updateTaskText("need food now");
                return true;
            }
            else return false;
        }
    }
}