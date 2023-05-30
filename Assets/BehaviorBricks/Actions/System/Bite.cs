using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
namespace BBUnity.Actions
{
    [Action("bite")]
    public class Bite : GOAction
    {
        [InParam("wolf")] Wolf wolf;
        int biteDamage = 10;
        public override void OnStart()
        {
            Debug.Log("bitten by wolf");
            this.gameObject.GetComponent<AudioSource>().Play();
            Survivor.instance.GetComponent<Health>().value -= biteDamage;
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
