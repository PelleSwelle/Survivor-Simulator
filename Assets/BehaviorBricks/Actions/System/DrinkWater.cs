using Pada1.BBCore;
using BBUnity.Actions;
using UnityEngine;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("survival/DrinkWater")]
    public class DrinkWater : GOAction
    {
        Thirst thirst;
        public override void OnStart() => thirst = GameObject.FindObjectOfType<Thirst>();

        public override TaskStatus OnUpdate()
        {
            if (thirst.waterLevel < thirst.maxWaterLevel)
            {
                Debug.Log("drank some water");
                GameObject.FindObjectOfType<Inventory>().unitsOfWater --;
                thirst.waterLevel += 20;
                return TaskStatus.COMPLETED;
            }
            Debug.Log("no more water");
            return TaskStatus.FAILED;
        }
    }
}
