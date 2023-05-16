using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsWoodInPile")]
    public class IsWoodInPile : GOCondition
    {
        public override bool Check()
        {
            WoodPile woodPile = GameObject.Find("woodPile").GetComponent<WoodPile>();
            return woodPile.numberOfLogs > 0;
        }
    }
}
