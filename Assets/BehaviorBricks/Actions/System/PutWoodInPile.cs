using UnityEngine;
using Pada1.BBCore;
using UnityEngine.AI;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("PutWoodInPile")]
    public class PutWoodInPile : GOAction
    {
        [InParam("Agent")] NavMeshAgent agent;
        WoodPile woodPile;

        public override TaskStatus OnUpdate()
        {
            if (WoodPile.instance.numberOfLogs >= WoodPile.instance.maxNumberOfLogs)
                return TaskStatus.FAILED;
            else 
            {
                Inventory.instance.logsOfWood -= 5;
                WoodPile.instance.add(5);
                return TaskStatus.COMPLETED;
            }
        }
    }

}
