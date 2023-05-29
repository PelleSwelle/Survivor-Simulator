using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    [Action("GameObject/ClosestGameObjectWithTag")]
    public class ClosestGameObjectWithTag : GOAction
    {
        [InParam("tag")] public string tag;

        [OutParam("foundGameObject")] public GameObject foundGameObject;

        private float elapsedTime;

        public override void OnStart()
        {
            float distance = float.MaxValue;
            foreach(GameObject objectWithTag in GameObject.FindGameObjectsWithTag(tag))
            {
                // float newDistance = (objectWithTag.transform.position + gameObject.transform.position).sqrMagnitude;
                float newDistance = Vector3.Distance(objectWithTag.transform.position, gameObject.transform.position);
                if(newDistance < distance)
                {
                    distance = newDistance;
                    foundGameObject = objectWithTag;
                }
            }
        }
        public override TaskStatus OnUpdate() => TaskStatus.COMPLETED;
    }
}
