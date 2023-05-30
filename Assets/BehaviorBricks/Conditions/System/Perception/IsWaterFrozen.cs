using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsWaterFrozen")]
    public class IsWaterFrozen : GOCondition
    {
        public override bool Check() 
        {
            BoilerStateManager boiler = GameObject.FindObjectOfType<BoilerStateManager>();
            if (boiler.currentState.GetType() == typeof(FrozenState))
            {
                Debug.Log("the water is frozen");
                return true;
            }
            else return false;
        }
    }
}