using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("survival/Rest")]
    public class Rest : GOAction
    {
        [InParam("restingMaterial")] public Material restingMaterial;

        public override void OnStart()
        {
            Survivor.instance.GetComponent<MeshRenderer>().material = restingMaterial;
            base.OnStart();
        }

        public override TaskStatus OnUpdate()
            => TaskStatus.RUNNING;
    }

}
