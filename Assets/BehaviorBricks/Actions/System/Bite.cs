using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
namespace BBUnity.Actions
{
    [Action("bite")]
    public class Bite : GOAction
    {
        [InParam("wolf")] Wolf wolf;
        int biteDamage = 2;
        public override void OnStart()
        {
            Survivor.instance.health -= biteDamage;
            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            float elapsedTime = 0;
            float targetTime = 2;
            
            if (elapsedTime < targetTime)
            {
                elapsedTime += Time.time;
                return TaskStatus.RUNNING;
            }
            return TaskStatus.COMPLETED;
        }
    }
}
