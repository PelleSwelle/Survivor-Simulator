using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using UnityEngine.AI;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("wander")]
    public class Wander : GOAction
    {
        [InParam("agent") ][SerializeField] NavMeshAgent agent;

        [InParam("wayPointsParent")]
        public Transform wayPoints;
        [SerializeField] Vector3 currentWayPoint;

        public override void OnStart()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            currentWayPoint = getRandomWayPoint();
            agent.destination = currentWayPoint;
            
            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            if (Vector3.Distance(agent.transform.position, currentWayPoint) < 3)
                return TaskStatus.COMPLETED;

            return TaskStatus.RUNNING;
        }


        Vector3 getRandomWayPoint()
        {
            int i = Random.Range(0, wayPoints.childCount);
            return wayPoints.GetChild(i).position;
        }
    }
}
