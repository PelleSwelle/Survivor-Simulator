using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("FillFlask")]
    public class FillFlask : GOAction
    {
        public override void OnStart() => GameObject.FindObjectOfType<Inventory>().unitsOfWater ++;
        public override TaskStatus OnUpdate() => TaskStatus.COMPLETED;
    }

}
