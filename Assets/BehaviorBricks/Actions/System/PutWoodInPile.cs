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
        public override void OnStart()
        {
            woodPile = WoodPile.instance;
            agent.destination = woodPile.transform.position;
        }

        public override TaskStatus OnUpdate()
        {
            if (Vector3.Distance(woodPile.transform.position, agent.transform.position) > 3)
                return TaskStatus.RUNNING;
            woodPile.add(Survivor.instance.heldWood);
            return TaskStatus.COMPLETED;
        }
    }

}
