using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using UnityEngine.AI;

namespace BBUnity.Actions
{
    [Action("Navigation/MoveToRandomPosition")] [Help("Gets a random position from a given area and moves the game object to that point by using a NavMeshAgent")]
    public class MoveToRandomPosition : GOAction
    {
        private NavMeshAgent agent;

        [InParam("area")] [Help("game object that must have a BoxCollider or SphereColider, which will determine the area from which the position is extracted")]
        public GameObject area;

        public override void OnStart()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogWarning("The " + gameObject.name + " game object does not have a Nav Mesh Agent component to navigate. One with default values has been added", gameObject);
                agent = gameObject.AddComponent<NavMeshAgent>();
            }
            agent.SetDestination(getRandomPosition());

            #if UNITY_5_6_OR_NEWER
                agent.isStopped = false;
            #else
                navAgent.Resume();
            #endif
        }

        public override TaskStatus OnUpdate()
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                return TaskStatus.COMPLETED;

            return TaskStatus.RUNNING;
        }

        private Vector3 getRandomPosition()
        {
            Vector3 areaPos = area.transform.position;
            Vector3 areaLocalScale = area .transform.localScale;
            
            BoxCollider boxCollider = area != null ? area.GetComponent<BoxCollider>() : null;
            if (boxCollider != null)
            {
                return new Vector3(
                    Random.Range(
                        areaPos.x - areaLocalScale.x * boxCollider.size.x * 0.5f, 
                        areaPos.x + areaLocalScale.x * boxCollider.size.x * 0.5f
                    ),
                    areaPos.y, 
                    Random.Range(
                        areaPos.z - areaLocalScale.z * boxCollider.size.z * 0.5f, 
                        areaPos.z + areaLocalScale.z * boxCollider.size.z * 0.5f
                    )
                );
            }
            else
            {
                SphereCollider sphereCollider = area != null ? area.GetComponent<SphereCollider>() : null;
                if (sphereCollider != null)
                {
                    float distance = Random.Range(-sphereCollider.radius, area.transform.localScale.x * sphereCollider.radius);
                    float angle = Random.Range(0, 2 * Mathf.PI);
                    return new Vector3(areaPos.x + distance * Mathf.Cos(angle),
                                       areaPos.y,
                                       areaPos.z + distance * Mathf.Sin(angle));
                }
                else
                {
                    return gameObject.transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
                }
            }
        }

        public override void OnAbort()
        {
            #if UNITY_5_6_OR_NEWER
                agent.isStopped = true;
            #else
                navAgent.Stop();
            #endif
        }
    }
}
