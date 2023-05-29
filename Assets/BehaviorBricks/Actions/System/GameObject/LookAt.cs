using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    [Action("GameObject/LookAt")]
    public class LookAt : GOAction
    {
        [InParam("lookAtTarget")] public GameObject target;

        private Transform targetTransform;

        public override void OnStart()
        {
            if (target == null)
                Debug.LogError("The look target of this game object is null", gameObject);
            else 
            {
                Debug.DrawLine(gameObject.transform.position, target.transform.position);
                targetTransform = target.transform;
            }
        }

        public override TaskStatus OnUpdate()
        {
            if (target == null)
                return TaskStatus.FAILED;
            gameObject.transform.LookAt(targetTransform.position);
            return TaskStatus.COMPLETED;
        }
    }
}
