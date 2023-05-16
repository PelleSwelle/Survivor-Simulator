using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine.AI;

namespace BBUnity.Actions
{
    [Action("explore")]
    
    public class Explore : GOAction
    {
        [InParam("poiParent")] Transform poiParent;
        [InParam("navMeshAgent")] NavMeshAgent agent;
        Vector3 currentPoi;
        LineRenderer line;
    
        public override void OnStart()
        {
            currentPoi = getRandomWayPoint();

            Logger.instance.updateTaskText("exploring");
            agent.destination = currentPoi;

            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            bool hasArrived = Vector3.Distance(agent.transform.position, currentPoi) < 2;
            if (hasArrived)
            {
                return TaskStatus.COMPLETED;
            }

            return TaskStatus.RUNNING;
        }

        Vector3 getRandomWayPoint()
        {
            int poi = (int)Random.Range(0, poiParent.childCount - 1);
            return poiParent.GetChild(poi).position;
        }
    }
}
