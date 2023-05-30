using Pada1.BBCore;
using UnityEngine;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("TakeWoodFromPile")]
    public class TakeWoodFromPile : GOAction
    {
        public override TaskStatus OnUpdate()
        {
            if (WoodPile.instance.numberOfLogs > 0)
            {
                WoodPile.instance.take();
                Inventory.instance.logsOfWood++;
                return TaskStatus.COMPLETED;
            }
            return TaskStatus.FAILED;
        }
    }
}