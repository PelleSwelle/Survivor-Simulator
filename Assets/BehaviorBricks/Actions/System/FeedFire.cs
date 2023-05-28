using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

namespace BBUnity.Actions
{
    [Action("survival/FeedFire")]
    public class FeedFire : GOAction
    {
        private WoodPile woodPile;

        public override TaskStatus OnUpdate()
        {
            if (Fire.instance.numberOfLogs >= Fire.instance.maxNumberOfLogs)
                return TaskStatus.FAILED;
            else 
            {
                Inventory.instance.logsOfWood -= 5;
                Fire.instance.add(5);
                return TaskStatus.COMPLETED;
            }
        }
    }

}
