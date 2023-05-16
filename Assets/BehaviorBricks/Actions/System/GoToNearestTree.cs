using UnityEngine;
using Pada1.BBCore;
using UnityEngine.AI;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("GoToNearestTree")]
    public class GoToNearestTree : GOAction
    {

        Transform target;
        NavMeshAgent agent;
        public override void OnStart()
        {
            Logger.instance.updateTaskText("going to nearest tree");
            agent = gameObject.GetComponent<NavMeshAgent>();
            target = getNearestTree();
            agent.destination = target.position;
        }

        public override TaskStatus OnUpdate()
        {
            if (Vector3.Distance(agent.transform.position, target.transform.position) > 2)
                return TaskStatus.RUNNING;
            return TaskStatus.COMPLETED;
        }
        
        Transform getNearestTree()
        {
            Transform treesParent = GameObject.Find("trees").transform;

            Transform closest = treesParent.GetChild(0);
            foreach(Transform tree in treesParent)
            {
                float distance = Vector3.Distance(Survivor.instance.transform.position, tree.transform.position);
                if (distance < Vector3.Distance(Survivor.instance.transform.position, closest.position))
                    closest = tree;
            }
            return closest;
        }
    }

}
