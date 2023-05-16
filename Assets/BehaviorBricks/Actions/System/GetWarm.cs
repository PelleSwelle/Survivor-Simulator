using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using UnityEngine.AI;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("survival/GetWarm")]
    public class GetWarm : GOAction
    {
        [InParam("getWarmMaterial")] Material getWarmMaterial;
        Freezer freezer = GameObject.FindObjectOfType<Freezer>();
        public override void OnStart()
        {
            Logger.instance.updateTaskText("going to get warm");
            gameObject.GetComponent<MeshRenderer>().material = getWarmMaterial;
            gameObject.GetComponent<NavMeshAgent>().destination = Fire.instance.transform.position;
            base.OnStart();
        }
        public override TaskStatus OnUpdate()
        {
            if (freezer.bodyTemp <= freezer.freezingTemp)
                return TaskStatus.RUNNING;
            return TaskStatus.COMPLETED;       
        }
    }
}
