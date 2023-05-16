using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace BBUnity.Actions
{
    [Action("animal/Feed")]
    public class Feed : GOAction
    {
        [InParam("tree")] GameObject tree;
        [SerializeField] NavMeshAgent agent;
        float timeToEat = 5.0f;

        public override TaskStatus OnUpdate()
        {
            float timeSpent = 0 * Time.deltaTime;
            
            if (timeSpent >= timeToEat)
                return TaskStatus.COMPLETED;
            
            return TaskStatus.RUNNING;
        }

    }
}
